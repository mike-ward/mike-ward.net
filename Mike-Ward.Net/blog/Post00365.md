The Definitive C# Singleton
2008-09-24T13:28:37
It’s looks like it’s not thread safe but the framework actually guarantees that it is.
    
    // .NET Singleton
    sealed class Singleton
    {
        static Singleton() {} // required to make lazy
        private Singleton() {}
        public static readonly Singleton Instance = new Singleton();
    }

There’s also an interesting discussion of double locks in the article. Check out [Exploring the Singleton Design Pattern](http://msdn.microsoft.com/en-us/library/ms954629.aspx) for details.
