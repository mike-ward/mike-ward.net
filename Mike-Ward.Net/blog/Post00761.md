Learning F#&ndash;Assembly Level Attributes
2012-05-26T15:59:55
I'm learning F# and for the most part, it's been fun and productive. However, I find myself getting tripped up on seeming simple but necessary constructs required for writing well behaved .NET programs. One of those constructs are the assembly level attributes used to indicate version and build numbers, copyrights and product descriptions.

In C# these attributes are typically placed in a file called AssemblyInfo.cs. When creating a new project in Visual Studio this file is automatically produced. Here's an example in C#
    
    using System;  
    using System.Reflection;  
    using System.Runtime.InteropServices;  
      
    [assembly: AssemblyTitle("tweetc")]  
    [assembly: AssemblyDescription("Command line twitter client")]  
    [assembly: AssemblyConfiguration("")]  
    [assembly: AssemblyCompany("Blue Onion Software")]  
    [assembly: AssemblyProduct("tweetc")]  
    [assembly: AssemblyCopyright("Copyright ©  2010 Blue Onion Software")]  
    [assembly: AssemblyTrademark("tweetc")]  
    [assembly: AssemblyCulture("")]  
    [assembly: CLSCompliant(true)]  
    [assembly: ComVisible(false)]  
    [assembly: Guid("f1a4d403-4b2e-4e54-94b5-39b3d3f8f229")]  
    [assembly: AssemblyVersion("1.0.*")]  
    [assembly: AssemblyFileVersion("1.0.*")]  
    

  


When you create a new F# project in Visual Studio, you don't get this file. This is one of about a dozen things I found with F# that just adds friction where it isn't needed. It's these friction points in part that made me avoid F# for years. That may sound like a lame excuse but the truth of the matter is I usually will only stick with a "new something" for a short while (< 30 minutes) before I abandon it. In other words, you have about 30 minutes to "hook" me with your "shiny new technology" before I move on to something else. Call it a personality flaw, but that's the way I'm wired. Fortunately (for me), F# is so compelling that I'm able to push aside my impatience this time.

So after about an hour of searching, I found the answer on page 289 of Chris Smith's, "Programming F#". Here's what it looks like in F#.
    
    module tweetc.AssemblyInfo  
      
    open System  
    open System.Reflection;  
    open System.Runtime.InteropServices;  
       
    [<assembly: AssemblyTitle("tweetc")>]  
    [<assembly: AssemblyDescription("Command line twitter client")>]  
    [<assembly: AssemblyCompany("Blue Onion Software")>]  
    [<assembly: AssemblyProduct("tweetc")>]  
    [<assembly: AssemblyCopyright("Copyright © 2012 Blue Onion Software")>]  
    [<assembly: AssemblyTrademark("tweetc")>]  
    [<assembly: Guid("7EF053BC-EA3C-4F49-8944-52FD0F2F7614")>]  
    [<assembly: ComVisible(false)>]  
    [<assembly: CLSCompliant(false)>]  
    [<assembly: AssemblyVersion("1.0.0.0")>]  
    [<assembly: AssemblyFileVersion("1.0.0.0")>]  
       
    do()

  


Most of the time, placing an attribute above a class or method is sufficient. However, in the case of assembly level attributes, the target of the attribute is ambiguous. Adding the attribute target "assembly" resolves the issue. Not much different from C# in that respect.

What's not so obvious is the **do()** binding at the bottom of the file. Again from Chris Smith's book.

> In F#, assembly level attributes must be placed inside of a module on a do binding

So why the mysterious **do()** binding? The **do()** binding is used execute code that doesn't define a function or value. It's your way of telling the compiler to "Shut the f*** up and just do it". **do()** bindings have other uses I'll discuss in a future article.
