Calling Managed Code from C++ Gotcha
2008-04-04T14:14:35
Here's an issue I ran into the other day.
    
    IMarkupServices markup = (IMarkupServices)htmlDocument2;

This line of code was imbedded in a C# routine. When called from other C# routines, it worked fine. However, when called from a legacy C++ program it raised an InvalidCastException.

The inner exception of this code reported a COM error of E_NOINTERFACE. Huh? Clearly the documentation says that IHTMLDocument2 contains a reference to IMarkupServices. So what's happening?

The Gotcha is that many COM (aka ActiveX) controls require single threaded apartment mode. In C#, you can force this by adding the STAThreadAttribute to your entry point as follows:
    
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

In C++, you can't do this if you're entry point is not managed. Instead, you'll need to use a linker switch:
    
    /CLRTHREADATTRIBUTE:STA

Setting the correct apartment model allows the cast to succeed.

Adam Nathan's blog article "[Gotcha with STAThreadAttribute and Managed C++](http://blogs.msdn.com/adam_nathan/archive/2003/07/18/56727.aspx)" explains why this linker setting is necessary.
