Custom Error Pages in NancyFx
2013-04-11T17:19:14
[NancyFx](http://nancyfx.org) (commonly just called Nancy) is a [Sinatra](http://en.wikipedia.org/wiki/Sinatra_(software)) inspired MVC framework for ASP.Net. It’s low ceremony and just plain fun to write in. The home page communicates volumes about its philosophy in just 7 lines of code (including braces).

One of the things I like about this framework is how easy it is to override default behavior. Here’s the default 404 page.

[![Nancy404](/content/images/blog/Windows-Live-Writer/Custom-Error-Pages_F75F/Nancy404_thumb.png)](/content/images/blog/Windows-Live-Writer/Custom-Error-Pages_F75F/Nancy404_2.png)

Cute, but we had a customer that wanted something a bit more “Corporate”.

For many operations in Nancy you can simply implement an interface and the framework will incorporate it at runtime. Implementing a custom error page is a good example of how, “Things just work”.

_Editors Note: See updates at the the end of this post._
    
    public class StatusCodeHandler : IStatusCodeHandler  
    {  
        private readonly IRootPathProvider _rootPathProvider;  
      
        public StatusCodeHandler(IRootPathProvider rootPathProvider)  
        {  
            _rootPathProvider = rootPathProvider;  
        }  
      
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)  
        {  
            return statusCode == HttpStatusCode.NotFound;  
        }  
      
        public void Handle(HttpStatusCode statusCode, NancyContext context)  
        {  
            context.Response.Contents = stream =>  
            {  
                var filename = Path.Combine(_rootPathProvider.GetRootPath(), "content/PageNotFound.html");  
                using (var file = File.OpenRead(filename))  
                {  
                    file.CopyTo(stream);  
                }  
            };  
        }  
    }

  


Notice there isn’t any code to register the new handler. Simply adding a class that implements _IStatusCodeHandler_ is all it takes. 

Let’s look at the individual methods.
    
    public StatusCodeHandler(IRootPathProvider rootPathProvider)  
    {  
        _rootPathProvider = rootPathProvider;  
    }

  


_IRootPathProvider_ is a standard Nancy interface that has one method, _GetRootPath()_. _GetRootPath()_ returns the root path of where the web site is installed on the server. Nancy provides a default implementation of this interface.

Nancy’s IoC container ([TinyIoC](https://github.com/grumpydev/TinyIoC)) does the rest. It locates the _StatusCodeHandler_ class and using constructor injection, creates an instance of _StatusCodeHandler_ with the required _IRootPathProvider_ instance. That’s a mouthful and if you’ve never worked with IoC’s, feels a bit magical. It’s also an excellent example of how IoC’s can simplify your code.
    
    public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)  
    {  
        return statusCode == HttpStatusCode.NotFound;  
    }

  


The rest is easier to understand. The _HandleStatusCode()_ method checks if status code is _HttpStatusCode.NotFound_. Returning **true** tells Nancy that our _StatusCodeHandler_ will handle the response to this status code.

And finally, the _Handle()_ method generates the new error page. Easy-Schmeasy.
    
    public void Handle(HttpStatusCode statusCode, NancyContext context)  
    {  
        context.Response.Contents = stream =>  
        {  
            var filename = Path.Combine(_rootPathProvider.GetRootPath(), "content/PageNotFound.html");  
            using (var file = File.OpenRead(filename))  
            {  
                file.CopyTo(stream);  
            }  
        };  
    }

  


The content is streamed from a file which is why I needed the root-path to locate it.

[Demo Custom 404 Page](/error)

**Update**

Based on feedback there’s a better way to implement this class. Here’s the updated code.
    
    public class PageNotFoundHandler : DefaultViewRenderer, IStatusCodeHandler  
    {  
        public PageNotFoundHandler(IViewFactory factory) : base(factory)  
        {  
        }  
      
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)  
        {  
            return statusCode == HttpStatusCode.NotFound;  
        }  
      
        public void Handle(HttpStatusCode statusCode, NancyContext context)  
        {  
            var response = RenderView(context, "PageNotFound");  
            response.StatusCode = HttpStatusCode.NotFound;  
            context.Response = response;  
        }  
    }

  


Using this method has a couple of advantages. 

  * No longer requires a reference to _IRootPathProvider_
  * _RenderView()_ allows the inclusion of model data (not used in this example). The model data could include error details for instance. 
  * Invokes the view engine which allows for template expansions.

Note that the _PageNotFound_ template will have to be located with your other views.
