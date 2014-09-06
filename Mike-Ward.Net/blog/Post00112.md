Call Stack Tips
2007-01-18T23:23:29
![Visual Studio 2005 Banner](/content/images/blog/WindowsLiveWriter/CallStackTips_CC77/right_bnr_vstudio%5B5%5D.gif) Just in case you've never tried, it - the next time you're looking at a call stack while stopped at a break point in [Visual Studio 2005](http://msdn2.microsoft.com/en-us/vstudio/default.aspx), try_ right clicking_ in the call stack window and investigating some of the context menu options.

Here's some that stand out.

Discovering the first one gave me a some good insight into why .NET control events were being fired without my, or my users, instigation. It is especially useful in combo with [Reflector. .NET](http://www.aisto.com/roeder/dotnet/).

**Show External Code  
**Changes those single line, obtuse call stack phrases "[External Code]" into illuminating exposés of internal .NET assembly method call stacks, complete with cracked message and parameter info. 

**Include Calls To / From Other Threads  
**Can provide deeper insight into how your breakpoint was reached in a multithreading scenario. 

**The Load Symbols Menu  
**This section of the menu provides runtime access to the debug symbol configuration. This is specifically useful in mixed mode apps. You should download the **[Debugging Tools For Windows](http://www.microsoft.com/whdc/devtools/debugging/default.mspx)** from Microsoft and follow the installation instructions.

Basically, you want to configure VS to download and cache the .PDB files which provide the symbols for the OS DLLs you're using - this capability provides much more accurate and useful stack traces and debug step execution.

You should generally update to the most current version of the 32 bit Debugging Tools for Windows - the current version is **6.6.7.5**, July 18, 2006.

**VS Config  
**In VS, go to Tools / Options / Debugging / Symbols and add the following to the "Symbol file (.pdb) locations" (note, this is also accessible from the Call Stack window context menu) 

[ _http://msdl.microsoft.com/download/symbols_ ](http://msdl.microsoft.com/download/symbols)

Specify a local directory to store the cached .pdb files. My symbol cache consumes approximately 260 MB, just for references. You may also want to checkmark the option "Load symbols using the update settings when this dialog is closed".

After debugging my app a few times, I returned to this dialog and disabled the [x] next to the symbol path in the "Symbol file (.pdb) locations" list - the constant checking for newer symbols slows things down a bit, and after a few common sessions you've probably downloaded the symbols for the system DLLs you most commonly interact with anyway. YMMV, depending on how scattered your debugging needs are.
