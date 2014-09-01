Favorite C# Idioms
2009-01-02T14:53:00
There’s a great post on Stackoverflow about [hidden features in C#](http://stackoverflow.com/questions/9033?sort=votes&page=1#sort-top). I prefer to think of these as idioms rather than hidden features since most are actually documented. Here are my favorites.

> From [CLR via C#](http://www.amazon.com/CLR-via-Second-Pro-Developer/dp/0735621632):
> 
> When normalizing strings, it is highly recommended that you use ToUpperInvariant instead of ToLowerInvariant because Microsoft has optimized the code for performing uppercase comparisons.

> From [Rick Strahl](http://www.west-wind.com/weblog/posts/236298.aspx):
> 
> You can chain the ?? operator so that you can do a bunch of null comparisons.
>     
>     string result = value1 ?? value2 ?? value3 ?? String.Empty;

> I think one of the most under-appreciated and lesser-known features of C# (3.5) are Expression Trees, especially when combined with Generics and Lambdas. This is an approach to API creation that newer libraries like NInject and Moq are using.
> 
> For example, let's say that I want to register a method with an API and that API needs to get the method name
> 
> Given this class:
>     
>     public class MyClass  
>     {  
>          public void SomeMethod() { /* Do Something */ }  
>     }  
>     
> 
> Before, it was very common to see developers do this with strings and types (or something else largely string-based):
>     
>     RegisterMethod(typeof(MyClass), "SomeMethod");  
>     
> 
> Well, that sucks because of the lack of strong-typing. What if I rename "SomeMethod"? Now, in 3.5 however, I can do this in a strongly-typed fashion:
>     
>     RegisterMethod(cl => cl.SomeMethod());  
>     
> 
> In which the RegisterMethod class uses Expression> like this:
>     
>     void RegisterMethod(Expression> action) where T : class  
>     {  
>         var expression = (action.Body as MethodCallExpression);  
>       
>         if (expression != null)  
>         {  
>             // TODO: Register method  
>             Console.WriteLine(expression.Method.Name);  
>         }  
>     }  
>     
> 
> This is one big reason that I'm in love with Lambdas and Expression Trees right now.

> My favorite trick is using the null coalesce operator and parens to automagically instantiate collections for me.
>     
>     private IList _foo;  
>       
>     public IList ListOfFoo { get { return _foo ?? (_foo = new List()); } }

> If you're trying to use brackets inside a String.Format expression...
>     
>     int foo = 3;  
>     string bar = "blind mice";  
>     String.Format("{{i am in brackets!}} {0} {1}", foo, bar);  
>     //outputs "{i am in brackets!} 3 blind mice"

> InternalsVisibleTo attribute is one that is not that well known, but can come in increadibly handy in certain circumstances. It basically allows another assembly to be able to access "internal" elements of the defining assembly

> If you want to exit your program without calling any finally blocks or finalizers use
>     
>     Environment.FailFast()

> I just found out about this one today -- and I've been working with C# for 5 years!
> 
> It's the namespace alias qualifier:
>     
>     extern alias YourAliasHere  
>     
> 
> You can use it to load multiple versions of the same type. This can be useful in maintenance or upgrade scenarios where you have an updated version of your type that won't work in some old code, but you need to upgrade it to the new version. [Slap on a namespace alias qualifier](http://blogs.msdn.com/abhinaba/archive/2005/11/30/498278.aspx), and the compiler will let you have both types in your code.

> There's also the ThreadStaticAttribute to make a static field unique per thread, so you can have strongly typed thread-local storage.

> More of a runtime feature, but I recently learned that there are two garbage collectors. The workstation gc and the server gc. Workstation is the default, but server is much faster on multicore machines.
>     
>       
>          
>             
>          
>       
>     
> 
> Be careful. The server gc requires more memory.

> The [Environment.UserInteractive](http://msdn.microsoft.com/en-us/library/system.environment.userinteractive.aspx) property.
> 
> The UserInteractive property reports false for a Windows process or a service like IIS that runs without a user interface. If this property is false, do not display modal dialogs or message boxes because there is no graphical user interface for the user to interact with.

> My favourite is the
>     
>     global::  
>     
> 
> keyword to escape namespace hell with some of our 3rd party code providers...

> One feature that I only learned about here on StackOverflow was the ability to set an attribute on the return parameter.
>     
>     [AttributeUsage( AttributeTargets.ReturnValue )]  
>     public class CuriosityAttribute:Attribute  
>     {  
>     }  
>       
>     public class Bar  
>     {  
>             [return: Curiosity]  
>             public Bar ReturnANewBar()  
>             {  
>                     return new Bar();  
>             }  
>     }  
>     
> 
> This was trully a hidden feature for me :-)

> The generic event handler:
>     
>     public event EventHandler MyEvent;  
>     
> 
> This way you don't have to declare your own delegates all the time.

There are many others in the post. What are your favorites?
