Learning F#
2012-05-20T18:46:27
The old saying in programming is "adapt or die". While that's not entirely true, I find the programmers I respect and consult with the most are the ones who are always learning something new. And these days, there's a lot of "new" out there to learn.

A few years ago, I decided to take a head-long dive into JavaScript. What a found was a beautiful language (with some serious warts) that taught me a great deal about functional programming. More importantly, it made me a better programmer. My "Bread and Butter"' language is C# but my style of using it has shifted more towards functional paradigms. A few years ago, passing functions around as arguments seemed weird. Now I can't seem to get along without them.

I'm firmly rooted in the Microsoft camp of development. One can argue whether that's a good choice or not, but it's served me well of the last 30 years programming (damn, I'm getting old). JavaScript opened my eyes to functional programming and while I still have trouble with some of the concepts (monads anyone), I've determined [F#](http://msdn.microsoft.com/en-us/vstudio/hh388569.aspx) is the next logical step in growing my skill set.

I've found the only good way to learn a language is to read about it intensely, write a non-trivial program in it and then read about it intensely again. I call it the "Rinse and Repeat Approach". A few years ago I wrote a command line twitter client in C# called tweetc. It was a decent little console application as these things go. I wrote it before twitter switched over to using OAuth for authentication so it no longer works. My plan is to rewrite it in F#.

I won't be using any .NET client libraries for OAuth or for deserializing twitter results. Pure F# all the way. I'm actually a good way into this project already with a working home-time-line. So what do I think about F# so far?

**F# is a difficult, dense and at times strange language.**

That sounds a little negative but I really don't mean it that way. It's more of a warning that it requires extra effort to learn this language.

Seems like every book I pick says F# is a simple, concise language. Heck, look at the tag line for Chris Smith's excellent "Programming F#".

> "A Comprehensive Guide for Writing Simple Code to Solve Complex Problems"

Hey, sounds good, sign me up. 

I've found nothing simple about this language (again not being negative). It's really quite different than anything I've encountered before. It makes my head hurt, which is not necessarily a bad thing. At the same time, I'm finding myself attracted to it's oddity and sparseness. One thing is isn't is C#. I suspect my C# biases get in the way of learning F#, but then again, I think sometimes the authors went a bit to far out of there way to not be C#

A few other observations:

  * Tooling support is not as good as in C#. ReSharper has become almost as necessary as Intellisense for me. 
  * The ordering of source files matters. F# is a bit like Pascal in that there are no forward references (or I haven't learned about them yet) 
  * There's really no good reference program I've found that shows how to write a typical Windows program complete with storing application settings and parsing command line arguments. I'm hoping that when I'm done with **tweetc**, it will serve as an example of writing a real, non-trivial program in F# 
  * Three resources I've found indispensible: 
    * [**Programming** **F#** - O'Reilly Media](http://shop.oreilly.com/product/9780596153656.do)" 
    * [http://www.tryfsharp.org/](http://www.tryfsharp.org/)
    * [What does this C# code look like in F#? (part one: expressions and statements) « Inside F#](https://lorgonblog.wordpress.com/2008/11/28/what-does-this-c-code-look-like-in-f-part-one-expressions-and-statements/)
  * I really don't see the advantage of not using parenthesis for calling functions. In fact, it's a bit inconsistent in that if you have no parameters or parameters with type annotations then parenthesis are required. 
  * There are two forms of syntaxes. A light-weight and standard form. You're allowed to mix them. Why? 
  * Casting is done with operators ( :>, :?> ) 
  * Some of the cooler aspects like Units of Measure, Records and async don't play well with other .NET languages. 

I could go on but I think my point is made. It's not a C like language and it seems to almost go out of its way to not be so in places where it really doesn't need to. It will be interesting to see how I feel about the language a few months from now.
