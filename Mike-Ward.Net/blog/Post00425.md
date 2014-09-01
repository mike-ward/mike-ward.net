I’ve seen the light and it’s Bazaar
2009-01-19T23:18:09
![Bazaar](http://bazaar-vcs.org/htdocs/bazaarNew/css/logo.png)One of the coolest presentations I attended at [CodeMash 2009](http://codemash.org/) was a session on [Bazaar](http://bazaar-vcs.org/), an open source, distributed version control system. It’s hard to imagine getting excited about something as mundane as version control but in this case it’s really worth a look. Promise.

Bazaar’s tag line is that it “Just Works”, and by golly it does. I’ve used a bunch of VCS systems over the years and before using Bazaar, I was convinced that [Subversion](http://subversion.tigris.org/) was it. It only took about 10 minutes to change my mind.

OK, assuming you know what a VCS is here’s what I like about Bazaar.

  * It’s just a program. No server required. No plugin’s needed or databases or other stuff required. 
  * No predefined workflow. Use it alone, with others, on servers or not. 
  * It’s simple. Even an old codger like myself can grok it. 
  * It’s powerful. It does pretty much anything the big guys do and with much less fuss. 
  * It’s very lightweight . Hell, if it were any lighter it might float off my lap top. 
  * It has understandable documentation that explains but does not overwhelm. 

The one thing that may put many people off is that it is primarily a command line interface. There are some projects out there to do a tortoise like integration with Windows Explorer and what appears to be a defunct Visual Studio 2005 plug-in but frankly, you are not going to need them. In fact, I’ve found I prefer the command line interface for Bazaar. I think this works in part because Bazaar doesn’t have a checkout, check-in mechanism like many other VCS systems. Just work on your files and when you want to save a revision, just type “bzr commit”. It finds all the changed files and updates the archive.

Here’s another scenario where Bazaar really shines. You’re working on code at work and want to finish up the work at home. You bring your work laptop home and finish up the work, all the while committing changes to the archive. Do you see where I’m going with this? Just because you’re not connected to a central archive doesn’t mean you can’t enjoy the benefits and safety of versioning your code at home. In fact, when you get back to work the next day, you can merge your changes back into a shared archive and it will include all the revisions and history from your work at home. It’s like you were there, only you weren’t.

Perhaps the biggest stumbling point for me was I kept trying to understand what “distributed” meant in the context of Bazaar. I kept imagining some Bittorent type thing where archives were winging all over the net. In reality, all it really means is that anyone can have a repository of the code. The use of a central repository in Bazaar is not required. A central repository is merely a convention that a team can decide to use or not. Bazaar has additional tools and even something called a “smart server” for such scenarios but they’re mostly just “helpers” to facilitate sharing.

You’ll notice I have not mentioned the usual VCS features like merging, branching and tagging. They’re included of course. Check out “[What makes Bazaar ROCK?](http://bazaar-vcs.org/BzrFeatures)” for more information. I could go on, but really, seeing is believing.
