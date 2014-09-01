Calling IDisposable through Interfaces that do not require IDisposable
2009-03-15T15:37:51
How do you call IDisposable.Dispose() when your interface does _not_ inherit from [IDisposable](SomeInterface someInterface = SomeInterfaceFactory();) but your implementation _does_? This happens more often than you might think, particularly when code generation is involved. For example, when Visual Studio generates service proxies for WCF service contracts, the generated ServiceClientProxy derives from System.ServiceModel.ClientBase, which can contain an auto-generated IDisposable depending on the interface constructs.

Of course you can always test for IDisposable by casting like below.
    
    SomeInterface someInterface = SomeInterfaceFactory();
    
    try
    {
        someInterface.Bla().Bla().Bla();
    }
    
    finally
    {
        if (someInterface is IDisposable)
            ((IDisposable)someInterface).Dispose();
    }

This is straightforward and I think most programmers grok the construct. However, there is another way.
    
    SomeInterface someInterface = SomeInterfaceFactory();
    
    using (someInterface as IDisposable)
    {
        someInterface.Bla().Bla().Bla();
    }

This essentially generates the same code as the first example. The compiler keeps an internal variable to the object returned by “someInterface as IDisposable” and checks it against null before calling Dispose().

Either way works but in more complex code scenarios the _using_ syntax can be less noisy and reduce the number of braces required.
