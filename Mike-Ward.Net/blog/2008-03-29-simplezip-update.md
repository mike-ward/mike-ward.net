SimpleZip Update
2008-03-29T20:58:29
![](http://content.answers.com/main/content/wp/en-commons/d/d9/Torchlight_zip.png) SimpleZip is my .NET (C#) Zip file generator that requires no third-party support libraries. You can read more about it at the [Code Project](http://www.codeproject.com/KB/cs/SimpleZip.aspx). This update adds one additional API.

void ZipTo(IEnumerable<string> fileNames, Stream archiveStream, bool flatten);   


The new parameter _flatten_ strips the directory paths off the file names when adding them to the Zip archive. This has the effect of "flattening" the structure to a single folder. Source code and sample project are available on the Downloads page.
