Tweetz, JavaScript, jQuery and Discovery
2010-02-01T01:25:12
I’ve been busily working on the next release of tweetz™ these last couple of weeks and have mostly ignored my blogging duties as a result. Codemash 2009 was a real wake call for me in that I realized that I needed to update my skills in a number of areas. If you take your craft seriously, you realize that getting “comfortable” is the kiss of death, skills wise. Especially in the profession of programming.

So, after seeing all the cool JavaScript/jQuery (and other stuff like Ruby) at Codemash, I arrived back, cracked open the tweetz code and set about to employ the new techniques I learned. I was immediately hit with a sad and disquieting realization however. The code really “sucked”.

It’s my own fault perhaps but consider that tweetz started out as just a few changes to a gadget called Twadget. It was written way back in 2006 using jQuery 1.1. Much has changed since then.

The code suffered from a classic case of lack of separation of concerns. You see this a lot in Web programming. Here’s this fat old DOM sitting out there just begging to have data and handlers hung on it like a Christmas tree. I followed suit with my “incremental” improvements and well, the result wasn’t pretty.

If I’ve learned anything about programming over the years, it’s that I suck at it. That sounds harsh but consider that we all “suck” at programming to varying degrees. As Jeff Atwood has said many times in his blog, “The goal is to suck a little less as time goes on”.

So I started over with tweetz. It wasn’t really worth “saving” in it’s current state and I had the opportunity to “do it right” this time around. I’ve also learned a tremendous amount about JavaScript and jQuery over the last few months. It’s really been an eye-opening trip of discovery. JavaScript is more powerful and robust than I realized.

Tweetz™ 2.0 has a real data model now. The controller and views are separated (mostly), and the generated markup is and much leaner and therefore faster. Many of the odd quirks and behaviors have disappeared in this new version. The code still sucks. It just sucks a whole lot less.

I keep thinking I’ll release the new version any day, but then realize there are many features the new version doesn’t support yet. As much as I’ve maligned the old tweetz, it was feature rich and did it’s job well for the most part. The new one is better so far and like any craftsman, I’m enjoying the process as much as the result. It may be a few days or a few weeks before tweetz 2.0 debuts, but trust me, it’s coming.
