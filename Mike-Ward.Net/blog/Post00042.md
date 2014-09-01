When Understanding means Rewriting
2006-09-21T12:54:57
Jeff Atwood has an excellent blog entry this morning called "[When Understanding means Rewriting](http://www.codinghorror.com/blog/archives/000684.html)". In it he explains how many programmer's rewrite code in order to understand how it works. The premise is that the previous code is complex enough in nature that it's faster to rework the problem than to work with the current solution.

In the past, I tended to want to rewrite old code, but now I've developed different strategies to try and understand and work with old code.

1. Read the documentation. Sounds obvious but if the programmer is worth is salt he'll have left a few bread crumbs for you to follow.

2. Step through the code a few times. This doesn't take long and let's you visit lots of code is a short time.

3. Change something. Once I get a general idea of what is happening, change something trivial and see how it behaves. 

4. Refactor something. One of the best tools I've found for doing this is FxCop. Since I'm about the only person I know who uses this tool (just kidding) it's for sure I'm going to find things right away. Again, this gets you engaged with the code and gives you some feel about the quality of what you're dealing with. If you're changes are breaking things like unit tests, it's a good bet you're in for major work. On the other hand, if you're changes are non-breraking, then perhaps you have something good here. Other targets for refactoring are classes with more than 300 lines of code or methods with more than 100 lines of code.

5. Take the attitude that you're here to improve, not remove. It takes a long time to really understand the problem and even longer to code it. Assuming you're working with competent people, give them the benefit of the doubt that they did their homework.

6. Finally, talk to programmer (if you have this luxury) and find out what issues they encountered. Often this leads insight into why things are structured the way they are.
