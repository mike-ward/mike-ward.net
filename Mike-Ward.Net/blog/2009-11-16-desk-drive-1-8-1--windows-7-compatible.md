Desk Drive 1.8.1 – Windows 7 Compatible
2009-11-16T02:07:31
Version 1.8 introduced Windows 7 compatibility and version 1.8.1 tweaks it a little more. I’ve found a few minor issues that likely no one but myself would notice. But like any author, I know my program for all its faults and not its strengths. So if you notice the changes between 1.8 and 1.8.1, good for you and remember there’s therapy available for people like us.

While I had to make some minor changes to Desk Drive to make it Windows 7 compatible, I’ve also gained a feature without any work what so ever. If you set Desk Drive to open Windows Explorer automatically, it also closes the open window when the USB drive is removed. That’s something I’ve wanted for a while and it just seems to work on Windows 7 (on my box at least).

A couple of usage notes on “Remembered icon positions”. First off, it won’t work if your desktop is set to “Auto arrange”. Makes sense when you think about it but it’s not obvious when you first encounter the problem. Also, very occasionally, I get a report about remembered icon positions not working on multi-monitor setups. I’ve never been able to run down the issue since it doesn’t happen here. However, there is a work around.

In the **DeskDrive.exe.config** file there is a setting called Monitor Offset. It’s an X,Y pair. If icons are appearing on the wrong screen you can usually just set the X offset to the width of the primary monitor. Sometimes it’s the negative width. The multi-monitor API is suppose to handle these details but it doesn’t seem to always work. Probably a bug on my part but I’ve never been able to corner it.

I’ve also received a few emails asking what the heck the positional effect is. Here’s a video showing the effect.

[http://www.youtube.com/watch?v=AU1LNJkIng8](http://www.youtube.com/watch?v=AU1LNJkIng8)

Finally, it’s been a long time since I’ve received a language translation from anyone. Desk Drive currently supports 20 languages. It’s super easy to translate Desk Drive. Just open **DeskDrive.exe.xml** and edit the default settings. There is only about a 20 strings to translate. Restart the program and make sure the translation is to your liking. Then send me the file and I’ll add it to the stock language settings. 

Available on the [downloads page](/downloads).
