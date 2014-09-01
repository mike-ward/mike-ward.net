Inserting Quotes in MSBuild Tasks
2007-04-29T16:35:16
![](http://www.myotherdrive.com/public/blueonion/Blog/vspro.png) I've finally got around to cracking open the [MSBuild documentation](http://msdn2.microsoft.com/en-us/library/0k6kkbsd.aspx) and writing a few custom scripts. If you program in Visual Studio 2005, you're using MSBuild and like most things programming, its worth some time to understand the tool. It's fairly straight-forward to learn and I won't repeat the already very good [tutorials](http://msdn.microsoft.com/msdnmag/issues/06/06/InsideMSBuild/default.aspx) available all over the Internet. I did run into one problem that proved irritatingly hard to resolve. Consider the following:

`<Exec Command="c:\program files\some folder\myprogram.exe" />`

When MSBuild tries to execute this task, you get an error saying it couldn't execute "**c:\program**". Obviously the spaces in the command are causing a problem here. The question is, how does one quote the command inside an XML file? My first thought was that since it is XML, I should be able to use the standard [XML character entities](http://en.wikipedia.org/wiki/List_of_XML_and_HTML_character_entity_references).

`<Exec Command="&quot;c:\program files\some folder\myprogram.exe&quot" />`

Update (12/11/07): There's a typo in my example as someone kindly pointed out. It actually does work to use &quot; character entity:  


`<Exec Command="&quot;c:\program files\some folder\myprogram.exe&quot;" />`

<strike>Nice idea, but it doesn't work. Same error, same problem.</strike> After spending what seemed like half-of-day scouring forums, I finally found a clue. MSBuild recognizes URL encoding. After looking up what the ASCII value for a quote (its 22), I tried the following:

`<Exec Command="%22c:\program files\some folder\myprogram.exe%22" />`

Ugly as sin, but it works. Surely there has to be a better way to handle white-space in MSBuild projects?

Technorati tags: [MSBuild](http://technorati.com/tags/MSBuild), [Visual Studio 2005](http://technorati.com/tags/Visual%20Studio%202005), [.NET](http://technorati.com/tags/.NET)
