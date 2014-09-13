How to Check C# Parameters
2007-11-28T00:56:04
I just downloaded a sample from [The Code Project](http://www.thecodeproject.com) and as usual spent 20 minutes cleaning up the code. Don't get me wrong, I'm grateful for the contributions and use them often. What bothers me is that many of what the industry considers "best practices" are simply ignored in these contributions. One of the most fundamental "best practices" is to check the validity of parameters.

What's even more annoying is that it can be done in one line of code if you don't mind a little unusual line formatting.
    
    if (item == null) throw new ArgumentNullException("item");

Now that wasn't so hard?

--------------------------------------------------------------------------------

Side note: Sure would be nice if C# allowed something like this:
    
    item ?? throw new ArgumentNullException("item"); // Not valid!

--------------------------------------------------------------------------------

Strings are a bit more work.
    
    if (string.IsNullOrEmpty(item))
    {
        throw (item == null)
          ? new ArgumentNullException("item")
          : new ArgumentException("empty", "item");
    }

I've noticed that Microsoft has started documenting many of their methods that take string arguments as as returning **ArgumentNullException** or **ArgumentException** to help differentiate between the two states. Check the [File.Open](http://msdn2.microsoft.com/En-US/library/b9skfh7s.aspx) documentation for an example. 

Things can be made more compact by doing the following:
    
    sealed class Throw
    {
        const string notSpecified = "not specified";
    
        static internal void IfNull(object item, string name)
        {
            if (item == null)
            {
                throw new ArgumentNullException(name ?? notSpecified);
            }
        }
    
        static internal void IfNullOrEmpty(string item, string name)
        {
            if (string.IsNullOrEmpty(item))
            {
                throw (item == null)
                    ? new ArgumentNullException(name ?? notSpecified)
                    : new ArgumentException("empty", name ?? notSpecified);
            }
        }
    }

Now you can check arguments as follows:
    
    Throw.IfNullOrEmpty(myString, "myString");
    Throw.IfNull(myObject, "myObject");

The disadvantage of this method is that all your exceptions originate in **Throw.IfNull** or **Throw.IfNullOrEmpty** so you'll have to look one up the call stack to find the issue.

I would prefer a more declarative method. Microsoft could have extended the constraint mechanism to handle this. For example:

--------------------------------------------------------------------------------
    
    void SomeMethod(string item1, object item2)
        where item1 : NotNullOrEmpty, item2 : NotNull // Not valid!
    { ... }

--------------------------------------------------------------------------------

Oh well, one can only hope.
