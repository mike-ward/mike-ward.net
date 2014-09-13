Improving your code with LINQ and Lambdas
2009-06-06T14:38:20
I’m surprised at how much code I review that still does not take advantage of the newer constructs of C#. Here’s an (admittedly contrived) example.
    
    static void Main()
    {
        var names = new[] { "name1", "name2", "name3", "name4", "name5", "name6", "name7" };
        var count = 0;
        foreach (var name in names)
        {
            if (name.Contains("name"))
                count += 1;
        }
        Console.WriteLine(count);
    }
    

Now compare it to this.
    
    static void Main()
    {
        var names = new[] { "name1", "name2", "name3", "name4", "name5", "name6", "name7" };
        Console.WriteLine(names.Count(name => name.Contains("name")));
    }
    

Which would you prefer to maintain? Which one more clearly communicates the intent of the program?

If that’s not enough to convince you, consider that extension methods like **Count()** are static, which allows for further optimizations and parallel execution opportunities.

If you consider yourself a pro, you owe it to yourself (and your fellow developers) to keep on top of these things. Read books, pair program, embrace the changes and learn from others. People smarter than you and I have spent countless hours thinking about these things and improving them. Shouldn’t you take advantage of those efforts?
