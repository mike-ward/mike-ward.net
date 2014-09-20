Using C# to Interact with the Shell Gotcha
2008-08-07T13:33:36
**Update**: I've discovered my solution here is flawed. See [Desk Drive 1.4.4 Released](/blog/post/2008/08/11/desk-drive-1-4-4-released) for details.

Interacting with the Shell in C# is easy because the common language runtime exposes COM objects through a proxy called the runtime callable wrapper (RCW). Although the RCW appears to be an ordinary object to .NET clients, its primary function is to marshal calls between a .NET client and a COM object.

![rcw](http://az667460.vo.msecnd.net/cdn/images/blog/UsingCtoInteractwiththeShellGotcha_8666/rcw.png)

For instance, to interact with Shell, add a reference to the** Microsoft Shell Controls And Automation** COM object.

[![image](http://az667460.vo.msecnd.net/cdn/images/blog/UsingCtoInteractwiththeShellGotcha_8666/image_thumb.png)](http://az667460.vo.msecnd.net/cdn/images/blog/UsingCtoInteractwiththeShellGotcha_8666/image.png)

Interacting with the Shell then is as easy as:
    
    var shell = new Shell32.ShellClass();
    shell.MinimizeAll();

The RCW gives the Shell32 object the appearance of a .Net object. No messy reference counting or **QueryInterface()** calls. This is how I originally wrote the code in [Desk Drive](/blog/post/2008/08/06/desk-drive-1-4-released) and it worked great on Vista, the platform I developed it on.

However, when I ran it on Windows XP because of an invalid cast exception to **Shell32.IShellDispatch5**. Embarrassingly, it took a few moments for me to realize what had happened here.

Vista has a newer version of the Shell COM object. Since I was developing under Vista, the RCW naturally assumed I wanted the latest interface (**Shell32.IShellDispatch5**). Windows XP only supports the **Shell32.IShellDispatch4** interface. Not having to deal with COM on a daily basis I forgot that it's vital to specify the interface you want in order to avoid just such a problem

Fortunately, the fix is easy here.
    
    var shell = (Shell32.IShellDispatch4)new Shell32.ShellClass();
    shell.MinimizeAll();

In C#, casting is overloaded to call **QueryInterface()** and retrieve the correct interface. The lesson here is clear, when using COM objects, always be explicit as to which interface you want. Don't let the compiler decide or you might get a surprise as I did.
