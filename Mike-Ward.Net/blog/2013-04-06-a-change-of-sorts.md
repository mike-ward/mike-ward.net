A Change of Sorts
2013-04-06T15:04:33
“Who is the Mike Ward chap and what have you done with Blue Onion Software?”

This started about a month ago when I decided to update my blog engine. [Bloget](/bloget) was my Web-Forms based blog engine that I wrote ages ago when modems ruled and AOL dominated the Internet . It's served me (and others) well. However, having lived in the [MVC](http://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller) world of web development for the last couple of years I’ve found there are better ways to generate a web page.

Blog engines are not hard to write, especially with newer toolsets and frameworks. Bloget was an all inclusive, [Wordpress](http://wordpress.org) like, blog engine. Although I never came close to the capabilities of Wordpress, it served my needs well. The new blog engine is much lighter and simpler. I’ve tossed off the stuff I don’t use and kept it to the basics. Here’s an brief overview of what I used.

[NancyFx](http://nancyfx.org) – Nancy is a [Sinatra](http://en.wikipedia.org/wiki/Sinatra_(software)) inspired MVC framework for ASP.Net. It’s low ceremony and just plain fun to write in. The home page communicates volumes about its philosophy in just 7 lines of code (including braces).

[Super Simple View Engine](https://github.com/grumpydev/SuperSimpleViewEngine) – NancyFx’s default view engine. Yeah it’s simple but I’ve found it’s all I need. Need more? You can use [Razor](http://weblogs.asp.net/scottgu/archive/2010/07/02/introducing-razor.aspx), or [Spark](http://sparkviewengine.com/) or a half dozen other view engines.

Database – I use files. It’s a bit old school but it’s all that’s needed. I just serialize a blog post to a file using [JSON](http://json.org) with the post number as the name of the file. Bloget did a similar thing. I tested it by generating 10,000 posts. Didn’t phase it in the least.

Frontend – HTML. Shockingly, you an actually write useful stuff in plain old HTML. Blog content is mostly just text and images so there’s really no need for a fancy [MVVM](http://en.wikipedia.org/wiki/Model_View_ViewModel) like [KnockoutJS](http://knockoutjs.com) or [BackboneJS](http://backbonejs.org/) or [AngularJS](http://angularjs.org/). I would certainly feel different if I were handling comments.

Comments – I punted here and use [Disqus](http://disqus.com/). It’s free and it handles the very messy business of moderating and filtering comments. Comment systems are one of the harder (maybe the hardest?) tasks of writing a blog engine. Call me weak.

Editor – Here I opted not to implement an online editor. I never used the one I wrote for Bloget because the offline editors are so much nicer (Windows Live Writer being my favorite). To support offline editors I needed to implement a blogging API’s. The only one I’m familiar with is [MetaWeblog API](http://xmlrpc.scripting.com/metaWeblogApi.html). The documentation is lacking and relies on some defunct Blogger API’s, which are no longer documented. It’s also an XML-RPC protocol. This was the most difficult, fiddly part of writing the new blog engine. Suggestions on a better, Windows Live Writer compatible API, are welcome.

And then there was that name: Blue Onion Software. Where did that name come from?. Actually, it was a bit of a joke. I was sitting in my driveway smoking a cigar and needed a domain for my then new blog. I thought of “Blue Onion” but some catering business in Nevada already owned it. So I tacked on the “Software” and thought everyone would know this was not a real company. I guess I was too subtle. I got a lot of inquires about hiring. 

This time around I thought I would be a little more up front in declaring this as a personal blog. Amazingly, I secured a domain with my name in it, albeit with a hyphen. Still feels strange seeing my name so prominent on the site. If I were a bit more clever, I might come up with a more interesting title (my colleague, Adam Marks has a web site named “[Defining Terms](http://definingterms.com)”, which I’ve always admired). My mind just doesn’t work that way.

The original mission of this site was to bookmark a bunch of stuff I found interesting and of use. The “Friday Links” posts do that in part. What has fallen off over the years are the in-depth programming articles. I write code everyday and over time I’ve come to think that what I’m doing as obvious and not worthy of a blog post. I’m wrong about that. This business is hard and even the seemingly easy stuff is worthy of a note, if only for the discussion it generates.
