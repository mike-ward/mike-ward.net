using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Nancy.Markdown.Blog;

namespace Mike_Ward.Net.models
{
    public interface IBlogModel
    {
        IBlog Blog { get; }
    }

    public class BlogModel : IBlogModel, IDisposable
    {
        public IBlog Blog { get; private set; }
        private readonly FileSystemWatcher _fileSystemWatcher;
        private bool _disposed;

        public BlogModel(IBlog blog, IRootPathProvider rootPathProvider)
        {
            Blog = blog;
            blog.Title = "Mike-Ward.Net";
            blog.Description = ".NET, Technology, Life, Whatever";
            blog.BaseUri = new Uri("http://localhost:12116/blog");
            blog.Author = "Mike Ward";
            blog.Langauge = "en-US";
            blog.Copyright = "Copyright (C) 2014 - Mike Ward";

            var path = Path.Combine(rootPathProvider.GetRootPath(), "Blog/");
            blog.Posts = ReadPosts(path);

            _fileSystemWatcher = new FileSystemWatcher(path) {NotifyFilter = NotifyFilters.LastWrite};
            _fileSystemWatcher.Changed += (sender, args) => ReadPosts(path);
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private static IEnumerable<Post> ReadPosts(string path)
        {
            return Directory
                .GetFiles(path, "Post*.md")
                .Select(file => Post.Read(File.OpenRead(file)));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            _fileSystemWatcher.Dispose();
        }
    }
}