JSLint for Visual Studio 2010
2010-06-23T22:42:44
> [`JSLint`](http://www.JSLint.com) is a JavaScript program that looks for problems in JavaScript programs. It is a code quality tool.
> 
> JavaScript is a sloppy language, but inside it there is an elegant, better language. `JSLint` helps you to program in that better language and to avoid most of the slop. 

I use this tool whenever I write JavaScript. It finds all sorts problems, many of which can be difficult to spot at runtime. My only gripe is that I have to copy the code from my Visual Studio editor to the Web site and then pick through errors.

There’s a plug-in for VS 2008 that integrates well with Visual Studio, but does not work with Visual Studio 2010. The plug-in model has changed in Visual Studio 2010.

I started writing a Visual Studio 2010 plug-in but soon lost interest. The Visual Studio object model is damn near inscrutable in my opinion.

Next I looked at writing a Resharper plug-in. Again, too hard. The documentation is weak and the object model is complex.

I finally settled on writing an external tool. Press Ctrl+K, Ctrl+J and the output window will display a report about your code.
    
    Microsoft (R) Windows Script Host Version 5.8  
    Copyright (C) Microsoft Corporation. All rights reserved.  
       
    (10,22): Missing semicolon.  
        var naughtyMike = 0  
       
    Globals:         String  
                     $  
                     Date  
                     jQuery  
                     isNaN  
                     Math  
                     APP  
                     System  
                     document  
                     ActiveXObject  
                     OAuth  
                     setTimeout  
                     clearTimeout  
                     clearInterval  
                     setInterval  
                     window  
                       
    Implied globals: badMike (5)  
                       
    Unused:          naughtyMike (9)

  


Not as cool as a plug-in but good enough for my purposes.

**How it Works**

JSLint is itself written in JavaScript. You can get the source at [http://jslint.com/fulljslint.js](http://jslint.com/fulljslint.js). There’s also a nice little WScript wrapper for invoking and displaying the results at [http://jslint.com/wsh.js](http://jslint.com/wsh.js).

I hacked these two files together into a file called JSlint.js. With this file in hand, I can now invoke the JSLint program from the command line as follows:
    
    cscript c:\users\mike\bin\jslint.js < %1

“cscript.exe” is windows console mode script runner that ships with windows. It can run JavaScript and VBScript programs.

Here’s the JavaScript code that invokes the JSLint program and streams the input and output.
    
    (function () {  
        var i, e, data;  
        if (!JSLINT(WScript.StdIn.ReadAll(), {passfail: false})) {  
          for (i = 0; i < JSLINT.errors.length; i += 1)  
          {  
            e = JSLINT.errors[i];  
            WScript.StdErr.WriteLine('(' + e.line + ',' + e.character + '): ' + e.reason);  
            WScript.StdErr.WriteLine('    ' + (e.evidence || '').replace(/^\s*(\S*(\s+\S+)*)\s*$/, "$1"));  
            WScript.StdErr.WriteLine();  
          }  
        }  
        var show = function (title, array) {  
          WScript.StdErr.WriteLine();  
          WScript.StdErr.Write(title);  
          if (array === undefined) { return; }  
          for (i = 0 ; i < array.length; i += 1) {  
            e = array[i];  
            WScript.StdErr.WriteLine( (e.line) ? (e.name + ' (' + e.line + ')') : e);  
            WScript.StdErr.Write('                 ');  
          }  
        };  
        data = JSLINT.data();  
        show("Globals:         ", data.globals);  
        show("Implied globals: ", data.implieds);  
        show("Unused:          ", data.unused);  
        WScript.Quit(1);  
    }());

  


This is a modified version of [http://jslint.com/wsh.js](http://jslint.com/wsh.js) that pretty prints the JSLint results.

**Integration with Visual Studio**

To integrate this tool with Visual Studio you’ll need an additional file called JSLint.bat.
    
    cscript c:\users\mike\bin\jslint.js < %1

You’ll have to modify the path to the jslint.js file.

Next, open “External Tools…” dialog in Visual Studio and add a new tool called JSLint. The specific command path will be different on your machine.

![2010-06-23 18h22_43](http://az667460.vo.msecnd.net/cdn/images/blog/JSLintforVisualStudio2010_FCBB/2010062318h22_43.png)

Finally, record a macro to run your new JSLint external tool command. Save it and assign it to a key combo (I like Ctrl+K, Ctrl+J).

Available on the [downloads page](/downloads).
