Launch product after setup finishes in MSI installers
2008-08-12T15:26:17
Visual Studio 2008 includes a setup project that can build MSI installers for your products. The authoring interface is a bit clunky but it incorporates most of the features one would want in a robust installer. Furthermore, since it is a Windows MSI Installer, it provides enterprise level options like feature selection and rollback. All in all, its a powerful and useful package.

Many installers offer to launch the product after the installer finishes. I've always found this feature handy. MSI installers natively support this "Launch product after install finishes" feature. Unfortunately, the Visual Studio IDE UI does not expose this customization.

But not all is lost. With a bit of JavaScript and a custom build command, you can access the Windows Installer object model and perform this customization. [Aaron Stebner's WebLog](http://blogs.msdn.com/astebner/archive/2006/08/12/696833.aspx) provides an excellent tutorial and script to enable the "Launch product after setup finishes" feature.

I added Aaron's script and custom build step to Desk Drive's installer. As you can see from the image below, it works quite nicely.

[![launchonexit](http://az667460.vo.msecnd.net/cdn/images/blog/LaunchproductaftersetupfinishesinMSIinst_A0BF/launchonexit_thumb.png)](http://az667460.vo.msecnd.net/cdn/images/blog/LaunchproductaftersetupfinishesinMSIinst_A0BF/launchonexit.png)

Don't forget to keep those translations coming for Desk Drive. I have English, German, Slovakian, Japanese and Finnish.
