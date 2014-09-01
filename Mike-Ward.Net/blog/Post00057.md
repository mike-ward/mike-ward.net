Control.DrawToBitmap Method
2006-10-04T20:48:02
A requirement from one of our clients required that I capture an image of a control to a bitmap. Being a Win32 programmer from days gone by I figured no problem. Grab a device context, do some bit blasting and I'm done. It's a little harder in .Net since you have to do a platform invoke for the BitBlt operation but very doable.

Well wouldn't you know it, just about the time I finish up the routine I discover that .Net 2.0 has a new method called [Control.DrawToBitmap](http://msdn2.microsoft.com/en-us/library/system.windows.forms.control.drawtobitmap.aspx) that does this very thing. There are a few restrictions like not working with RichText controls or ActiveX controls. Worked like a charm for me.
