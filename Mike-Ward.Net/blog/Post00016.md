Script# - Developing JavaScript in C#
2006-08-23T00:53:15
Just picked this up on [DotNetKicks.com](http://dognetkicks.com/). This is great idea if it really works. I've written a lot of javascript and frankly it's tedious work. Having a real language and tools would be a boon to client side development

> Script# brings the C# development experience (programming and tooling) to the JavaScript/Ajax world. 
> 
> The Script# compiler is a C# compiler that generates JavaScript as its output instead of IL. A key goal of the compiler to produce readable JavaScript (as if you had authored it by hand), and would be comfortable deploying into real apps. Hence the translation works from C# source directly into JavaScript without an intermediate IL layer. The compiler can also produce equivalent, but much more compact script for use in release mode deployment. The compiler does not introduce any additional levels of abstraction, thereby allowing you full control of what your application does. In essense the best of script with the best of C#! 
> 
> The Script# compiler can optionally be used with the Script# Framework that provides a more productive application development platform for larger, and more complex applications. 
> 
> **A Better Scripting Approach**
> 
> The fundamental goal was to improve the state of the art in scripting. This goes way beyond the usual things that come to mind at first thought: compile-time checking, and intellisense or statement completion. I do think these are super-useful, and would be valuable in and of themselves. As we worked on Atlas we were also thinking of a great tools experience, and we explored different approaches and technologies for achieving this. Script# is a prototype of one such exploration. It attempts to address some programming environment requirements: 

  * A clean language with the natural constructs. Today with script, you can go a long ways in simulating OOP (classes, interfaces, inheritance etc.), but the simulations are thrown at the face of the developer. Various C# constructs such as properties, events, and syntax for defining inheritance go a long way in making the code readable. Similarly modifier keywords like public vs. protected vs. internal, sealed vs. virtual etc. help define a better object model. All of this can be brought into the scripting world. 
  * Easier refactoring and exploration. Script development could benefit immensely from the refactoring, and class browsing support already present in the IDE and in tools such as .NET Reflector. Both lend themselves to having a more manageable code base over time. 
  * Ability to generate documentation. Again doc-comments from C# and the existing infrastructure could be leveraged here. 
  * Ability to customize the script code easily. For example, I'll show debug vs. release and minimization below. The same idea could apply to building a version of the script that had more error checking or logging built in when you do need to run diagnostics. The approach could also be used to include instrumentation for the purposes of profiling, measuring code coverage, etc. Another interesting aspect of this project is that it will be able to generate script catering to multiple script profiles such as the current Javascript language, as well as Javascript 2 when it appears. 

> **A Rich Scripting Framework**
> 
> The scripting framework accompanying the Script# framework can be used both from C# or directly from JavaScript. The framework is designed to work on top of JavaScript and technologies prevalent across browsers and platforms. It is very much in early stages at this point, and consists of various layers: 

  * An OOP-based type system for better encapsulation of data and logic, that supports applications and components written in C#. 
  * A base class library that both extends built-in script objects as well as adds new classes that allows one to carry forward a reasonable part of their managed code programming experience. 
  * Higher level abstractions such as networking, UI controls, etc. enabling focus on application-level logic rather than at raw nuts and bolts of scripting 

[More from the website](http://projects.nikhilk.net/Projects/ScriptSharp.aspx)
