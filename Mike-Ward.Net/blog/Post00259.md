SimpleZip - Generate Zip files with one line of code
2008-03-22T14:19:21
.NET doesn't have much in the way of built-in archive support. If you want to Zip up some files you can use the open source [SharpZipLib](http://www.icsharpcode.net/OpenSource/SharpZipLib/) or a commercial package like [Xceed](http://xceed.com/). There's also Zip API's in the J# library but you can't count on the assemblies being installed. A recent article in The Code Project called [SimpleUnzipper](http://www.codeproject.com/KB/cs/Simple_Unzipper.aspx) inspired me to write a counter part aptly named SimpleZip.

SimpleZip consists of one class with one public method and about 450 lines of code. It can easily be added to an existing project and the code is small enough that it can be readily understood and modified. The one static method is as follows:

    static void ZipTo(IEnumerable<string> fileNames, Stream archiveStream)

Its use should be self-explanatory.

The archiveStream is of particular interest in that it does not have to be a seekable stream. To see why this is interesting (and important) it's worth taking a moment to understand a little of the Zip archive structure.

The Zip archive has a simple structure that supports file compression. The basic structure is:
    
    [local file header 1]
    [file data 1]
    [data descriptor 1]
        . 
        .
        .
    [local file header n]
    [file data n]
    [data descriptor n]
    [archive decryption header] 
    [archive extra data record] 
    [central directory]
    [end of central directory record]
    
    Local file header:
    
        local file header signature     4 bytes  (0x04034b50)
        version needed to extract       2 bytes
        general purpose bit flag        2 bytes
        compression method              2 bytes
        last mod file time              2 bytes
        last mod file date              2 bytes
        crc-32                          4 bytes
        compressed size                 4 bytes
        uncompressed size               4 bytes
        file name length                2 bytes
        extra field length              2 bytes
    
        file name (variable size)
        extra field (variable size)

The local file header is of interest in that the compressed size, uncompressed size and CRC-32 all come before the actual file bits. This format makes it difficult to stream an archive from a generator without backtracking in the stream to update the size and CRC-32 values. This format is likely in part due to the "file" orientation of the original product.

Fortunately, a later update allows us to place the size and CRC-32 values after the file content in the _data descriptor_ section. To do this, bit 3 of the _general purpose bit flag_ is set. The decompressor then knows to look for the size and CRC-32 values after the file data.

With this modification it is now possible to write to non-seekable streams. An example of a non-seekable stream you may encounter is _Page.Response.OutputStream_ from ASP.NET. Without this modification, the archive would have to be streamed to an intermediate stream (likely a file). There are security situations that sometime preclude using temporary files. And besides, it just a bit wasteful.

.NET has support for the Deflate compression algorithm used in PKZip and other popular Zip archive programs. While there are other more efficient compression algorithms available, Deflate does a "good enough" job for most situations. It's also fast and supported on many platforms. But here in lies a second problem. At the end of the deflation, we have to emit the compressed size. If we're writing to a non-seekable stream however, we can't use the Position or Length properties of the stream since these properties often raise a _NotSupportedException_. 

The number of bytes going into the compressor is in general different than the number of bytes emitted and yet we can't query the archive stream for the number of bytes written because the Position and Length properties are not supported in non-seekable streams.


To workaround this problem, a second, in-line stream is added that simply counts the bytes as they go by. Since it is after the compressor (deflate) stream it accurately counts the number of bytes that will be written to the archive stream.


By now it should be apparent that one of my goals is to use this Zip generator in a Web application. With this class I can easily send a Zip file as a response to a Web request as follows:

    Page.Response.Clear();   
    Page.Response.ContentType = "application/zip";   
    Page.Response.AddHeader("Content-Disposition", "attachment;filename=" + "archive.zip");   
    SimpleZip.ZipTo(files, Page.Response.OutputStream);   
    Page.Response.End();

A couple more points in the code. _CounterStream,_ like _DeflateStream,_ has a option to leave the contained stream open when it is closed. The normal behavior of streams is to close the contained stream when closed or disposed. Obviously, the stream cannot be closed until the caller closes the stream.

Another annoying omission in the .NET library is there is no CRC-32 implementation. One is included here.

**Limitations** 

SimpleZip will not leave WinZip and its brethren quivering in their boots anytime soon. While small and easy to use, there are lots of things SimpleZip does not support. For instance, you can not modify an existing archive. The .NET Deflate algorithm is not as effective as other implementations in part due to its streaming interface. Also, large archive support (> 2 GB) is not supported since .NET does not have Deflate64 support. There is no support for file/archive comments or encryption.

Still, I think SimpleZip will work satisfactorily in many situations. You can get the code and (admittedly light weight) unit tests from the Downloads page. Feedback, enhancements and bug fixes welcomed.
