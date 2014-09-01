Zip folders? But why?
2007-07-20T13:40:28
`<rant>  
It drives me crazy that Windows XP treats compressed files as folders. I get that this is "a feature", but I’m developing a nervous twitch from accidently clicking on zip files in the tree view pane in explorer. I fully _never _want to interact with a .zip file this way.  
</rant>`

Here’s how you can disable the thing, so that zip files are just files once again.

What you need to do is unregister the ZipFldr.dll, which is the explorer extension that implements the Zip Files as Folders feature:

open a command prompt [ Start / Run / c md.exe ]  
type the following commands:

`pushd %WINDIR%\system32  
regsvr32 /u zipfldr.dll  
exit `
