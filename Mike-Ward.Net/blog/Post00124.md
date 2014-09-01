Using Keywords as Identifiers in C#
2007-02-12T15:57:18
There are times when keywords and identifiers collide when coding. This is particularly true in code generators but sometimes the keyword really describes the purpose of the identifier (like **default** or **ref** for instance). You can come up with clever naming schemes but there is a simpler way. In C#, you can just prefix the identifier with an @ symbol.

> Keywords are predefined reserved identifiers that have special meanings to the compiler. They cannot be used as identifiers in your program unless they include @ as a prefix. For example, @if is a legal identifier but if is not because it is a keyword. [The C# Language](http://download.microsoft.com/download/9/8/f/98fdf0c7-2bbd-40d3-9fd1-5a4159fa8044/csharp%202.0%20specification_sept_2005.doc)
