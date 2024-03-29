Resolving Dependent .NET Assembly Version Conflicts
2007-04-08T13:52:36
I ran into an interesting error message this morning while adding some [NUnitAsp](http://nunitasp.sourceforge.net/tutorial/index.html) unit tests to [Bloget](/bloget).

* * *

------ Build started: Project: Bloget, Configuration: Debug Any CPU ------  
Bloget -> D:\Data\Visual Studio 2005\Projects\Bloget\Bloget\bin\Debug\Bloget.dll  
------ Build started: Project: D:\...\BlogetTest\, Configuration: Debug .NET ------  
Validating Web Site  


Validation Complete  
------ Build started: Project: UnitTests, Configuration: Debug Any CPU ------  
**Consider app.config remapping of assembly "nunit.framework, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77" from Version "2.2.0.0" [] to Version "2.2.8.0" [C:\Program Files\TestDriven.NET 2.0\NUnit\nunit.framework.dll] to solve conflict and get rid of warning.  
**C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Microsoft.Common.targets : warning MSB3247: **Found conflicts between different versions of the same dependent assembly**.  


* * *

I've highlighted the relevant bits here. This occurs because NUnitAsp depends on a different version of the NUnit framework than [Test Driven .NET](http://www.testdriven.net/). I'm a bit fan of TDN but I also want to unit test the UI portions of Bloget which is what NUnitAsp does (more on this in another blog post). Fortunately, the error message gives you all you need to know to fix the problem. I added an App.config file to the project with the following XML.

`<?xml version="1.0"?>  
<configuration>  
<runtime>  
<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
<dependentAssembly>  
<assemblyIdentity name="nunit.framework" publicKeyToken="96D09A1EB7F44A77" culture="neutral"/>  
<bindingRedirect oldVersion="0.0.0.0-2.2.8.0" newVersion="2.2.8.0"/>  
</dependentAssembly>  
</assemblyBinding>  
</runtime>  
</configuration> `

Having to enter this by hand is a real drag. But then I discovered an interesting shortcut. If you double-click on the warning message in Visual Studio 2005's Error List view, it will pop-up a nice little dialog like this:

![One or more dependent assemblies have version conficts. Do you want to fix these conflicts by adding binding redirect records to the app.config?](http://www.myotherdrive.com/public/blueonion/Blog/AssemblyConflictDialog.png)

(I run a Mac like theme on my laptop which is why the dialog does not look like Windows XP)

Once added, the build and run work as expected.
