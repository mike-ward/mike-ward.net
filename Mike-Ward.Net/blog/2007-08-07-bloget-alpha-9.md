Bloget Alpha 9
2007-08-07T00:57:26
Bloget alpha 9 is available for download. It also marks the end of the alpha releases. There's an old saying in the software biz that goes something like, "Sometimes you have to just shoot the programmers and ship the darn thing." Well, I'm not going that far but my cat Euclid says it's time. 

So what's new? Mostly little stuff. I've decided to simplify the distribution from the example based format I was using earlier. There is now one file that contains the style sheet and web site. Normally, one uses external style sheets but I wanted to really drive home the point about just how little code it takes to write a fully functional blog using Bloget.

![](http://www.myotherdrive.com/public/blueonion/Blog/thumb_aqua-sphere.jpg) I settled on a theme. It's inspired by [this guy](http://bloggertemplatesbycaz.blogspot.com) but I really only duplicated the look. The style sheet itself was not as compact and simple as I thought it could be so I started from scratch. The theme uses no images for layout so it's super fast. I think it's pretty darn cool that it describes an entire blog in just over a hundred lines of markup.

There's an installer now. It's just a Visual Studio generated installer at this point. I've tried it in a number of environments. Sometimes it gets the file permissions correct for the web site and sometimes it does not. Not sure why this is but I'll probably rewrite it in [WiX](http://wix.sourceforge.net/) before the final release.

I've added a navigation menu to the administration section. This has the usual entries like Write, Administration, Drafts and so on. Being a control I thought it might be better to let the author layout these items but over the course of development I found that idea didn't sit to well.

I've also added coverage tests for every part of the project and all new code gets unit tests. I was a little late to the the test driven development party but I'm making up for lost ground now. If you haven't looked into test driven development, you owe it to yourself to swallow your pride and try it out. It's really humbling to see just how many mistakes one catches by writing tests.

I have a couple of new themes I'll post later. One looks like the default Wordpress Kubrick theme. I think mine looks and works better but then I'm biased. I've also grabbed another Wordpress theme called Samansa. It took about an hour to redo each theme in Bloget.

Beta one should occur in the next month or so. The only feature I'm intending to add is a category editor. It will include category merging which is something I haven't seen elsewhere.

Well, that's it. Looking back on my little blog project, I'm quite happy with the result. I have a fully functional blog engine expressed in a single binary. The template language is robust and comprehensive. It has to be the simplest blog on the planet when it comes to deployment. There are features like plug-ins and events that I don't have yet. Those things will come later. But for brand X bloggers like myself it's one sweet little program. Do give it a try and do send me your feedback.

- Mike
