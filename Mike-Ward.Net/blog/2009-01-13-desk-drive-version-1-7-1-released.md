Desk Drive Version 1.7.1 Released
2009-01-13T00:45:09
Version 1.7 of [Desk Drive](/deskdrive) introduced a bug. When enough files were added or deleted from a removable device (like a USB stick), Desk Drive would add another shortcut to the desktop. This bug was related to the 1.7 feature showing total/free space for removable devices. Version 1.7.1 fixes this (hopefully).

I’ve also had reports that the “Locus effect” is not always in the correct location. When monitors are positioned so that the primary monitor is negatively offset from the secondary monitor (monitor 1 is right of monitor 2), the Locus effect can appear on the wrong screen. Turns out that there is no good way to detect this and even if I did, I likely would not get it right for all circumstances. So, I’ve added a MonitorOffset setting to DeskDrive.exe.config that allows you to add an offset to the X and Y positions to compensate.

That’s all for now. Enjoy.
