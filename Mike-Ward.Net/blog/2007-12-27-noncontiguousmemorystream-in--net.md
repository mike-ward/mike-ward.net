NonContiguousMemoryStream in .NET
2007-12-27T23:19:07
System.IO.MemoryStream is one handy little class. One of my favorite uses for memory streams is serialization. I typically serialize to a memory stream first and then copy the stream to a file or other backing store. Why I do this is simple. If the serialization faults, I don't corrupt the backing store image. You can of course accomplish a similar thing using temporary files but I find the speed and convenience of memory streams to be better.

However, like all things programming, there is a price to be paid. The System.IO.MemoryStream uses a single buffer as a backing store. For small items, this is just fine. But if the stream is large, it's possible to not have enough contiguous memory due to fragmentation. This problem is compounded by the [large heap compaction strategy in .NET](http://msdn.microsoft.com/msdnmag/issues/1200/GCI2/). I've seen situations where memory is exhausted long before the actual physical memory limit is reached.

One way avoid both the contiguous memory limitation as well the the large heap problem in .NET is to allocate the backing store in smaller chunks. As the backing store grows, more chunks are added to the backing store. This can relieve memory pressure by not forcing the heap to compact as often and avoids the large heap compaction issue in .NET by keeping the chunks smaller than 85KB.

NonContigusousMemoryStream is my version of System.IO.MemoryStream that allocates its backing store in 8KB chunks. There's a small performance penalty by using chunks so you'll want to use this class only in situations where large memory streams occur.

I wrote several tests designed to progressively allocate and dispose memory streams until memory was exhausted. In these tests, NonContiguousMemoryStream was able to run 3 times as many iterations as using System.IO.MemoryStream. Performance was only 10% slower as compared to System.IO.MemoryStream (up to the point where System.IO.MemoryStream failed).

Included in the source code is a series of unit tests that exercise all operations of the code. If you plan on using it, I would appreciate a note on how you're using it and any issues you encountered. Otherwise, it's free for any use.

[Source Code](/downloads/NonContiguousMemoryStream.zip)
    
    
    using System;
    using System.IO;
    using System.Collections.Generic;
    
    namespace BlueOnionSoftware
    {
        class NonContiguousMemoryStream : Stream
        {
            readonly int bufferStoreSize = 8 * 1024;
            readonly List buffersStore = new List();
            long position;
            long length;
            bool disposed;
    
            public override bool CanRead
            {
                get
                {
                    if (disposed)
                    {
                        throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                    }
    
                    return true;
                }
            }
    
            public override bool CanSeek
            {
                get
                {
                    if (disposed)
                    {
                        throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                    }
    
                    return true;
                }
            }
    
            public override bool CanWrite
            {
                get
                {
                    if (disposed)
                    {
                        throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                    }
    
                    return true;
                }
            }
    
            public override void Flush()
            {
            }
    
            public override long Length
            {
                get
                {
                    if (disposed)
                    {
                        throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                    }
    
                    return length;
                }
            }
    
            public override long Position
            {
                get
                {
                    if (disposed)
                    {
                        throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                    }
    
                    return position;
                }
    
                set
                {
                    if (disposed)
                    {
                        throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                    }
    
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("value", "position >= 0");
                    }
    
                    position = value;
                }
            }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                if (disposed)
                {
                    throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                }
    
                if (buffer == null)
                {
                    throw new ArgumentNullException("buffer");
                }
    
                if (offset < 0 || offset > buffer.Length)
                {
                    throw new ArgumentOutOfRangeException("offset", offset, "0 <= offset < buffer.Length");
                }
    
                if (count < 0 || count > buffer.Length)
                {
                    throw new ArgumentOutOfRangeException("count", count, "0 <= count < buffer.Length");
                }
    
                int end = Math.Min(buffer.Length, offset + count);
                int startingOffset = offset;
                int buffersStoreIndex = (int)(position / bufferStoreSize);
                int bufferStoreOffset = (int)(position % bufferStoreSize);
    
                while ((offset < end) && (position < length))
                {
                    byte[] bufferStore = buffersStore[buffersStoreIndex];
                    int run = Math.Min(end - offset, bufferStoreSize - bufferStoreOffset);
                    Buffer.BlockCopy(bufferStore, bufferStoreOffset, buffer, offset, run);
                    offset += run;
                    bufferStoreOffset += run;
                    position += run;
    
                    if (bufferStoreOffset == bufferStoreSize && position < length)
                    {
                        buffersStoreIndex += 1;
                        bufferStoreOffset = 0;
                    }
                }
    
                return (offset - startingOffset);
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                if (disposed)
                {
                    throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                }
    
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        position = offset;
                        break;
    
                    case SeekOrigin.Current:
                        position += offset;
                        break;
    
                    case SeekOrigin.End:
                        position = length - 1 + offset;
                        break;
    
                    default:
                        throw new ArgumentException("Invalid SeekOrgin enumeration", "origin");
                }
    
                if (position < 0 || position >= length)
                {
                    throw new ArgumentOutOfRangeException("0 <= (offset + orgin) < stream.Length");
                }
    
                return position;
            }
    
            public override void SetLength(long value)
            {
                throw new System.NotImplementedException();
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                if (disposed)
                {
                    throw new ObjectDisposedException(typeof(NonContiguousMemoryStream).ToString());
                }
    
                if (buffer == null)
                {
                    throw new ArgumentNullException("buffer");
                }
    
                if (offset < 0 || offset >= buffer.Length)
                {
                    throw new ArgumentOutOfRangeException("offset", offset, "0 <= offset < buffer.Length");
                }
    
                if (count < 0 || count > buffer.Length)
                {
                    throw new ArgumentOutOfRangeException("count", count, "0 <= count < buffer.Length");
                }
    
                if ((offset + count) > buffer.Length)
                {
                    throw new ArgumentOutOfRangeException("offset + count", (offset + count), 
                        "(offset + count) <= buffer.Length");
                }
    
                while ((position + count) > (buffersStore.Count * bufferStoreSize))
                {
                    buffersStore.Add(new byte[bufferStoreSize]);
                }
    
                int end = offset + count;
                int buffersStoreIndex = (int)(position / bufferStoreSize);
                int bufferStoreOffset = (int)(position % bufferStoreSize);
    
                while (offset < end)
                {
                    byte[] bufferStore = buffersStore[buffersStoreIndex];
                    int run = Math.Min(end - offset, bufferStoreSize - bufferStoreOffset);
                    Buffer.BlockCopy(buffer, offset, bufferStore, bufferStoreOffset, run);
                    offset += run;
                    bufferStoreOffset += run;
    
                    if (bufferStoreOffset == bufferStoreSize && offset < end)
                    {
                        buffersStoreIndex += 1;
                        bufferStoreOffset = 0;
                    }
                }
    
                position += count;
    
                if (position > length)
                {
                    length = position;
                }
            }
    
            protected override void Dispose(bool disposing)
            {
                if (disposed == false)
                {
                    disposed = true;
                    base.Dispose(disposing);
                }
            }
        }
    }
