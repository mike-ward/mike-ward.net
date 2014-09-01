Tiny Trick for ViewState Backed Properties
2006-09-11T23:14:48
Phil Haacked's blog has an excellent article on using [the null coalescing operator with value types](http://haacked.com/archive/2006/08/07/TinyTrickForViewStateBackedProperties.aspx). I ran into to this very issue just the other night and like Phil quickly gave up. To summarize the trick.
    
    bool result = (bool)ViewState["WillSucceed"] ?? false;

won't compile but just change the casting order to (note the extra parenthesis):
    
    bool result = (bool)(ViewState["WillSucceed"] ?? false);

and your in. Excellent tip!
