Generating WCF Service Proxies without Visual Studio
2012-04-04T19:08:53
Ever since my employer transitioned from Clearcase to TFS, I could no longer generate WCF service proxies using the “Add Service Reference” feature of Visual Studio (it generated an empty proxy file). The “Add Service Reference” feature has always been problematic for me so it was time to take matters into my own hands.

There are two alternatives as I see it.

  * Write your own proxy 
  * Generate the proxy manually 

Synchronous proxies are relatively easy to write and might be a good way to go. Async proxies are much harder. And aysnc, event-driven proxies, the kind used in Silverlight are just downright obnoxious.

Generating the proxies manually is much easier. The trick is to use the _SLsvcutil.exe_ utility. The regular _svcutil.exe_ utility will not generate a Silverlight compatible proxy. It took a bit of head banging to get all the options correct but once I did, it worked, everytime. Here’s an example command:

`"%PROGRAMFILES(x86)%\Microsoft SDKs\Silverlight\v4.0\Tool\slsvcutil.exe"`   
`**_http://localhost:62881/MyService.svc?wsdl_**`   
`/namespace:"*,**_MyService_**"`   
`/ct:System.Collections.ObjectModel.ObservableCollection'1`   
`/r:"%PROGRAMFILES(x86)%\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\System.Windows.dll"`

The bold-italic parts (the service address and namespace) are what you’ll need to change for a specific contract. I saved this in a batch file called “GenerateProxy.bat” in the folder for the service under the service reference folder.

This command generates only two files, not a dozen like the Visual Studio version. One file contains the proxies, the other contains an example Client.config file. If you’re adding a new service for the first time, you’ll have to update this project’s ServiceReferences.Client.config file. This is needed to allow the hosting of services locally for debugging.

When it comes time to update the service, just run GenerateProxy.bat.
