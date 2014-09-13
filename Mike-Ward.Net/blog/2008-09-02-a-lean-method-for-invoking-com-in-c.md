A lean method for invoking COM in C#
2008-09-02T20:50:08
One of the features I wanted to add to Desk Drive was the ability to minimize all windows when it detected a new drive. There's a method in the Windows Shell that is exposed through COM that does this. One way to get at this is to do the following:

Add a reference "Microsoft Shell Controls and Automation" typelib (Add Reference | COM Tab)

Then do the following somewhere in your code.
    
    Shell32.ShellClass shell = new Shell32.ShellClass();
    shell.MinimizeAll();

While this is easy for the programmer, it comes at a cost. The IDE generates an assembly named **Interop.Shell32.dll** which must be deployed with the application. Furthermore, the assembly is relatively large (52 KB) considering we're calling only one method.

I dislike multiple assemblies for deployments. My ideal distribution is one executable image when I can get away with it. Also, it takes time to load and initialize the interop DLL, not to mention the extra memory overhead. There has to be a better way.

A quick trip to [Adam Nathan's](http://en.wikipedia.org/wiki/Adam_Nathan) "[.NET and COM, The Complete Interoperability Guide](http://search.barnesandnoble.com/ASPNET/Scott-Mitchell/e/9780672321436/?itm=2)" yields the answer in Chapter 21, "Manually Defining COM Types in Source Code". Here's an example console program that minimizes all desktop windows.
    
    namespace MinimizeAll
    {
        using System;
        using System.Runtime.InteropServices;
    
        class Program
        {
            static void Main()
            {
                var shell = new Shell32();
                var shellDispatch = (IShellDispatch)shell;
                shellDispatch.MinimizeAll();
            }
        }
    
        [ComImport, Guid("13709620-C279-11CE-A49E-444553540000")]
        class Shell32
        {
        }
    
        [ComImport, Guid("D8F015C0-C278-11CE-A49E-444553540000")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IShellDispatch
        {
            [DispId(0x60020007)]
            void MinimizeAll();
        }
    }

That's really all there is to it. Of course a few notes about what is going on here are in order.

There's no Interop DLL generated! First and foremost is that there is no need to reference the "Microsoft Shell Controls and Automation" typelib any longer.

The C# compiler is pretty smart when it comes to COM, provided you give it a few hints. There are two attributes every COM class must include in managed code:

  * ComImportAttribute
  * GuidAttribute

ComImportAttribute is a bit misleading in that it doesn't really "import" anything. It simply marks the class as a COM type. The GuidAttribute identifies the class/interface from the COM perspective.

Constructing COM classes is remarkably easy. The Guid in this case is the CLSID for the Shell Controls and Automation class. The compiler generates the necessary CoCreateInstance logic in the default constructor. 

Next, we need a definition for the IShellDispatch interface. Again, the class is properly decorated to identify it as a COM object. Because IShellDispatch is a dispatch-only interface, the order of the members doesn't matter. All invocations are done via IDispatch. And since we're only calling MinimizeAll(), we can get away with specifying the one method even though IShellDispatch contains other methods. Don't try this with IUnknown-only or dual interfaces where the order and number of members are used to generate vtables.

Finally, it's necessary to tell the compiler you're using a dispatch-only interface by specifying the InterfaceTypeAttribute. Without this, objects will not marshal correctly.

One problem in the above example is that the COM objects are never released. I generally wrap these objects in a sealed class that handles the reference counting. Here's an example.
    
    sealed class Shell : IDisposable
    {
        Shell32 shell;
        IShellDispatch shellDispatch;
    
        public Shell()
        {
            shell = new Shell32();
            shellDispatch = (IShellDispatch)shell;
        }
    
        public void MinimizeAll()
        {
            if (shellDispatch == null)
                throw new ObjectDisposedException("Shell");
    
            shellDispatch.MinimizeAll();
        }
    
        public void Dispose()
        {
            try
            {
                if (shellDispatch != null)
                    Marshal.ReleaseComObject(shellDispatch);
    
                if (shell != null)
                    Marshal.ReleaseComObject(shell);
            }
    
            finally
            {
                shell = null;
                shellDispatch = null;
                GC.SuppressFinalize(this);
            }
        }
    }

That's it! Use your new found COM powers wisely.
