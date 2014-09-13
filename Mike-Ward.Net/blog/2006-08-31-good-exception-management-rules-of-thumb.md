Good Exception Management Rules of Thumb
2006-08-31T14:51:24
Another great article from Scott Hanselman's blog. I've been involved in more "discussions" on exception management than I care to remember. It surprises me how many developers see them as evil, even to the point of banning them from code. Exceptions are not evil, they're a tool like anything else and it takes some understanding to wield them properly. Scott has some nice "[Rules of Thumb](http://www.hanselman.com/blog/GoodExceptionManagementRulesOfThumb.aspx)" here that I totally agree with.

  * Exceptions are exceptional and should be treated as such. If something exceptional, unusual, or generally "not supposed to ordinarily happen" then an exception is a reasonable thing to do. 
    * You shouldn't throw exceptions for things that happen all the time. Then they'd be "ordinaries". 

[more...](http://www.hanselman.com/blog/GoodExceptionManagementRulesOfThumb.aspx)
