VSColorOutput - Visual Studio Output Coloring Extension
2011-12-28T16:57:55
VSColorOutput provides color highlighting for the build and debug output windows in Visual Studio. I wrote it to highlight trace output in debug output window. I found it made it easier to find trace messages I was interested in during debug sessions.

It also highlights build errors and warnings. Here's an example:

![vso](/cdn/images/blog/VSColorOutputA-Visual-Studio-Extension_9C56/vso.png)

**Installation**

[Download](http://vscoloroutput.codeplex.com/releases/view/79354) and open the **VsColorOutput.visx** file. VSColorOutput supports Visual Studio 2010/2011. You can also find it in the [Visual Studio Extension Gallery](http://visualstudiogallery.msdn.microsoft.com/f4d9c2b5-d6d7-4543-a7a5-2d7ebabc2496). To uninstall, go the _Tools|Extensions_ page, find VSColorOutput in the _Installed Extensions_ and click uninstall. Registry entries are not removed so later installations will reuse these settings.

**How does it work?**

VSColorOutput hooks into the the classifier chain of Visual Studio. This allows VSColorOutput to monitor every line sent to the output window. A list of classifiers, consisting of regular expressions and classifications is checked. The first matching expression determines the classification the line of text. If no patterns match, then line is classified as **BuildText**.

From here, Visual Studio does the heavy lifting of mapping the classification to a color. Colors are stored in the registry.

**Configuration**

Out of the box, VSColorOutput will match most error and warning messages. It uses regular expressions to match lines to output classifier categories. You access these settings from the _Tools|Options|VSColorOutput_ options page.

![op1](/cdn/images/blog/VSColorOutputA-Visual-Studio-Extension_9C56/op1.png)

![op2](/cdn/images/blog/VSColorOutputA-Visual-Studio-Extension_9C56/op2.png)

The regular expressions use the .NET form ([http://msdn.microsoft.com/en-us/library/hs600312.aspx](http://msdn.microsoft.com/en-us/library/hs600312.aspx)), which varies slightly from those used by Ruby, JavaScript, Python, etc.

To restore the default patterns, simply remove all the patterns.

At run-time, VSColorOutput will walk this list in order, testing the line of text against the regular expression. If it matches, the line is given the classification associated with the pattern. No additional patterns are tested for the given line. Therefore, the order of the classifiers is significant.

There are nine VSColors classifications. They are:

  * Build Text 
  * Build Header 
  * Log Information 
  * Log Warning 
  * Log Error 
  * Log Custom1 
  * Log Custom2 
  * Log Custom3 
  * Log Custom4 

The names reflected their intended use but are entirely arbitrary.

To change the color of the classification go to the _Options|Environment|Fonts and Colors_ dialog. The colors are grouped near the bottom starting with VSColorOutput:

![fc](/cdn/images/blog/VSColorOutputA-Visual-Studio-Extension_9C56/fc.png)

The is project is open source and available at [http://vscoloroutput.codeplex.com](http://vscoloroutput.codeplex.com). I welcome contributions and suggestions as always. If you have an issue, please try to capture a log, or stack trace, or send me a sample project that reproduces the issue.
