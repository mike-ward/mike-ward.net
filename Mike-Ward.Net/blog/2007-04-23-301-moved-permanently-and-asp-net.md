301 Moved Permanently and ASP.NET
2007-04-23T03:35:13
Yousef, over at [My C# Corner](http://www.mycsharpcorner.com/) has an nice article on why you should use 301 response codes to redirect your [www.xyz.com](http://www.xyz.com) site to xyz.com or vice-versa. In short, search engines might misinterpret the two sites as duplicates and reduce your page rank accordingly. Also, your page rankings get split across multiple sites. The easy and correct way to fix this is to issue a 301 permanent redirect from one name to the other. Yousef even suggests using the Application_BeginRequest method in your Global.asax file. All good stuff. Here's his sample code.

`void Application_BeginRequest(object sender, EventArgs e)  
{  
if (HttpContext.Current.Request.Url.ToString().ToLower().Contains  
("http://mycsharpcorner.com"))  
{  
HttpContext.Current.Response.Status ="301 Moved Permanently";  
HttpContext.Current.Response.AddHeader("Location",Request.Url.ToString()  
.ToLower().Replace([http://mycsharpcorner.com](http://mycsharpcorner.com),  
"http://www.mycsharpcorner.com"));  
}  
}`

This code is OK but with just a little bit of effort, we can make it better. Here's my version.

`void Application_BeginRequest(object sender, EventArgs e)  
{  
const string www = "http://www.blueonionsoftware.com";  
const string redirect = "http://mike-ward.net";  
string request = HttpContext.Current.Request.Url.ToString();  
  
if (request.StartsWith(www, StringComparison.InvariantCultureIgnoreCase))  
{  
HttpContext.Current.Response.Status = "301 Moved Permanently";  
HttpContext.Current.Response.AddHeader("Location",  
redirect + request.Substring(www.Length));  
}  
}  
`

And here's the response header I get (thank you [Fiddler](http://www.fiddlertool.com/fiddler/)) when I type in [www.blueonionsoftware.com/bloget](http://www.blueonionsoftware.com/bloget).

`HTTP/1.1 301 Moved Permanently  
Date: Sun, 22 Apr 2007 20:07:56 GMT  
Server: Microsoft-IIS/6.0  
X-Powered-By: ASP.NET  
X-AspNet-Version: 2.0.50727  
Location: /bloget  
Cache-Control: private  
Content-Length: 0  
`

OK, so it works.

So why is my version better (IMHO)? ToLower() has two problems here. First, it does not specify the culture meaning you get the current culture. In some cultures, lower and upper case don't mean the same thing. Also, ToLower() creates a new string. Again, probably not a big deal but if this code were in a high volume site, it might add extra pressure to the .NET heap because it is called on every request.
