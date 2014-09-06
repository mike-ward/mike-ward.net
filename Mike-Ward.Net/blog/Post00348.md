Changing drive icons in Windows Explorer
2008-08-21T19:53:24
A few of you have emailed asking if it is possible to change the icon that [Desk Drive](/deskdrive) puts on the desktop. Well, the answer is yes with qualifications. There is no option in Desk Drive to change drive icons but it can be done a couple of ways from the Windows itself.

For USB flash drives, create an autorun.inf file in Notepad and add the following:
    
    [autorun]
    label=USB Flash Drive bla bla bla...
    icon=usbstick.ico

Copy both the autorun.inf and icon file to your flash drive. Next time you plug the flash drive in it will show up with the new label and icon. It will also appear the same way in Windows Explorer. Here's an example from my desktop.

![Example of custom icon on the desktop](/content/images/blog/ChangingDriveIcons_DD36/usbstick.png)   
Example USB icon

Another way to modify default drive icons/labels is to edit the registry (in Windows XP at least). There's a great article at [markwilson.it](http://www.markwilson.co.uk/blog/2006/02/changing-drive-icons-in-windows.htm) that thoroughly explains how to do this.

Does anyone know if Windows Vista supports the same registry settings as XP for drive icons/labels? I did a quick check on my Vista machine and didn't find the required registry entries.
