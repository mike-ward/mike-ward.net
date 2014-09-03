using System;
using System.IO;
using System.Linq;
using Nancy;
using Nancy.Blog;

namespace Mike_Ward.Net.models
{
    public interface IBlogModel
    {
        IBlog Blog { get; }
    }

    public class BlogModel : IBlogModel
    {
        public IBlog Blog { get; private set; }

        public BlogModel(IBlog blog, IRootPathProvider rootPathProvider)
        {
            Blog = blog;
            blog.Title = "Mike-Ward.Net";
            blog.Description = ".NET, Technology, Life, Whatever";
            blog.BaseUri = new Uri("http://localhost:12116/blog");
            blog.Author = "Mike Ward";
            blog.Langauge = "en-US";
            blog.Copyright = "Copyright (C) 2014 - Mike Ward";
            blog.Posts = Directory.GetFiles(Path.Combine(rootPathProvider.GetRootPath(), "Blog/"), "*.md")
                .Select(file => Post.Read(File.OpenRead(file)));
        }
    }
}