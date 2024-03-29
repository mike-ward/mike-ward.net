Learning F# &ndash; Deployment
2012-05-22T13:23:18
One of the first things I think about when writing a new program is deployment. That may seem odd but the deployment aspect of your program is one of the first things a user encounters. Nothing frustrates me more than getting a shiny new package and then having to search for 10 other dependencies to install before I can get things running.

For a long time, I use to include the .NET runtime installers in my deployment packages. At first the runtime installer package was small but [over the years it has grown quite a bit](http://www.hanselman.com/blog/SmallestDotNetOnTheSizeOfTheNETFramework.aspx). There are [smaller redistributions](http://msdn.microsoft.com/en-us/library/5a4x27ek.aspx) like the client only version but in general, you're looking at a 350mb download for the full package. Fortunately, most Windows installations have the .NET runtime installed for one reason or another (i.e. Windows Update). So much so, that I no longer include it with my installation packages.

Scott Hanselman has also put together an excellent site ([smallestdotnet](http://www.hanselman.com/smallestdotnet/)) to ease the download burden of getting the .NET runtimes. In many cases, the download shrinks to 28mb.

![image_3](/content/images/blog/Learning-F--Deployment_7725/image_3.png)

Unfortunately, the F# runtimes are **not** included in any of the .NET runtime installers. Instead, you'll have to include with your deployment package. Currently, the F# redistributable is only 1.2mb.

Relevant links: [#F Redistributable Package](http://msdn.microsoft.com/en-us/library/ee829875.aspx) and [download](http://go.microsoft.com/fwlink/?LinkID=228912&clcid=0x409)
