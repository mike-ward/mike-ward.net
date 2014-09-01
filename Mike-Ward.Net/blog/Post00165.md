GhostDoc helps with Commenting your Code
2007-05-13T19:56:11
![](http://s3.amazonaws.com/BlueOnionSoftware/Blog/GhostDoc.png)<summary>  
[GhostDoc](http://www.roland-weigelt.de/ghostdoc/) is a free add-in for Visual Studio that automatically  
generates XML documentation comments for C#. Either by using   
existing documentation inherited from base classes or   
implemented interfaces, or by deducing comments from name and  
type of e.g. methods, properties or parameters.  
</summary>

.NET languages like C# and VB.NET have a nifty little feature called XML comments that enable the developer to add comments about properties and methods in the code. Later, the compiler can gather these comments along with other information and generate an XML file. The XML file in turn can be used by tools like NDoc and [Sandcastle](http://blogs.msdn.com/sandcastle/) to build professional grade documentation for code. Once in place, the whole process can be automated to create documenting with every build. This is all well and good but you still have to write the darn comments. Here's GhostDoc comes in. It can give you a springboard to get you going by using existing documentation from base classes and deducing comments from names, types, methods, etc. It won't write extensive prose but it does give you enough to get you over the hump of writing comments. It comes with a set of default rules that you can add to and customize to your own tastes.

![](http://s3.amazonaws.com/BlueOnionSoftware/Blog/ghostdocconfig.png)

But how can a tool with virtually no understanding of the English language generate often pretty accurate documentation? Well, the basic idea is pretty simple: GhostDoc assumes that your code follows the Microsoft's Design Guidelines for Class Library Developers: 

  * you are using PascalCasing or camelCasing to write identifier names consisting of multiple words 
  * your method names usually start with a verb 
  * you do not use abbreviations in identifier names 

If you follow these rules (e.g. write "ClearCache()" instead of "Clrcch()") and choose more or less self-documenting identifier names, there's a good chance for GhostDoc to split the identifier names into words, tweak and/or shuffle them a little and produce a comment that, while not perfect, gives you a head start on the way to good documentation. 

The text generation is performed using customizable rules and templates, and in addition to the built-in rules it is possible to define new custom rules that extend or replace existing rules (by giving the custom rules a higher priority and/or disabling built-in rules) 

As mentioned above, GhostDoc does not really understand English identifier names, nevertheless it tries to apply certain mechanisms to increase the quality of the generated comments: 

  * Handling of verbs (GhostDoc assumes the first word of a method name to be a verb): Add -> Adds , Do -> Does, Specify -> Specifies 
  * "Of the" reordering (using trigger words like "width", "height", "name", etc.): ColumnWidth -> Width of the column 
  * Combined with special handling of specific adjectives: MaximumColumnWidth -> "Maximum width of the column" instead of "Width of the maximum column" 
  * Automatic detection of acronyms consisting of consonants (Html -> HTML), combined with a list-based approach for other acronyms (Gui -> GUI) 
  * Use of a list of words where that should not be headed by a "the" (AddItem -> Adds the item, but BuildFromScratch -> Builds from scratch) 

As the quality of the comment depends heavily on the quality of the identifier name, using GhostDoc for a longer period of time actually teaches writing consistent and self-documenting identifier names, which is definitely a nice side-effect.

[Introduction to GhostDoc](http://dotnetslackers.com/articles/vs_addin/Introduction_ghostdoc.aspx)[ ](http://dotnetslackers.com/articles/vs_addin/Introduction_ghostdoc.aspx)

Technorati tags: [C#](http://technorati.com/tags/C#), [.NET](http://technorati.com/tags/.NET), [XML](http://technorati.com/tags/XML), [Visual Studio 2005](http://technorati.com/tags/Visual%20Studio%202005), [Sandcastle](http://technorati.com/tags/Sandcastle)
