Desk Drive Version 1.1 Released
2008-05-27T22:05:52
[![deskdrive](/content/images/blog/DeskDriveVersion1.1Released_E33C/deskdrive_thumb.png)](/content/images/blog/DeskDriveVersion1.1Released_E33C/deskdrive.png) There were a couple of positive articles on some popular web sites about Desk Drive posted last week. As a result, I've received a ton of email requesting features, fixes, etc. Version 1.1 adds one new feature and removes another.

The new feature let's you exclude any drive by name. Several people reported issues with having to enable "Fixed" drives to see their removable drives. This sounds like a driver issue to me but of course that doesn't fix the problem. Excluding drives is useful in its own right and may help with unusual issues.

I removed the interval timer setting. It defaults to 4 seconds.

I've also released the source code so you can modify it to your hearts content. If you do something really cool, let me know so I can incorporate it into the code.

I've received a number of annoying emails suggesting that the high memory usage was something I should correct as if some how I made a mistake. .NET programs have a higher baseline for memory usage meaning their minimum size is larger than say C++ programs. There's an old saying that you don't get something for nothing and that's the case here. Localization, code security and better system integration come at a cost. It's apparent that some reviewers have no real knowledge of why the .NET platform is just flat out better and instead focus on something they think they understand like memory usage. Frankly, I prefer programs written in .NET because I know they have a much lower chance of doing damage to my computer or have exploitable security holes.

One guy has gone so far as to write a his own version of Desk Drive because he doesn't like to install .NET applications on his computer. Why someone would care about such a thing is beyond my understanding. Wonder if he has Java installed? What ever... In the interest of full disclosure you can read more about it [here](http://www.freewaregenius.com/2008/05/27/desktop-media-get-automatic-desktop-shortcuts-when-you-plug-in-your-usb-drive-or-other-media/). 

There's also this persistent request to hide the tray icon I don't quite understand. Once the icon is hidden, there would be no UI to get to the settings dialog. I don't know, call me silly, but I think that might make for a usability issue. Besides, Windows already allows you to selectively hide tray icons. Looks like I'll have to post a tip about that one later.
