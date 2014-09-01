Pretty Printing Collections in C#
2009-08-12T16:15:17
The combination of [Extension Methods](http://msdn.microsoft.com/en-us/library/bb383977.aspx) and [LINQ](http://msdn.microsoft.com/en-us/library/bb308959.aspx) can make everyday tedious programming chores a bit less annoying. Take formatting an array of strings.
    
    static void Main()
    {
        string[] languages = { "English", "German", "Portuguese", "Swedish" };
        Console.WriteLine(languages.Aggregate((n, n1) => n + ", " + n1));
    }

Output:
    
    English, German, Portuguese, Swedish

I know, it’s a little thing, but is sure is convenient. OK, your turn. What’s your favorite little extension method or LINQ snippet?
