Tip for Finding Memory Leaks in C#
2006-10-03T16:27:03
There are many tools and techniques for finding memory leaks in managed code. Some involve sophisticated tools like the [CLR Profiler](http://www.c-sharpcorner.com/Code/2004/Aug/CLRProfiler.asp). While I have found such techniques useful for bugs in the "wild", I have found a simpler technique that smokes out these errors during development. It's really two tips.

Use [FxCop](http://www.gotdotnet.com/team/FxCop/) or the code analysis tool in VS 2005 Pro. It tells you so much about your code and finds objects that you forgot to dispose. Use it every day.

Put break points on your finalizers. If you write classes of any complexity, you likely have implemented the [dispose pattern](http://msdn2.microsoft.com/en-us/library/fs2xkftw.aspx) for these objects. If not, you likely should. Add asserts to the finalizers or use break points and run your program as normal. Did you hit any finalizers (you see this mostly during program exit)? If so, these are good candidates for further examination. It's a good bet that if your finalizers are executing then your objects are living longer than they should.

Other interesting articles about Dispose Patterns

[A Closer Look at the Dispose Pattern](http://haacked.com/archive/2005/11/18/ACloserLookAtDisposePattern.aspx)   
[Dispose, Finalization and Resource Management](http://www.bluebytesoftware.com/blog/PermaLink.aspx?guid=88e62cdf-5919-4ac7-bc33-20c06ae539ae)   
[The Dispose Pattern, Finalizers and Debug.Assert()](http://www.agileprogrammer.com/oneagilecoder/archive/2005/03/24/3065.aspx)
