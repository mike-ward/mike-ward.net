Desk Drive 1.4.4 Released
2008-08-11T14:25:02
I was still receiving reports of Desk Drive crashing when "Minimize all windows" was active. I talked about this problem in an earlier post titled "[Using C# to Interact with the Shell Gotcha](/blog/post/2008/08/07/using-c-to-interact-with-the-shell-gotcha)". **Well, I was wrong**. If you develop on a system with a later version of the shell interface, it will bind to that version when using the VS 2008 interop code generator. Said another way, you can't just add a reference to the Shell and let VS do the COM interop.

Recall that the reason for the crash is that Windows XP only supports up to IShellDispatch4. Vista added a newer IShellDispatch5 interface to support the 3D Flip task switching feature. When you build under Vista and use Visual Studio's COM interop code generator, it always binds to IShellDispatch5. Even if you cast to IShellDispatch4 as suggested earlier, the generated code first binds to IShellDispatch5 and then to IShellDispatch4. Well, XP does not support IShellDispatch5 which is the cause of the crash when running on XP.

This is like a total bummer. All I really need is a way to tell the code generator which interface to bind too. Unfortunately, that behavior is not supported by the tools. There are two ways to work around the issue. Build on XP (yuck!) or write your own COM Interop. I opted for the later.

There's an excellent article on Code Guru about [Writing your own COM Interop in C#](http://www.codeguru.com/csharp/csharp/cs_misc/com/article.php/c9065/) that provides most of the code you'll need. It's really not all that different from using COM objects in C++ and in some ways easier. However, the interface itself (IShellDispatch in this case) is not defined anywhere in C#. Defining one by hand is tedious and error prone.

To get an interface definition in C# for IShellDispatch, I fired up [Reflector](http://www.aisto.com/roeder/dotnet/) and loaded the Interop.Shell32.dll assembly that Visual Studio generated earlier.

[![image](/cdn/images/blog/DeskDrive1.4.4Released_8162/image_thumb.png)](/cdn/images/blog/DeskDrive1.4.4Released_8162/image.png)

(Click to enlarge)

As you can see, Reflector disassembles the interface into C#. A simple copy and paste and you're there.

By doing my own COM interop, I can now control what interfaces I use from the shell, independent of what platform I'm developing on. By referencing IShellDispatch only, I avoid the casting error that generated the original crash. The work was a little tedious but Desk Drive users are worth the effort :).

Another advantage to doing your own COM Interop is that there is no longer an interop assembley (Interop.Shell32.dll) to deal with and deploy. Fewer assemblies means faster load times and fewer things to screw up.

So, finally, hopefully, I've put to bed the issue of Shell interop in Desk Drive. You can download the source code to Desk Drive to see the specifics of the solution. 
