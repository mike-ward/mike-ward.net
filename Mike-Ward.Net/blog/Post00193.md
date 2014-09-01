.NET Tip of the Day
2007-09-01T15:22:45
Just tripped across a nicely put together tip site for .NET called (what else?) [.Net Tip of the Day](http://http://dotnettipoftheday.org/tips/). The tips are really good and the format is no-nonsense, get straight to the point. ASP topics are also included. I discovered several attributes that control debug output that I didn't know about. Here's an example.

> Use DebuggerDisplay attribute for a better debugger experience
> 
> Apply DebuggerDisplay attribute to a class or member to determine how it is displayed in the debugger variable windows. For example, the following C# code causes "Count = 4" to be displayed in debugger:
>     
>     [DebuggerDisplay("Count = {count}")]  
>     class MyHashtable  
>     {      
>         public int count = 4;  
>     }

Definitely put this one on your blog roll.  

