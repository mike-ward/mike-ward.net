Script Bundling in NancyFx
2014-02-19T20:41:35
There are several script bundling options available in NancyFx including SquishIt and Microsoft’s Bundle and Minification classes. Try as I might though, I couldn’t get them to work. There’s something funky with the Razor view engine that makes this task impossible at the moment.

Related:

  * [Script Bundling in NancyFx](/blog/post/00906/script-bundling-in-nancyfx)
  * [Asset Bundling in NancFx - Part 2](/blog/post/00907/asset-bundling-in-nancyfx-ndash-part-2)
  * [Asset Bundling in NancFx - Part 3](/blog/post/00908/asset-bundling-in-nancyfx-part-3)
  * [Asset Bundling in NancFx - Part 4](/blog/post/00910/asset-bundling-in-nancyfx-part-4)

This got me to thinking, how hard can it be? Isn’t it just concatenating files into a single response? Well, there’s likely more to it, but as a first cut this works for me.

See [Part 2](/blog/post/00907/asset-bundling-in-nancyfx-ndash-part-2) for an implementation with caching support
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Nancy;
    using Nancy.Responses;
    
    namespace SendExplorer.utilities
    {
        public static class Bundle
        {
            public static Response Styles(this IResponseFormatter formatter, IEnumerable<string> paths, 
                IRootPathProvider rootPathProvider)
            {
                return formatter.FromText(ConcatTextFiles(paths, rootPathProvider), "text/css");
            }
    
            public static Response Scripts(this IResponseFormatter formatter, IEnumerable<string> paths, 
                IRootPathProvider rootPathProvider)
            {
                return formatter.FromText(ConcatTextFiles(paths, rootPathProvider), 
    		"application/x-javascript");
            }
    
            public static Response FromText(this IResponseFormatter formatter, string text, 
    		string contentType)
            {
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
                return new StreamResponse(() => stream, contentType);
            }
    
            public static string ConcatTextFiles(IEnumerable<string> paths, 
                IRootPathProvider rootPathProvider)
            {
                return string.Join(Environment.NewLine, 
    		paths.Select(p => ReadTextFile(rootPathProvider, p)));
            }
    
            private static string ReadTextFile(IRootPathProvider rootPathProvider, string path)
            {
                return File.ReadAllText(Path.Combine(rootPathProvider.GetRootPath(), path));
            }
        }
    }

[https://gist.github.com/mike-ward/9100604](https://gist.github.com/mike-ward/9100604)

And here’s how to use it.
    
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

I won’t be surprised if I run into issues. I can think of a few already.

  * No caching. Every call will read the files and do the concatenation. This is easy to fix and I’ll add it to the gist when I do it. 
  * No minification. Personally, I think minification is overrated. The major benefit of bundling is fewer requests. 
  * No name mangling to force the browser to load new assets when on of the assets changes. I’m content with F5 for now.

I would really like to start a discussion on this so please feel free to comment. Script bundling shouldn’t be rocket science.
