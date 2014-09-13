FreeSnap 1.5 Beta 3 Released
2008-11-22T20:23:19
![](/content/images/blog/FreeSnap1.5Beta_117EF/beta.jpg) You can read about the new features in my earlier blog posts.

  * [FreeSnap 1.5 Beta 1](/blog/post/2008/11/11/freesnap-1-5-beta)
  * [FreeSnap 1.5 Beta 2](/blog/post/2008/11/17/freesnap-1-5-beta-2)

This release adds a few more refinements to task switcher algorithm. It also adds a cycle backward key sequence. Win+TAB will cycle to the next application in the same manner as Alt-TAB but without all the fanfare. Instead of little pictures of applications, it just activates the next application. One reader suggested that I add a Win+Shift+TAB sequence to cycle backwards, which I’ve done. This is a nice feature to have when you over shoot past the intended application.

I find the three-key sequence a bit awkward so I’ve also added Win+` (directly above the TAB key on US keyboards). I find this much more natural. The Win+` sequence will likely map to something else on non-US keyboards so your mileage may vary.

There are several other keyboard sequences that map only to US keyboards including Win+/ and Win+?. It has been suggested that I add settings to reconfigure the keyboard to user preferences. That’s actually a harder problem than it sounds since FreeSnap intercepts keyboard messages at a very low level. It would mean having to expose and explain virtual keyboard codes which may be more than most people want to get into. I would appreciate feedback on this issue and what you would consider to be a good solution.

The 32 and 64 bit betas are available on the [downloads](/downloads) page.
