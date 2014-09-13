Remote Desktop Tips
2006-10-26T16:33:58
We recently switched from using Timbuktu to Remote Desktop to access servers where I work. In general, I like Remote Desktop better than Timbuktu. You get your own desktop and session distinct from other logons and you get to use your own logon credentials which is just one less account/password to have to remember.  
  
There are a couple of issues. First if you want to logo to the host server console, there is no obvious way. A bit of investigation and we found the following:  
  
**mstsc.exe /console**  
  
When you logon using this command, you get the console desktop.  
  
The other issue is that the basic Windows 2003 Server is only licensed for two simultaneous logon's. We've found that users tend to close the window instead of logging out. To combat this, there are some handy group policies.  
  
Run gpedit.msc on the host server and navigate to the Local Computer Policy | Computer Configuration | Administrative Templates | Windows Components | Terminal Services | Sessions policies.  
  
You'll find polices to automatically logout disconnected or idle sessions.  

