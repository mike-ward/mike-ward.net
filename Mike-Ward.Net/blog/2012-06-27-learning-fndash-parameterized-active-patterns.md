Learning F#&ndash; Parameterized Active Patterns
2012-06-27T23:14:44
I've been teaching myself F#, Microsoft's functional language for .NET and blogging about it from time to time. Here are links to my previous articles.

[Learning F#](/blog/post/2012/05/20/learning-f)   
[Learning F# – Deployment](/blog/post/2012/05/22/learning-f-ndash-deployment)   
[Learning F# – Assembly Level Attributes](/blog/post/2012/05/26/learning-fndashassembly-level-attributes)

The code for the project is at [http://tweetc.codeplex.com/](http://tweetc.codeplex.com/)

Sticking with the theme of, "Here's a real program that does something real and useful", I'd like to talk about parsing command lines. There is of course no "one" way to parse a command line. A lot of it depends on how you intend to use the command line. In my twitter command-line program **tweetc**, I want to do the following where tc.exe is the program:
    
    tc Hi Mom!         : post an update to your time line  
    tc                 : get new status updates  
    tc –h50            : get the last 50 homeline statuses  
    tc -m20            : get the last 20 mentions  
    tc -green          : set the text color to green  
    tc -ldarkgreen     : set the secondary text color to dark green  
    tc -reset          : erase all remembered settings  
    tc -s paris hilton : tweets about something uninteresting  
    tc -h              : show help  
    

  


As simple as this looks it takes a surprising amount of C# code to get it right. I usually end up with a big switch statement. If I'm feeling a bit more clever I'll use a dictionary but there are edge cases and things wind up getting more verbose than I like.

Here's my (partial) solution in F# (I've left out the color handling to keep the code short). It's refreshingly brief and even if you don't fully understand the language the gist of what the code is trying to do is apparent.
    
    let (|Option|_|) option input =  
        let m = Regex.Match(input, option + "([0-9]+)")  
        if m.Success then Some(int m.Groups.[1].Value)  
        elif input = option then Some(20)  
        else None   
       
    let processArgs (args:string[]) =  
        if args.Length = 0   
        then getCredentials(); home 20  
        else match args.[0] with  
             | "-?"  
             | "-help"           -> showHelp()  
             | "-reset"          -> clearAllSettings()  
             | Option "-h" count -> getCredentials(); home count     
             | Option "-m" count -> getCredentials(); mentions count   
             | Option "-d" count -> getCredentials(); messages count   
             | Option "-s" count -> search count (String.Join(" ", Array.sub args 1 (args.Length - 1)))  
             | _                 -> getCredentials(); updateHome (String.Join(" ", args)) |> ignore  
    

  


Even with the odd F# syntax it reads well. There are a few functions in here like getCredentials(), home, mentions, etc. that I've not shown but being a twitter client it's not too hard to imagine what they do.

The interesting bit here is the "(|Option|_)" function. In F# it's referred to as a Parameterized [Active Pattern](http://msdn.microsoft.com/en-us/library/dd233248.aspx). The preceding link describes Active Patterns and their variants in detail but the short version is that an active pattern is way of dividing input data into named partitions. The link has some nice examples.

Partial Active Patterns match only part of the input. These patterns don't produce a value but instead return an option type. Option types are characterized by the Some|None keywords. I'll talk about option types another time. In brief it's a handy way of saying, "I got nothing or I have a value" (null is something F# avoids). 

Parameterized Active Patterns are Partial Active Patterns that can take additional parameters (Active Patterns always take at least one argument). The extra parameters precede the actual input parameter which I find unintuitive. The F# syntax has it's oddities.

As you can see from the code, Parameterized Active Patterns allow me to pass in a parameter indicating the program option I'm interested in ("h", "m", etc.). Without the parameter I would have had to resort to specifying an Active Pattern per program option.

If all this makes your head ache just a bit consider that this is one of the hardest concepts I've come across in F#. I'm not going to pretend this was easy to write. It wasn't. Nor can I explain adequately how this works in the space of a blog article. Download the code, fire-up the debugger and step through it. I think once you internalize it you'll find lots of uses for it. One thing I do know is the next time I use Parameterized Active Patterns I'll be referring to this bit of code to "refresh" my understanding.

On a side note, being new at F#, I wonder if this is a good approach to the problem. Perhaps there's a better way to express this? Let me know. I'm no expert and appreciate the feedback. 
