Desk Drive 1.6.3 Released
2008-09-16T14:50:15
Desk Drive 1.6.3 includes changes that should allow it to run on x64 for systems natively. One of the cool benefits of writing in .Net is that if you stick to the rules, your compiled code can run in both 32 and 64 bit modes natively. This is due to the “Just in Time” (JIT) compilation feature of .Net.

For the most part, this is automatic. Where you get into trouble is usually in the Interop portions. Many programs don’t require Interop. But if your program interacts with the shell or other “Native services” of Windows, you’ll more than likely have to do some form of platform invoke or COM Interop.

This is where FxCop or the Code Analysis feature of Visual Studio can really be your friend. “FxCop/Code Analysis” analyzes your code and finds problems that the compiler misses. In particular, it is very good at finding 32/64 bit incompatibilities in your code. 

Saving and restoring icon positions in Desk Drive requires sharing memory with the Windows shell. This is a risky area because it requires dealing with raw representations of data which are different in 32 and 64 bit representations. .Net can handle it, provided you code it correctly. And that’s where FxCop/Code Analysis is valuable. It spots these inconsistencies and often times tells you how to correct the problem.

So the moral of the story is to use FxCop/Code Analysis as part of your build cycle. I recommend that you not only eliminate all the errors, but all the warnings as well. It’s a bit daunting when you get started, but if want to write solid code, it’s a necessity. I think of it as a another pair of eyes reviewing the code.

I don’t have a 64 bit operating system to test on so I’m relying on your feedback as to my success or not.

Also in this release, I’ve added logging. Logs are written to the Windows event log service. If something doesn’t work in Desk Drive, check the event log and with some luck there some diagnostic information there.

I’ve also tweaked some of the language translations in this release. Enjoy, and don’t forget to donate.
