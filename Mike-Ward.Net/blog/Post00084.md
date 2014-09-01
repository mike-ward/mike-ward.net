File.WriteAllBytes
2006-12-15T00:03:04
The .NET runtime has so many features it is difficult to keep track. Just the other night, I need to write a byte[] to a file. I started out with something like this:

using (FileStream stream = newFileStream("myfile", FileMode.CreateNew))

{

stream.Write(buffer, 0, buffer.Length);

}

Not bad but it is a little tedious. Then I discovered quite by accident that .NET 2.0 added helper methods to the System.File class including **System.File.WriteAllBytes**.

Other "helper" methods include **ReadAllBytes**, **ReadAllLines**, **ReadAllText**, **WriteAllLines**, **WriteAllText** and **AppendAllText**. These methods are not hard to write as evidenced above, but they sure are handy none-the-less.

So now the example above becomes:

File.WriteAllBytes("myfile", buffer);
