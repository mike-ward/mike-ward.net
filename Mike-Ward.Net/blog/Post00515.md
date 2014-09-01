Setting File Permissions in Wix 3.0
2009-10-07T23:47:08
I’m new to Wix and to Windows Installers in general so some of this is likely wrong or obvious. Still, I couldn’t find much information on how to do set file permissions for a particular user account so I thought I’d share.

I needed my installer to set the folder permissions for the App_Data folder in an ASP.NET site. Typically, you need to give the “Network Services” account write permissions to this folder. I scoured the Internet for a solution and posted a question on [Stack Overflow](http://stackoverflow.com/questions/1527939/wix-set-appdata-folder-permission-to-modify-for-networkservice) before coming up with my own solution.
    
    <CustomAction Id="PermissionAppData" Directory="TARGETDIR"   
      ExeCommand="&quot;[SystemFolder]cacls.exe&quot;   
      &quot;[INSTALLDIR]\App_Data&quot;  
      /T /E /G &quot;NT AUTHORITY\Network Service:C&quot;" Return="check" />

  


Add this custom action to the install sequence table and you’re golden.

There’s a **util:PermissionEx** custom action in Wix 3 but it seems to only work for “well known” accounts (like Administrators). Maybe there’s a better way but darn if I could come up with it. Feedback appreciated.
