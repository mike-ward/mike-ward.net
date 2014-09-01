WCF timings with different bindings
2008-06-16T20:16:46
I was curious how WCF timings compared using different transport bindings. Here's what I came up with:

`Buffered   
--------   
WSHttpBinding : time=00:00:00.7206547, length=11520054   
NetTcpBinding : time=00:00:00.5371746, length=11520054 

`Streaming   
---------   
BasicHttpBinding : time=00:00:00.9087755, length=11520054   
NetTcpBinding : time=00:00:01.8869526, length=11520054 `

```---------   
NetBIOS : time=00:00:00.9174436, length=11520054`

The test measured how long it took to get an 11MB image file from a remote server. This is not what one would call a definitive test. However, I think the results are interesting enough to share.

The "Buffered" test retrieves the image file as a byte array. The streaming tests return a stream which is used in a loop to read the file in 16K chunks. And finally, the NetBIOS test is nothing more the opening the same file as a share and reading all the bytes into an array.

Now I don't know about you, but I would have expected the NetBIOS time to be fastest here. Apparently, NetBIOS is not all the efficient. What's a real surprise is streaming with NetTcpBinding. I ran the test quite a few times and streaming NetTcpBinding always came in dead last. Again, not what I would have expected.

All bindings were set not to use security. The hosting server was else where on our local LAN.

Are these numbers in line with what others have found? 
