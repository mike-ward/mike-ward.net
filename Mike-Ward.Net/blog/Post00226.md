Repairing IE7 in Vista
2007-12-24T16:30:00
I've been using Vista on my new laptop for 3 months now and still like it. I'm puzzled why there is such hatred leveled at this operating system. CNet in fact called it one of the 5 worst technologies of 2007. I guess I've just been lucky.

![](http://www.microsoft.com/library/media/1033/windows/images/products/winfamily/ie/icon_ie7.gif)

Yesterday, I hit my first real issue and I'm not even sure it's a Vista issue so much as an IE7 issue. Anyway, I couldn't open web pages in IE7 without getting JavaScript errors. Even Google's home page caused issues. I usually use Safari or Firefox for browsing so it wasn't a big deal. Still, the one thing I find IE7 better for is developing ASP.NET applications in Visual Studio 2008. The integration is just better with IE7 in this one instance (no surprise here I suppose).

Well, after spending hours searching forums and trying everything from resetting IE to sacrificing a small goat, I found a message board entry that suggested re-registering the JavaScript engine (Jscript.dll). In hindsight it should have been the first thing I tried but the errors and suggestions I found led me in other directions. Needless to say, that was the tonic IE7 needed. As an extra measure of insurance, I registered all the other components that might affect IE. Copy the lines below into a batch file and execute it in your Windows\System32 directory with Admin privileges if you're experiencing similar issues. 

**The usual warnings apply here about modifying the registry meaning I'm not responsible for any damage or issues arising from using this script. Make sure to set a restore point before applying this file.**
    
    
    rundll32.exe advpack.dll /DelNodeRunDLL32 C:\\WINNT\\System32\ \dacui.dll 
    rundll32.exe advpack.dll /DelNodeRunDLL32 C:\\WINNT\\Catroot\ \icatalog.mdb 
    regsvr32 URLMON.DLL /s 
    regsvr32 actxprxy.dll /s 
    regsvr32 shdocvw.dll /s 
    regsvr32 oleaut32.dll /s 
    regsvr32 setupwbv.dll /s 
    regsvr32 wininet.dll    /s 
    regsvr32 comcat.dll    /s 
    regsvr32 shdoc401.dll /s 
    regsvr32 shdoc401.dll /i /s 
    regsvr32 asctrls.ocx /s 
    regsvr32 oleaut32.dll /s 
    regsvr32 shdocvw.dll /I /s 
    regsvr32 shdocvw.dll /s 
    regsvr32 browseui.dll /s 
    regsvr32 browseui.dll /I /s 
    regsvr32 msrating.dll /s 
    regsvr32 mlang.dll /s 
    regsvr32 hlink.dll /s 
    regsvr32 mshtml.dll /s 
    regsvr32 mshtmled.dll /s 
    regsvr32 urlmon.dll /s 
    regsvr32 plugin.ocx /s 
    regsvr32 sendmail.dll /s 
    regsvr32 comctl32.dll /i /s 
    regsvr32 inetcpl.cpl /i /s 
    regsvr32 mshtml.dll /i /s 
    regsvr32 scrobj.dll /s 
    regsvr32 mmefxe.ocx /s 
    regsvr32 proctexe.ocx    /s 
    regsvr32 corpol.dll /s 
    regsvr32 jscript.dll /s 
    regsvr32 msxml.dll /s 
    regsvr32 imgutil.dll /s 
    regsvr32 thumbvw.dll /s 
    regsvr32 cryptext.dll /s 
    regsvr32 rsabase.dll /s 
    regsvr32 triedit.dll /s 
    regsvr32 dhtmled.ocx /s 
    regsvr32 inseng.dll /s 
    regsvr32 iesetup.dll /i /s 
    regsvr32 hmmapi.dll /s 
    regsvr32 cryptdlg.dll /s 
    regsvr32 actxprxy.dll /s 
    regsvr32 dispex.dll /s 
    regsvr32 occache.dll /s 
    regsvr32 occache.dll /i /s 
    regsvr32 iepeers.dll /s 
    regsvr32 wininet.dll /i /s 
    regsvr32 urlmon.dll /i /s 
    regsvr32 digest.dll /i /s 
    regsvr32 cdfview.dll /s 
    regsvr32 webcheck.dll /s 
    regsvr32 mobsync.dll /s 
    regsvr32 pngfilt.dll /s 
    regsvr32 licmgr10.dll /s 
    regsvr32 icmfilter.dll /s 
    regsvr32 hhctrl.ocx /s 
    regsvr32 inetcfg.dll /s 
    regsvr32 trialoc.dll /s 
    regsvr32 tdc.ocx /s 
    regsvr32 MSR2C.DLL /s 
    regsvr32 msident.dll /s 
    regsvr32 msieftp.dll /s 
    regsvr32 xmsconf.ocx /s 
    regsvr32 ils.dll /s 
    regsvr32 msoeacct.dll /s 
    regsvr32 wab32.dll /s 
    regsvr32 wabimp.dll /s 
    regsvr32 wabfind.dll /s 
    regsvr32 oemiglib.dll /s 
    regsvr32 directdb.dll /s 
    regsvr32 inetcomm.dll /s 
    regsvr32 msoe.dll /s 
    regsvr32 oeimport.dll /s 
    regsvr32 msdxm.ocx /s 
    regsvr32 dxmasf.dll /s 
    regsvr32 laprxy.dll /s 
    regsvr32 l3codecx.ax /s 
    regsvr32 acelpdec.ax /s 
    regsvr32 mpg4ds32.ax /s 
    regsvr32 voxmsdec.ax /s 
    regsvr32 danim.dll /s 
    regsvr32 Daxctle.ocx /s 
    regsvr32 lmrt.dll /s 
    regsvr32 datime.dll /s 
    regsvr32 dxtrans.dll /s 
    regsvr32 dxtmsft.dll /s 
    regsvr32 vgx.dll /s 
    regsvr32 WEBPOST.DLL /s 
    regsvr32 WPWIZDLL.DLL /s 
    regsvr32 POSTWPP.DLL /s 
    regsvr32 CRSWPP.DLL /s 
    regsvr32 FTPWPP.DLL /s 
    regsvr32 FPWPP.DLL /s 
    regsvr32 FLUPL.OCX /s 
    regsvr32 wshom.ocx /s 
    regsvr32 wshext.dll /s 
    regsvr32 vbscript.dll /s 
    regsvr32 scrrun.dll mstinit.exe /setup /s 
    regsvr32 msnsspc.dll /SspcCreateSspiReg /s 
    regsvr32 msapsspc.dll /SspcCreateSspiReg /s 
    regsvr32 msxml3.dll /s
    
