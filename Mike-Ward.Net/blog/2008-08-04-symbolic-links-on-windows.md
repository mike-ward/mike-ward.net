Symbolic Links On Windows
2008-08-04T13:37:47
Symbolic links to directories are really useful.

> Windows 2000 and higher supports directory symbolic links, where a directory serves as a symbolic link to another directory on the computer. For example, if the directory D:\SYMLINK specified C:\WINNT\SYSTEM32 as its target, then an application accessing D:\SYMLINK\DRIVERS would in reality be accessing C:\WINNT\SYSTEM32\DRIVERS. Directory symbolic links are known as NTFS junctions in Windows. Unfortunately, Windows comes with no tools for creating junctions—you have to purchase the Win2K Resource Kit, which comes with the linkd program for creating junctions. I therefore decided to write my own junction-creating tool: _Junction_. _Junction_ not only allows you to create NTFS junctions, it allows you to see if files or directories are actually reparse points. Reparse points are the mechanism on which NTFS junctions are based, and they are used by Windows' Remote Storage Service (RSS), as well as volume mount points. 
> 
> [http://technet.microsoft.com/en-us/sysinternals/bb896768.aspx](http://technet.microsoft.com/en-us/sysinternals/bb896768.aspx)

I use junction to set my /Build directory to reside on another physical disk, while still appearing to be from the root of the snapshot view I'm using. Cool!
