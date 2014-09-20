Simply Weather Gadget Update
2012-08-19T13:47:04
I've been getting more than a few emails as of late that my Simply Weather gadget has stopped working. It also stopped working on one of my systems last week as well. It was obvious what was failing but I never could figure out why. The call was valid, the data going over the wire looked valid, but all I would get in return from Google is a 403 error (Simply Weather uses Google's weather API). Something has changed, either on Microsoft's side or Google's. Such is the life of a programmer, working today, broken tomorrow.

To fix the gadget, I replaced the data access routines. Of course I couldn't just replace the data access routines. Once I started poking around in the code I had to update the rendering routines. And the data model really needed updating. And of course a view model would be really handy. And … in the end, I rewrote the gadget. Such is the life of a programmer, working today, refactoring tomorrow. :)

The new gadget is beta at this point and can be [downloaded here](https://skydrive.live.com/redir?resid=4BF90C12F2590F59!405&authkey=!AAvd2N2RugunwSU).

I've made a couple of changes.

You can haz colors! No preset backgrounds means you can choose any color now. I've added a color selection dialog. Click the current-weather-condition to display the color selection dialog.

![color1](http://az667460.vo.msecnd.net/cdn/images/blog/Simply-Weather-Gadget-Update_7A07/color1.png)

Clicking on either text box will bring up a color selector.

![color2](http://az667460.vo.msecnd.net/cdn/images/blog/Simply-Weather-Gadget-Update_7A07/color2.png)

As you move the color selector around you'll see the gadget change colors. I've found I have a particular talent for creating some truly ugly color combinations. Hopefully you'll do better.

I've also upgraded the tool tips on the gadget. Hover over the weather icons and to see the forecast weather condition. The old gadget also had this feature but the gadget had to have the focus for it to work. The new gadget works with or without having the focus.

![tooltip](http://az667460.vo.msecnd.net/cdn/images/blog/Simply-Weather-Gadget-Update_7A07/tooltip.png)

The layout has been fixed to handle triple digit temperatures without cutting off part of the last digit.

Try it out, send me your bugs and in about a week or we'll make it official.
