C# File Utilities
2007-03-17T15:34:59
Since [Bloget™](/bloget) is file based, I needed some file open routines that were robust and tolerant. [Das Blog](http://www.dasblog.net) is a popular open source blogging engine that also uses files so I thought I would take a peek at what they did.

As I suspected, Das Blog has some routines that try to open files several times before raising an error. This makes sense since there is a small possibility that the file may be locked for read when you want to write to it or vice versa. I refactored the code to take advantage of delegates which cuts down on the amount of repeated code I found in the original implementation. In addition, since I'm using .NET 2.0, I could take advantage of anonymous delegates which saved and additional few lines of code.

using System;

using System.IO;

using System.Threading;

namespace BlueOnionSoftware

{

internal static class FileUtilities

{

static internal void WriteFile(string fileName, byte[] buffer)

{

if (fileName == null)

{

throw new ArgumentNullException("WriteFile(fileName)");

}

if (string.IsNullOrEmpty(fileName))

{

throw new ArgumentException("WriteFile(fileName)", "fileName string is empty");

}

if (buffer == null)

{

throw new ArgumentNullException("WriteFile(buffer)"); 

}

CreateBackupFile(fileName);

using (FileStream fileWriter = OpenForWrite(fileName))

{

fileWriter.Write(buffer, 0, buffer.Length);

}

}

static internal FileStream OpenForWrite(string fileName)

{

if (fileName == null)

{

throw new ArgumentNullException("OpenForWrite(file)");

}

if (string.IsNullOrEmpty(fileName))

{

throw new ArgumentException("OpenForWrite(file)", "file string is empty");

}

return OpenFile(fileName, delegate(string name) 

{ return new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None); });

}

static internal FileStream OpenForRead(string fileName)

{

if (fileName == null)

{

throw new ArgumentNullException("OpenForRead(file)");

}

if (string.IsNullOrEmpty(fileName))

{

throw new ArgumentException("OpenForRead(file)", "file string is empty");

}

return OpenFile(fileName, delegate(string name)

{ return new FileStream(name, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read); });

}

static internal FileStream OpenForAppend(string fileName)

{

if (fileName == null)

{

throw new ArgumentNullException("OpenForAppend(file)");

}

if (string.IsNullOrEmpty(fileName))

{

throw new ArgumentException("OpenForAppend(file)", "file string is empty");

}

return OpenFile(fileName, delegate(string name) 

{ return new FileStream(name, FileMode.Append, FileAccess.Write, FileShare.None); });

}

private delegate FileStream OpenFileHandler(string fileName);

static private FileStream OpenFile(string fileName, OpenFileHandler openFileHandler)

{

int retries = 10;

FileStream file;

for (;;)

{

try

{

file = openFileHandler(fileName);

break;

}

catch (UnauthorizedAccessException)

{

if (--retries <= 0)

{

throw;

}

Thread.Sleep(100);

}

}

return file; 

}

static private void CreateBackupFile(string file)

{

if (File.Exists(file))

{

int retries = 10;

string backupFile = file + ".bak";

for (;;)

{

try

{

File.Copy(file, backupFile, true);

break;

}

catch (UnauthorizedAccessException)

{

if (--retries <= 0)

{

throw;

}

Thread.Sleep(100);

}

}

}

}

}

}

Download: [fileutilities.cs (4 KB)](/cdn/images/blog/fileutilities.css)
