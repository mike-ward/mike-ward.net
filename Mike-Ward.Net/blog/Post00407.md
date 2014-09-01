Resolving Virtual Paths to Uri's in ASP.Net
2008-11-26T22:31:56
ASP.Net has a boat load of methods for dealing with paths. However, no where can I find a method to convert a virtual path (~/) to its equivalent Uri. Perhaps it’s there but darn if I can find it. The best I can up with is:
    
    var uri = Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/SomePage.aspx")

If the site is hosted at: [http://example.com/website](http://example.com/website), then this code yields [http://example.com/website/SomePage.aspx](http://example.com/website/SomePage.aspx), which is what I want. 

[![kick it on DotNetKicks.com](http://www.dotnetkicks.com/Services/Images/KickItImageGenerator.ashx?url=http%3a%2f%2fblueonionsoftware.com%2fblog.aspx%3fp%3de1670afd-2b62-4343-83ab-7a70b6b35e10)](http://www.dotnetkicks.com/kick/?url=http%3a%2f%2fblueonionsoftware.com%2fblog.aspx%3fp%3de1670afd-2b62-4343-83ab-7a70b6b35e10)

Perhaps there is a better way to do this?
