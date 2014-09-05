Day of the Virus
2006-10-31T00:11:31
I received a call on Thursday from some friends who have a small medical practice. Apparently their computers were acting a little strange. I had helped setup their system 2 years earlier. When I arrived at the office, the situation was not good. The file server would not boot and other systems were barely usable.

I quickly isolated the computers from each other and the network and went to work. All systems were running the latest commercial version of AVG Anti-virus. Not good enough as it turned out. On one system, AVG detected viruses but could not isolate them. No sooner would I clean up the files and they would reinfect. I was not happy. AVG just would not block the reinfection.

Out of desperation, I loaded trial version of [NOD32](http://www.eset.com). It found the same viruses but was able to isolate them and keep the system from reinfecting. Score one for NOD32. Once things settled down I found that the restoration files the Windows keeps were also infected. This left me no choice but to do a repair install. It worked. I bought NOD32.

The viruses ripped through the office net and infected all systems. On the file server it took out the Master Boot Record which is why it would not boot. The other systems suffered from other issues. It took 9 hours to clean up 6 systems.

The good news is no data was lost. They backup regularly using a system I installed. Perhaps the biggest problem was that these systems were running as Admin. The reason was that the HP printers they were using would not print in Limited accounts. This was my fault. I had tried on several occasions to get these printers to work on Limited accounts. I curse HP for the crap driver software they ship with their systems. With renewed motivation and a few hours effort I finally figured out that if I set the printer ports to use IP addresses instead of the usual device name I could print in Limited accounts. Needless to say, all systems are now running in "Limited" accounts.

In the final analysis they were lucky mostly due good practices. Had we not had Admin privileges enabled the viruses might have been defeated. I should have been more persistent on the Limited account issue. Good backups (even though we didn't need them), regular updates and one very good software package made the difference.

As for AVG, I'm sorely disappointed. It let something in and once there, allowed it to spread. That's a fatal mistake in my book and I'm done with them. My new best friend is NOD32. If you believe the [benchmarks and reports](http://www.eset.com/products/compare-NOD32-vs-competition.php), it's the best thing going. It saved my bacon.

Having experienced the destructive force of computer viruses first hand has really hardened my attitude. This was a small office and it cost them almost a full day of business. I don't know about their revenue but I suspect it cost them thousands of dollars. Random attacks like this are really malicious and evil. If not terrorism, it comes darn close. 
