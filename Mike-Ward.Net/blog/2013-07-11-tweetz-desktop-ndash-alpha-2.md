Tweetz Desktop &ndash; Alpha 2
2013-07-11T22:56:29
[![image](http://az667460.vo.msecnd.net/cdn/images/blog/Windows-Live-Writer/TweetzAlpha-2_10285/image_thumb.png)](http://az667460.vo.msecnd.net/cdn/images/blog/Windows-Live-Writer/TweetzAlpha-2_10285/image_2.png)Just when you thought it was safe, another tweetz alpha release appears. Be afraid :)

For those of you just tuning in, tweetz desktop is the desktop version of tweetz the gadget. It’s written in WPF and has additional fuctionality.

In this release: (0.4.0)

Images can be added to your status updates. Twitter only allows .PNG, .JPG and non animated GIF’s. You can drag and drop from the file explorer onto the application to add an image or use the file open dialog. In some instances you can drag images from the browser. Unfortunately, the browsers are not consistent in how the handle drag operations. YMMV

You can click on a tweet to select it. The background color changes to indicate it’s selected. This is handy for marking a tweet (the last one read for instance)

Selection is also useful with keyboard shortcuts. The Up and Down Arrow Keys move the selected tweet. The J and K keys work the same. R replies to the selected tweet. T to retweet/unretweet. F to favorite/unfavorite. I’ll add more in another release.

Images appear inline with the associated tweet. It’s surprisingly nice to see the images inline. There’s option to turn it off if you don’t roll that way.

The layout has changed. Twitter requires that certain elements be present. In particular, both the screen name and user name must be present and the timestamp must be a permalink to the tweet. Their platform, their rules.

The Search panel removes retweets from the search timeline. There’s also a keyboard shortcut to go directly to search. It’s the forward slash key (/). 

The rest of time has been wasted struggling with the oddities of WPF. In particular handling keyboard focus is nightmarish. 

Download: [tweetz5.exe](/cdn/downloads/tweetz5.exe)
