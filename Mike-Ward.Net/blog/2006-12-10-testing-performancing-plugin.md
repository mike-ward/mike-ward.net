Testing Performancing Plugin
2006-12-10T01:56:31
  
Testing the Performancing blogging plugin. This is a FireFox extension. It's supports [MetaWeblog API](http://www.xmlrpc.com/metaWeblogApi) but not correctly. This is the second time I've found a bug in the implementation of MetaWeblog API which is really sad because it really is a simple protocol. Really guys, it's a one page specification. So what's the bug? Performancing passes boolean tags as true/false. The specification says it should be 1/0. That may not sound like a big deal but it does require putting special case code into my XmlRpc parser to deal with it. Really annoying and unnecessary.  
  
The other bug I see in almost all of the blog publishing tools with regard to MetaWeblog API implementation is returning categories as an array instead of struct. I agree that it probably makes more sense to return them as an array of values but the specification is quite clear that is should be a struct (actually, a struct of structs). Since it appears to be near universal (Microsoft even documents [getCategories](http://msdn2.microsoft.com/en-us/library/ms812819.aspx) it as returning an array), I'll acquiesce, but it sure does make a mess of things.  
  
As for the tool itself, it's pretty basic. I'm going to try [BlogJet](http://www.blogjet.com/) next which I hear is much better.  
  
powered by [performancing firefox](http://performancing.com/firefox)  
  

