Console application debugging made easier
2008-03-27T15:09:36
When debugging console applications in .NET I like the program to pause just before exit so I can study the console output. One way to do this is to set a break point at the end of the application. This is OK but shifts the focus to the IDE which is annoying, especially in single screen environments like my laptop.

I've found a better way. Place a _finally_ block at the end of your program as follows.
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // your code here...
            }
    
            finally
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.WriteLine("Press [enter] to exit");
                    Console.ReadLine();
                }
            }
        }
    }

Now the program pauses while debugging allowing you to read the console output.
