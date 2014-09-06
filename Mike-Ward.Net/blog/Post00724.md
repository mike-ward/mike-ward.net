Update: Desk Drive 1.8.5
2011-11-20T19:50:07
This update fixes an occasional but persistent crash when removing drive media. It doesn't happen on most systems but when it does, it sure is a bummer. I could never reproduce this but one of your fellow users could and he was willing to put up with several updates and fiddling to run the problem down. Thanks!

The other reason I haven't updated this in a while is that Microsoft stopped supporting the Visual Studio setup project I used to build installers. Really irritating in my opinion. I like _._msi setups but they are a bit of work to build and support (I'm talking WiX here). I've switched over to [Inno Setup](http://www.jrsoftware.org/isinfo.php). It's not as robust as WiX but it's easy to author setups and is well supported. I've stopped trusting Microsoft when it comes to setup authoring.

You'll also notice that the setup program will ask to install a third party package. This is strictly an opt-in. I know some of you will object. I get some loose change if you opt-into the install and keep the package installed for at least 24 hours. It's about as painless away as I can think of to monetize the programs at this time. Your support is appreciated.

Since this is a new installer technology, it won't automatically uninstall or upgrade the older software. Please uninstall any older versions of Desk Drive before installing this new one.

Now that I have a new installer technology, I'll be actively developing Desk Drive and my other freeware again.

Available on the [downloads page](/downloads).
