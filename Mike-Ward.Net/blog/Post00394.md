PDC Wrap Up
2008-11-02T21:33:36
The last two days were as interesting as the first two. Seemed like the week got busier towards the end which is why I’m playing catch up now.

One of the benefits of attending a PDC is that you get to interact with the Microsoft developers. This can lead to some interesting and informative sessions. My colleague and good friend, Brian Genisio (whose excellent blog “[House of Bilz](http://brian.genisio.org/)” should be on your reading list), encouraged me to attend an Open Space meeting with Glen Block, the product manager for the Managed Extensibility Framework (MEF).

Open Space meetings originated back in the mid 1980’s and is a form of meeting that allows people who are passionate about a particular subject to meet and discuss. Open Space meetings have a single facilitator who initiates and concludes the meeting and explains the general method. The facilitator has no other role in the meeting and does not control the actual gathering in any way. Proponents suggest guidelines that can be summarized by 4 simple rules:

  * _Whoever comes is the right people_: this alerts the participants that attendees of a session class as "right" simply because they care to attend 
  * _Whatever happens is the only thing that could have_: this tells the attendees to pay attention to events of the moment, instead of worrying about what could possibly happen 
  * _Whenever it starts is the right time_: clarifies the lack of any given schedule or structure and emphasises [creativity](http://en.wikipedia.org/wiki/Creativity) and [innovation](http://en.wikipedia.org/wiki/Innovation)
  * _When it's over, it's over_: encourages the participants not to waste time, but to move on to something else when the fruitful discussion ends 

I was not familiar with this format which is why I’m describing it here. Needless to say it was interesting. In fact, the other phrase you hear thrown around from Open Space proponents is “Be prepared to be surprised.” Here’s a picture of the group (Glen Block is the guy closest to the whiteboard on the left).

![MEF heads discussing the Managed Extensiblity Framework](/content/images/blog/PDCWrapUp_D83E/openspace.jpg)

Pretty informal affairs and yet a lot of good information exchange went on here. In fact, we found out that the Managed Extensibility Framework team is working on an **Inversion of Control (IOC) container** for the next release. This was not announced at the general conference so I guess I got a scoop of sorts. No promises it will ship with the product but their intention is clearly to do so. I was surprised needless to say.

And speaking of the [Managed Extensibility Framework](http://www.google.com/url?sa=t&source=web&ct=res&cd=3&url=http%3A%2F%2Fcode.msdn.microsoft.com%2Fmef&ei=vRsOSdGQJ4qOwQGfl7ly&usg=AFQjCNG8E7EMABnQwfyFkLkHT6rTeO2VYQ&sig2=FeLWqaw9jsAJpFlmcVa75g), if you have not checked it out, you can [view the PDC video](http://mschnlnine.vo.llnwd.net/d1/pdc08/WMV-HQ/TL33.wmv). Once you “get it” you want to use it immediately. It will play a central role in the next version of Visual Studio and other Microsoft products. It was also announced that it will be included in .Net 4.0 runtime distribution. And finally, it’s open source. How cool is that?

I also had a chance to meet [Laurent Bugnion](http://www.galasoft.ch/), author of the highly anticipated “[Silverlight 2 Unleashed](http://www.amazon.com/Silverlight-2-Unleashed-Laurent-Bugnion/dp/0672330148/ref=sr_1_2?ie=UTF8&s=books&qid=1225659313&sr=1-2).” Here he is pictured with another one of my colleagues (Laurent is on the left).

![lb](/content/images/blog/PDCWrapUp_D83E/lb.jpg)

We only talked for about 15 minutes but it was a very interesting talk indeed. It would have been great to grab a beer and talk for a few hours. Needless to say, with the release of his new book, he was a busy guy.

The PDC also has some rather strange publicity stunts as well. For instance, Oracle had guys on motor scooters zipping around with tow behind signs. I’m not sure what I was suppose to get out of it but I sure did notice it.

![oracle scooters](/content/images/blog/PDCWrapUp_D83E/oracle.jpg)

Usually by the third and fourth days, things have slowed down a bit and the talks are not as interesting. The press has gone home and the keynote speakers are back in their offices doing keynote-ie things I guess. However, some of the most exciting discoveries for me personally came in these last two days.

The [Managed Extensibility Framework](http://code.msdn.microsoft.com/mef) has just rocked my world. We tried to solve this problem a while back for a more specific circumstance. Needless to say, I like MEF better.

[Managed Contract Tools](http://research.microsoft.com/research/downloads/Details/4ed7dd5f-490b-489e-8ca8-109324279968/Details.aspx): Currently a Microsoft Research Project, it should ship with .Net 4.0. I would have preferred more use of attributes here but the concept is great and long over due.

[Pex](http://research.microsoft.com/research/downloads/Details/d2279651-851f-4d7a-bf05-16fd7eb26559/Details.aspx): A white box testing tool. Again, it’s best to [watch the video](http://mschnlnine.vo.llnwd.net/d1/pdc08/WMV-HQ/TL51.wmv) (which includes the Managed Contract Tools) on this one. The level of static analysis this tool manages to pull off is amazing. This will be part of Visual Studio 2010 but you can get a preview version for VS 2008 today.

CLR Futures: The CLR just keeps getting better. In 4.0 they will be introducing side by side execution (both 2.0 and 4.0 CLR’s in the same process space), importing of external COM objects (No more PIA’s), a wrapping tool for windows.h and SAL (generates p/invoke wrappers), Big Integer support, Tuples (like python and ruby), better tail recursion, and better garbage collection (can collect gen 2 while gen 0,1 are collecting).

F#: The introduction course to F# was the very last session of the conference and it was packed! Usually by day 4 you can pretty much pick and choose. Not this time. I’m not sure but it probably overflowed to a second room. Great talk. Really gets me excited about learning a functional language.

The PDC was a blast. The improvements to the CLR, new tooling and scalable cloud platform make it a great time to be developer.
