Asset Bundling in NancyFx &ndash; Part 2
2014-02-20T15:29:42
[Last time](/blog/post/00906/script-bundling-in-nancyfx) I wrote a "naïve" implementation of asset bundling for [NancyFx](http://nancyfx.org). While effective it was inefficient. This time around I'll add cache support and, "304, Not Modified" handling.

Related:

  * [Script Bundling in NancyFx](/blog/post/00906/script-bundling-in-nancyfx)
  * [Asset Bundling in NancFx - Part 2](/blog/post/00907/asset-bundling-in-nancyfx-ndash-part-2)
  * [Asset Bundling in NancFx - Part 3](/blog/post/00908/asset-bundling-in-nancyfx-part-3)
  * [Asset Bundling in NancFx - Part 4](/blog/post/00910/asset-bundling-in-nancyfx-part-4)

Here's the code.
    
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Nancy;
    using Nancy.Helpers;
    using Nancy.Responses;
    
    namespace SendExplorer.utilities
    {
        public static class Bundle
        {
            private static readonly ConcurrentDictionary<int, assetbundle> BundleCache = 
                new ConcurrentDictionary<int, assetbundle>();
    
            public static Response Styles(this IResponseFormatter formatter, IEnumerable<string> files, 
    		IRootPathProvider rootPathProvider)
            {
                return formatter.GetBundle(files, rootPathProvider, "text/css");
            }
    
            public static Response Scripts(this IResponseFormatter formatter, IEnumerable<string> files, 
    		IRootPathProvider rootPathProvider)
            {
                return formatter.GetBundle(files, rootPathProvider, "application/x-javascript");
            }
    
            public static Response GetBundle(this IResponseFormatter formatter, IEnumerable<string> files,
                IRootPathProvider rootPathProvider, string contentType)
            {
                var hash = BundleHash(files, rootPathProvider);
                if (BundleCache.Keys.Contains(hash) == false)
                {
                    var text = ConcatTextFiles(files, rootPathProvider);
                    var bytes = Encoding.UTF8.GetBytes(text);
                    var lastWriteTimeUtc = DateTime.Now;
                    var etag = string.Concat("\"", lastWriteTimeUtc.Ticks.ToString("x"), "\"");
                    var assetBundle = new AssetBundle 
    			{ LastUpdate = lastWriteTimeUtc, ETag = etag, Bytes = bytes };
                    BundleCache.TryAdd(hash, assetBundle);
                }
                var bundle = BundleCache[hash];
    
                if (CacheHelpers.ReturnNotModified(bundle.ETag, bundle.LastUpdate, formatter.Context))
                {
                    var response = new Response
                    {
                        StatusCode = HttpStatusCode.NotModified,
                        ContentType = null,
                        Contents = Response.NoBody
                    };
                    return response;
                }
    
                return ResponseFromBundle(bundle, contentType);
            }
    
            private static int BundleHash(IEnumerable<string> files, IRootPathProvider rootPathProvider)
            {
                return files
                    .Select(file => FullPath(file, rootPathProvider))
                    .Select(file => new FileInfo(file).LastWriteTimeUtc.GetHashCode() ^ file.GetHashCode())
                    .Aggregate((a, b) => a ^ b);
            }
    
            public static Response ResponseFromBundle(AssetBundle assetBundle, string contentType)
            {
                var stream = new MemoryStream(assetBundle.Bytes);
                var response = new StreamResponse(() => stream, contentType);
                response.Headers["ETag"] = assetBundle.ETag;
                response.Headers["Last-Modified"] = assetBundle.LastUpdate.ToString("R");
                return response;
            }
    
            public static string ConcatTextFiles(IEnumerable<string> files, 
                IRootPathProvider rootPathProvider)
            {
                return string.Join(Environment.NewLine, 
    		files.Select(p => ReadTextFile(p, rootPathProvider)));
            }
    
            private static string ReadTextFile(string path, IRootPathProvider rootPathProvider)
            {
                return File.ReadAllText(FullPath(path, rootPathProvider));
            }
    
            private static string FullPath(string path, IRootPathProvider rootPathProvider)
            {
                return (Path.Combine(rootPathProvider.GetRootPath(), path));
            }
    
            public class AssetBundle
            {
                public DateTime LastUpdate { get; set; }
                public string ETag { get; set; }
                public byte[] Bytes { get; set; }
            }
        }
    }

[https://gist.github.com/mike-ward/9100604](https://gist.github.com/mike-ward/9100604)

Code highlights:

  * Assets are bundled once and cached for later reference. 
  * ETag and Last-Modified headers are added and checked (using some Nancy helper methods). If the nothing has changed, a 304 Not Modified response is returned. 
  * Of particular interest is the _BundleHash_ method. It builds a hash based on the names and timestamps of the assets. Change one of the asset timestamps and the hash should change forcing a new bundle to get generated.

And here's how to use it:
    
    using Nancy;
    using SendExplorer.utilities;
    
    namespace SendExplorer.Modules
    {
        public class SiteModule : NancyModule
        {
            public SiteModule(IRootPathProvider rootPathProvider)
            {
                Get["/"] = p => View["home"];
                Get["/about"] = p => View["about"];
    
                Get["/styles"] = p => Response.Styles(
    		new[] {"css/pure-min.css", "css/styles.css"}, 
    		rootPathProvider);
    
                Get["/scripts"] = p => Response.Scripts(
    		new[] {"js/third-party/angular.min.js", "js/app/app.js"}, 
    		rootPathProvider);
            }
        }
    }

And here's a test to show how the 304 Not Modified response works:
    
    [TestMethod]
    public void BundlingReturnsNotModifiedOnSecondAccess()
    {
        var browser = new Browser(with => with.Module<sitemodule>());
        var actual = browser.Get("/scripts");
        actual.StatusCode.Should().Be(HttpStatusCode.OK);
        var lastModified = actual.Headers["Last-Modified"];
        actual = browser.Get("/scripts", with =>
        {
            with.Header("If-None-Match", "*");
            with.Header("If-Modified-Since", lastModified);
        });
        actual.StatusCode.Should().Be(HttpStatusCode.NotModified);
        actual.Body.Should().BeEmpty();
    }

The final piece of the puzzle is to add compression. This is a harder nut-to-crack in that the type of asset determines the tool used to compress it.
