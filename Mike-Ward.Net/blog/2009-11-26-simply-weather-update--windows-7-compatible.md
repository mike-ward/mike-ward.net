Simply Weather Update – Windows 7 Compatible
2009-11-26T15:08:57
Fixed an odd layout bug on Windows 7. 

I also changed the “Custom Weather Page” to use the default browser instead of always opening in Internet Explorer. It opened in Internet Explorer because sidebar gadgets are essentially web pages running in a special “gadget version” of Internet Explorer. Calling the standard JavaScript, “window.open” function opens the new window in the current browser, thus IE. I had to sneak in a bit of ActiveX scripting to open the page in the default browser. Mission accomplished.

Someone also asked about a transparent background. I experimented with this but the results were just plain ugly. The font-smoothing (Clear Type) renders nearly unreadable text on transparent backgrounds.

Speaking of backgrounds, if you’re artistically inclined (I’m definitely not), why not take a few minutes and design some new backgrounds. If you peek in the gadget folder (email me if you need help finding it), you’ll see they’re nothing more than PNG images.

Available on the [downloads page](/downloads).
