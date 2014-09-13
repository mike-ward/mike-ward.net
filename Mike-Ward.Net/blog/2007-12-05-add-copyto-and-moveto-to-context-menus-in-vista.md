Add CopyTo and MoveTo to context menus in Vista
2007-12-05T00:04:21
Here's a fun little productivity tip. Add CopyTo and MoveTo to your right-click context menu in windows explorer. Saves you having to open a second explorer window or navigate away from your current location. Simply open notepad and copy the following lines into it. Watch out for the word wrap. It should total three lines.

`   
Windows Registry Editor Version 5.00   
[HKEY_CLASSES_ROOT\AllFilesystemObjects\shellex\ContextMenuHandlers\{C2FBB630-2971-11D1-A18C-00C04FD75D13}]   
[HKEY_CLASSES_ROOT\AllFilesystemObjects\shellex\ContextMenuHandlers\{C2FBB631-2971-11D1-A18C-00C04FD75D13}]`

Name it copyto.reg ([or download this file](/downloads/copyto.reg)). Double click copyto.reg to add the registry settings. 

![](http://s3.amazonaws.com/BlueOnionSoftware/Blog/copyto.png)
