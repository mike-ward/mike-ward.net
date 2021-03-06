ReSharper Gem
2011-09-05T12:56:34
If you program in C#, odds are you use [Microsoft’s Visual Studio](http://www.microsoft.com/visualstudio/en-us) development environment. VS 2010 has it’s stability and performance issues, which I’ve been quite vocal about, but it still is one of the best IDE's for .NET development going. Developing without [Intellisense](http://en.wikipedia.org/wiki/Intellisense) is hard to imagine.

[ReSharper](http://www.jetbrains.com/resharper/) is a plugin from [JetBrains](http://www.jetbrains.com/index.html) that amps up the usability of VS 2010 another notch (at some cost to performance, listening JetBrains?). It’s one of those tools that even after using it for years, you’re still discovering features that enhance you’re workflow. 

My colleague [Brian Genisio](http://houseofbilz.com/) turned me on to a quick way to move code blocks and/or entire functions with the following ReSharper keyboard shortcut.
    
      
    Place the cursor on a function in your code.  
    Press Ctrl+Shift+Alt+Up Arrow

  


The indicated function moves above the previous function or declaration. (Down arrow works as you would expect).

Admittedly, the keyboard shortcut is a bit of a contortion, but after a few times it becomes second nature.

When you want to rearrange more than a few functions though, this can become tiresome. Instead, press Ctrl+Alt+F. This brings up the "File Structure" dialog.

![2011-09-05 08h33_16](/cdn/images/blog/Resharper-Gems_6EFD/2011-09-05-08h33_16.png)

Most ReSharper users are probably familiar with the above dialog. It's a quick way to grok the file structure and find functions you don't quite remember the name.

**But here's the gem. You can rearrange the items in the file by clicking on a method in the File Structure dialog and dragging it to a new location (in the dialog).** Multiple select is also supported for moving several functions at once.

It works just like you would expect and even maintains the correct spacing (formatting) between functions. Anal retentive types (like myself) rejoice! 
