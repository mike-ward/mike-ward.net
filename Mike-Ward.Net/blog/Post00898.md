Adding an Expires Header to Static Content in NancyFx
2014-01-13T23:46:49
[NancyFx](http://nancyfx.org) is one simplest, fastest ways to build a MVC style web site in ASP.NET. It only takes a few minutes to grok how it works.

By default, NancyFx will serve files contained in the /Content folder of your web site. Web analysis tools like [YSlow](http://yslow.org/) and Google’s [PageSpeed](http://developers.google.com/speed/pagespeed/insights/) recommend that static content be served with an “Expires header”. This header allows the browser to cache the content and use it again without generating a web request. This can increase the speed of subsequent page loads significantly depending on the resource.

To override the default response handler for static content, build a new response handler with the required “Expires header” as follows:
    
    public static class StaticContentConventionBuilderAddOn  
    {  
        public static Func<NancyContext, string, Response> AddDirectoryWithExpiresHeader(  
            string requestedPath,  
            TimeSpan expiresTimeSpan,  
            string contentPath = null,  
            params string[] allowedExtensions)  
        {  
            var responseBuilder = StaticContentConventionBuilder  
               .AddDirectory(requestedPath, contentPath, allowedExtensions);  
            return (context, root) =>  
            {  
                var response = responseBuilder(context, root);  
                if (response != null)  
                {  
                    response.Headers.Add("Expires", DateTime.Now.Add(expiresTimeSpan).ToString("R"));  
                }  
                return response;  
            };  
        }  
    }

  


NancyFx’s _StaticContentConvensionBuilder.AddDirectory_ helper method makes this easy. Finally, a function is built that invokes the response builder and then adds the “Expires header” to that response.

Finally, NancyFx has to be instructed to use the new static content convention handler by replacing the old handler with the new one. In the [Bootstrapper](https://github.com/NancyFx/Nancy/wiki/Bootstrapper), override the _ConfigureConventions_ method as follows.
    
    protected override void ConfigureConventions(NancyConventions nancyConventions)  
    {  
        base.ConfigureConventions(nancyConventions);  
        nancyConventions.StaticContentsConventions.Clear();  
        var responseBuilder = StaticContentConventionBuilderAddOn  
            .AddDirectoryWithExpiresHeader("content", TimeSpan.FromDays(365));  
        nancyConventions.StaticContentsConventions.Add(responseBuilder);  
    }  
    

  


NancyFx allows many aspects, like static content handling, to be overridden with user methods making it adaptable to many situations.
