Asset Bundling in NancyFx - Part 3
2014-02-21T15:22:22
In parts [1](/blog/post/00906/script-bundling-in-nancyfx) and [2](/blog/post/00907/asset-bundling-in-nancyfx-ndash-part-2), I built an Asset Bundling facility for use in [NancyFx](http://nancyfx.org). It provides a very easy (dare I say, super-duper-happy) method to bundling assets in NancyFx. In this last part, I'll add asynchronous support.

Related:

  * [Script Bundling in NancyFx](/blog/post/00906/script-bundling-in-nancyfx)
  * [Asset Bundling in NancFx - Part 2](/blog/post/00907/asset-bundling-in-nancyfx-ndash-part-2)
  * [Asset Bundling in NancFx - Part 3](/blog/post/00908/asset-bundling-in-nancyfx-part-3)
  * [Asset Bundling in NancFx - Part 4](/blog/post/00910/asset-bundling-in-nancyfx-part-4)

In recent releases, NancyFx has added support for asynchronous route handling. Adding asynchronous support to the Asset Bundling code is easy using C#'s new async/await facility.

First I'll extend the Bundle class to include three new functions that support async:
    
    public static async Task StylesAsync(this IResponseFormatter formatter, IEnumerable<string> files, 
        IRootPathProvider rootPathProvider)
    {
        return await formatter.GetBundleAsync(files, rootPathProvider, CssMimeType);
    }
    
    public static async Task ScriptsAsync(this IResponseFormatter formatter, IEnumerable<string> files, 
        IRootPathProvider rootPathProvider)
    {
        return await formatter.GetBundleAsync(files, rootPathProvider, JsMimeType);
    }
    
    public static async Task GetBundleAsync(this IResponseFormatter formatter, IEnumerable<string> files,
                IRootPathProvider rootPathProvider, string contentType)
    {
        var responseTask = new Task(() => GetBundle(formatter, files, rootPathProvider, contentType));
        responseTask.Start();
        return await responseTask;
    }

[https://gist.github.com/mike-ward/9100604](https://gist.github.com/mike-ward/9100604)

And here's how to use it:
    
    public SiteModule(IRootPathProvider rootPathProvider)
    {
        Get["/"] = p => View["home"];
    
        Get["/styles", true] = async (p, ct) => await Response.StylesAsync(
            new[] {"css/pure-min.css", "css/styles.css"}, rootPathProvider);
    
        Get["/scripts", true] = async (p, ct) => await Response.ScriptsAsync(
            new[] {"js/third-party/angular.min.js", "js/app/app.js"}, rootPathProvider);
    }

Easy, smeasy!

What's next?

It might be fun to look into adding some of the other traditional asset bundling services like [SASS](http://sass-lang.com/) and [Coffeescript](http://coffeescript.org/) support. These are harder nuts-to-crack in that native .NET implementations do not exist. One thought I had was to translate _libsass_ to C#. Suggestions for other features are welcomed!
