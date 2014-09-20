Bloget - Alpha 6 Released
2007-03-06T02:00:38
Whoa!, Alpha 5 just went out a week ago and I'm now deploying Alpha 6. What happened? In a word, good stuff. I discovered earlier last week that you can embed resources in binaries and serve them up in web pages. Say what? Ok, let's look at an example. Let's say you have an static image of a help button you want to display in your ASP.NET control. Easy enough but the image has to exist in a specific location on the server in order to link to it. That means when you deploy your control, the image has to be in the correct location or it won't display.

There are two problems with this scenario. First it requires that you ship an extra file with your deployment and second, it has to be installed on the server in the correct location to work. I think it makes more sense to embed the image in the control assembly and serve it up on demand. Question is, how do you link to an embedded resource from a web page?

![sun](http://spaces.live.com/rte/emoticons/sun.gif) Answer, **WebResource.axd**.

ASP.NET has a builtin HTTP handler called WebResource.axd that allows you to build links to embedded resources. This is like gold as far as I'm concerned. I won't go into details here since the steps are a bit complicated. These two blogs links, [Jeff's Junk](http://weblogs.asp.net/jeff/archive/2005/07/18/419842.aspx) and [4 Guys From Rolla](http://aspnet.4guysfromrolla.com/articles/080906-1.aspx) supply instructions on how to use WebResource.axd to link to embedded resources.

So what did I do with this new found power you ask? Simple, I embedded OpenWYSIWYG into Bloget. Earlier distributions of Bloget required two binaries, Bloget.dll and FreeTextBox.dll. [FreeTextBox](http://freetextbox.com) is a nice wysiwyg editor that ships as an ASP.NET control. [OpenWYSIWYG](http://www.openwebware.com) is a 100% JavaScript [wysiwyg](http://en.wikipedia.org/wiki/WYSIWYG) text editor. I've always liked OpenWYSIWYG, but then there was all those scripts and images that would have to be added to the distribution. By embedding these files in Bloget I get a really nice text editor and eliminate the need for FreeTextBox.dll. Bloget is now a single binary distribution.

In addition, I get a wysiwyg text editor with source that I can tweak. I've wanted something like this for [Bloget](/bloget) for quite sometime but was unwilling to ship a bunch of extra files with the distribution. Now I get my source and can embed it to (there's a pun in there somewhere).

![](http://az667460.vo.msecnd.net/cdn/images/blog/WindowsLiveWriter/BlogetAlpha6_A2D0/archie%5B3%5D.jpg)

To summarize, Alpha 6 sports a brand new builtin Wysiwyg editor and is a single binary distribution. Download it now and check it out. Alpha 7 will introduce new controls like a blog roll and a second type of archive control so stay tuned and as always, send feedback. - Mike
