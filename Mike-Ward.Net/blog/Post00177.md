HTTP Compression in ASP.NET 2.0
2007-06-10T23:01:45
Mads Kristensen writes an excellent blog called .NET Slave. Recently, he posted an article on how easy it is to enable [HTTP compression](http://www.madskristensen.dk/blog/PermaLink,guid,60533e14-789d-41a1-92d2-43efddce7d8e.aspx) in ASP.NET 2.0 without having to touch IIS. This is a handy thing to have when using hosted services like [Go Daddy](http://godaddy.com) where you don't have access to the IIS configuration. I've had it bookmarked for some time intending to add it to this site. Well I finally took the plunge and added it.

The code is surprisingly brief and works as advertised. However, I did run into a few issues that the original code did not address. For instance, the built-in web server in Visual Studio 2005 does not seem to work correctly when compression is enabled. Also, some services like [Feed Burner](http://ww.feedburner.com) do not accept compression even though their request header indicates otherwise. I've added a few extra checks to the original code to fix these issues.

`using System;  
using System.Web;  
using System.IO.Compression;  
  
public class CompressionModule : IHttpModule  
{  
const string GZIP = "gzip";  
const string DEFLATE = "deflate";  
static string[] exceptions = { "=rss", "=rpc", "localhost" };  
  
void IHttpModule.Init(HttpApplication context)  
{  
context.BeginRequest += BeginRequest;  
}  
  
void BeginRequest(object sender, EventArgs e)  
{  
try  
{  
if (RequestContains(exceptions))  
{  
return;  
}  
  
HttpApplication app = sender as HttpApplication;  
  
if (EncodingAccepted(GZIP))  
{  
app.Response.Filter = new GZipStream(app.Response.Filter, CompressionMode.Compress);  
SetEncoding(GZIP);  
}  
  
else if (EncodingAccepted(DEFLATE))  
{  
app.Response.Filter = new DeflateStream(app.Response.Filter, CompressionMode.Compress);  
SetEncoding(DEFLATE);  
}  
}  
  
catch (Exception)  
{  
// Log it here...  
}  
}  
  
bool RequestContains(string[] values)  
{  
string request = HttpContext.Current.Request.Url.AbsoluteUri.ToLowerInvariant();  
  
foreach (string value in values)  
{  
if (request.Contains(value))  
{  
return true;  
}  
}  
  
return false;  
}  
  
bool EncodingAccepted(string encoding)  
{  
string acceptEncoding =   
HttpContext.Current.Request.Headers["Accept-encoding"] ?? string.Empty;  
  
return acceptEncoding.Contains(encoding);  
}  
  
void SetEncoding(string encoding)  
{  
HttpContext.Current.Response.AppendHeader("Content-encoding", encoding);  
}  
  
void IHttpModule.Dispose()  
{  
// Nothing to dispose;   
}  
}`

Technorati tags: [ASP.NET](http://technorati.com/tags/ASP.NET), [HTTP](http://technorati.com/tags/HTTP), [Compression](http://technorati.com/tags/Compression)
