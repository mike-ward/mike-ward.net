Installing VS 2005 Extensions after Installing .NET Framework 3.0 SP1 or Later
2008-02-21T00:49:27
If you try to install the Visual Studio 2005 Extensions required for WPF development after installing the .Net Framework 3.0 SP1 or later, you will get an error saying that the .Net FW 3.0 is not installed.

To get around this, either back down to the original .Net FW 3.0 via uninstall/reinstall, or add the following registry key:

[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{15095BF3-A3D7-4DDF-B193-3A496881E003}]   
"DisplayName"="Microsoft .NET Framework 3.0"

[http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=2550726&SiteID;=1](http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=2550726&SiteID=1)
