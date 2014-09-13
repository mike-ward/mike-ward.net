Nancy Static Content and Internet Explorer
2013-04-18T14:43:59
Many of you like to download and use my desktop gadgets (that Microsoft unceremoniously killed in Windows 8). Setting up a web site to download a gadget should not be a big deal, right? Something like:
    
    <a href="content/downloads/stopwatch.gadget">stopwatch.gadget</a>

should work. And it does for Chrome, Firefox and other browsers. Try this with Internet Explorer and you’ll get a prompt to save the file as:
    
    stopwatch.zip

WTF?

Where did this ".zip" thing come from?

This is Internet Explorer’s way of trying to help you out. When files are downloaded, the "Content Type" is usually specified in the response header. Nancy does a good job of matching extensions to their "Content Types" (technically a MIME Type). However, Nancy does not have an extension mapping for ".gadget".

Because the "Content Type" is not specified, Internet Explorer peeks at the content to determine what kind of file is being downloaded. Gadgets are packaged as .Zip archives and since Windows doesn’t recognize it’s own ".gadget" extension, it incorrectly decides to save it as a ".zip" archive.

Usually you can override/extend things in [Nancy](http://NancyFx.org) but the MIME-Type dictionary is private. This may be a conscious design decision or just an oversight.

OK, so lets wire-up a route and handle it our selves.
    
    Get["content/downloads/stopwatch.gadget"] = pars =>  
        Response.AsFile("content/downloads/stopwatch.gadget", "application/x-windows-gadget");

  


This doesn’t work. This route is never matched due to some extra "magic" Nancy performs on file extensions. [The documentation spells out the process](https://github.com/NancyFx/Nancy/wiki/Content-Negotiation#file-extension-support).

OK, I’m flexible. We’ll drop the ".gadget" extension from our links and change the route.
    
    Get["content/downloads/stopwatch"] = pars =>  
        Response.AsFile("content/downloads/stopwatch.gadget", "application/x-windows-gadget");

  


Now our route matches and we have the right MIME-Type for our content and … Damn!

Internet Explorer still wants to save it as a zip archive.

Here’s the rub. Internet Explorer needs a second header to behave correctly, "Content-Disposition".

Since there's no "Helper" method in Nancy to construct a response with the additional header so we have to write it ourselves.
    
    public class DownloadsModule : NancyModule  
    {  
        public DownloadsModule(IRootPathProvider rootPathProvider)  
        {          
            Get["/content/downloads/(?<file>(tweetz31|stopwatch|simplyweather|marketreport|calculator))"]   
                = pars => new GadgetResponse(pars.file.Value, rootPathProvider);  
        }  
       
        public class GadgetResponse : Response  
        {  
            public GadgetResponse(string gadget, IRootPathProvider rootPathProvider)  
            {  
                var name = gadget + ".gadget";  
                Headers.Add("Content-Disposition", "attachement; filename=" + name);  
                ContentType = "application/x-windows-gadget";  
                var path = Path.Combine(rootPathProvider.GetRootPath(), "content/downloads/", name);  
                Contents = stream =>  
                    {  
                        using (var file = File.OpenRead(path)) file.CopyTo(stream);  
                    };  
            }  
        }  
    }

  


I modified the route to use a regular expression to handle additional gadgets.

The "Content-Disposition" header tells the browser the preferred name for the downloaded file. _IRootPathProvider_ is a standard Nancy interface that gets the absolute path to the root of the web site. This is needed to locate the file on server.

It’s 2013 and still I have to deal with Internet Explorer specific issues on my web site (sigh).
