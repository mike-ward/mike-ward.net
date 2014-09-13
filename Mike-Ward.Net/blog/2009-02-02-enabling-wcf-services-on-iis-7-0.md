Enabling WCF Services on IIS 7.0
2009-02-02T18:30:10
![Powered by IIS7](http://www.iis.net/themes/iis/images/powered-by-iis7-1of2.png)Out of the box, IIS 7.0 (Windows Server 2008) does not support WCF Services. Perhaps this is another one of those security issues that Windows Server 2008 and IIS 7.0 lock down by default. Annoyingly, the error displayed on the browser does not offer many clues as to what went wrong.

After running my custom Web services installer, I check for the availability of the service by opening a browser and navigating to the service (.svc) page. On IIS 6.0, this just worked if I had the .NET 3.5 framework installed. On IIS 7.0, even with the .NET 3.5 framework installed, I was still getting an error (404.3 to be precise). The magic to make this work requires registering a bunch of service handlers. Fortunately, it’s a one liner.

Open a command prompt and run the following:
    
    %windir%\Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ServiceModelReg.exe –r –y

Afterwards, you should be able to navigate to the .svc page.
