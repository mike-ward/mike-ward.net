Adding Information to Exceptions
2007-04-23T23:58:53
This is an excerpt of a post from Marc Brooks about [Exception Handling in .NET](http://musingmarc.blogspot.com/2005/09/exception-handling-in-net-some-general.html).

> If you do have contextual information you can add to an exception, **DO SO**. Use the Exception.Data [collection](http://msdn2.microsoft.com/en-us/library/2wyfbc48%28en-us,vs.80%29.aspx), that's what it is there for! You can add the values of interesting parameters to you methods. This is especially useful in the context of a database layer or other low-level library. You can squirrel-away the SQL and all the parameters. Only do this if you think that these details will be useful for post-mortem diagnosis. If the information you log is transitory it will NOT help tracking down errors from logs. This is (mostly) good:
>     
>     catch (Exception ex)
>     {
>        ex.Data.Add("SQL", command.Text);
>        ex.Data.Add("key", myKey);
>        throw;
>     }
> 
> If you add things to the Exception.Data collection, make sure that you don't conflict with what is already there as this is a HashTable. I use the catching-class's name to scope the values. This is much better than above:
>     
>     catch (Exception ex)
>     {
>        ex.Data.Add(String.Format("{0}.{1}.SQL",
>            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName,
>            System.Reflection.MethodBase.GetCurrentMethod().Name), command.Text);
>     
>        throw;
>     }
> 
> [Exception Handling in .NET](http://musingmarc.blogspot.com/2005/09/exception-handling-in-net-some-general.html)

There's the usual recommendations that most seasoned .NET programmers know and understand. However, there are two items here I haven't seen before. The first is the use of the Exception.Data collection. It may be obvious to everyone else but heck if I ever noticed it. And the next tip is icing on the cake. I've often wanted to include the method type and name in my error messages and felt a little dirty just typing the names in. After all, why can't the compiler fill it in for me? Well, the next best thing is demonstrated here using System.Reflection.MethodBase.GetCurrentMethod(). Thanks Marc.
