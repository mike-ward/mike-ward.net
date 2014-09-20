Bloget™ Alpha 5
2007-02-28T23:31:29
Despite a trip to Slovakia this month I managed to squeak out the next alpha of [Bloget](/bloget). Alpha 5 introduces two new features, timezone support and [BlogML](http://blogml.com). Timezones are well, timezones. You can set the timezone of your blog to reflect your location. Sounds simple I know but it requires a bit more coding than you might think. Makes me wish I had .NET 3.0 which does support timezone conversions.

[![](http://az667460.vo.msecnd.net/cdn/images/blog/WindowsLiveWriter/BlogetAlpha5_FF7C/rulerock_thumb%5B1%5D.jpg)](http://az667460.vo.msecnd.net/cdn/images/blog/WindowsLiveWriter/BlogetAlpha5_FF7C/rulerock%5B3%5D.jpg) BlogML is an XML format for storing the entire content of a blog. You can use BlogML as a way to archive the contents of blogs or to act as a standard format for transferring content from one blog to another - this could include migrating a blog from one blogging engine to another. Check it out in the admin screen under import/export.

Of course there are the usual cleanups and usability changes one expects at this phase of a project. One thing that's not going to change is the data schemas. That's right, I'm throwing the gauntlet down and locking in the data schemes. I may add to them but no breaking changes at this point. If you have been hesitating because you were afraid future versions won't work with your current data, fear not. Besides, with BlogML support you can always export and reimport but that won't be necessary.

As for Alpha 6, I'm planning on adding three new controls: BlogRoll, Recent Comments and Archives by Month. If things go real well, I'll add black lists as well but I'm traveling to Florida this month so time's limited (isn't it always?).

So there you have it, another release of my soon to be world famous blog engine (yeah, right). As always, send feedback. - Mike
