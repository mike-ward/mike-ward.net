IDF 2006: Terascale Processing Brings 80 Cores to your Desktop
2006-09-28T15:02:19
PC Perspective is running an interesting [article](http://www.pcper.com/article.php?aid=302">terascale) on the future multicore processing. The article starts off:

> If you’ve never heard the term “[terascale](http://www.pcper.com/article.php?aid=302)” before reading this article, you aren’t alone. Before attending this Fall’s IDF, I hadn’t been introduced to the term either. But after hearing and reading about it and doing a lot of research into the technology, I can tell you that we are going to walk away from this technology overview excited about the future of computing. 

The future of computing is multicore and we're not talking dual or quads here. Intel is estimating desktops will be running 80 core systems by 2011 with close to 32 billion transistors. And the architecture will be radically different as well.

> You should not think of this merely as SMP on a single die; these are vastly different cores with new platform requirements and software requirements. How so? How about memory bandwidth needs of 1.2 Terabytes/s compared to the 12 GB/s in current SMP systems? And what about latency levels of only 20 cycles for a terascale core compared to 400 cycles on a modern SMP system? Now you see the scales we are talking in here and the significance (and hurdles) these designs introduce.

Wow, now that's a lot of power. But as any super hero well knows, with great power comes great responsibility. There are some significant challenges for software developers in harnessing this power.

> There is no doubt that programming for a terascale processor like this is going to be difficult – we already see this in the move from single core processors, to dual core and now quad core. A programmer needs to be able to both IDENTIFY parallelism in a problem as well as MANAGE that parallelism so that data integrity is not lost during the application. 

At the PDC 2005 in Los Angles, Microsoft introduced some ideas for dealing with this large scalability. In some cases, future .Net frameworks will automatically detect parallelism in your program by unrolling loops or other repetitive processing. In other cases, there will be new language constructs to help the compiler better utilize multiple processors. It's clear that software developers are going to need new tools to manage these new architectures. I can't wait...
