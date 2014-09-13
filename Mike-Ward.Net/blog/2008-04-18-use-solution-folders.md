Use Solution Folders
2008-04-18T13:06:55
![](http://www.hanselman.com/blog/content/binary/WindowsLiveWriter/TheWeeklySourceCode24ExtensibilityEditio_13756/image_3.png) In reading [Scott Hanselman's blog](http://feeds.feedburner.com/~r/ScottHanselman/~3/272745966/TheWeeklySourceCode24ExtensibilityEditionPlugInsProvidersAttributesAddInsAndModulesInNET.aspx) this morning, I ran across an interesting tid bit.

> ASIDE: Not enough people use "Solution Folders" in Visual Studio. Seriously, folks, just right-click and "Add | New Solution Folder," start dragging things around and bask in the tidiness

He's referring to how "tidy" the [xUnit.NET](http://www.codeplex.com/xunit) code he's reviewing here. It's a great point however. I'm currently working on a project that has 71 project files in it. Way too many in mind opinion. And the reason I suspect is that most developers don't know (or don't care) that they can organize their solutions and projects into folders.

Projects often get used organize code but it's an expensive proposition. It takes much longer to load solutions with lots of projects. Take the same number of files and put them in one project and Visual Studio loads the solution much faster.

Multiple projects means multiple project settings. If you have ever maintained a large solution you know what I mean. It's easier to change 5 projects than 71.

Load times are slower. Believe it or not, people still value programs that start quickly. Every time you add a project to a solution, you're building another module (likely a .DLL). Not only do these modules take longer to build, they take longer to load due to disk access, fix-ups, path probing, private page loading, etc.

And then there's the "Myth of Modularity" argument I often get from developers when I recommend then reduce the number of projects. "It won't be as modular if I use fewer projects" is a common protest. So let's see, module A requires these 70 other modules to work. Furthermore, the modules themselves are dependent on each such that if I make any code changes I have to ship a significant number of modules to support the update. Yeah, right.

Project (and solution) folders are a cheap, easy and low overhead way to organize your projects. Think about it.
