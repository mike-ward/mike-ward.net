using System;
using System.Globalization;
using System.Linq;
using Nancy;
using Nancy.Blog;
using Nancy.Responses.Negotiation;

namespace Mike_Ward.Net.Modules
{
    public class BlogModule : NancyModule
    {
        public BlogModule(IBlog blog)
        {
            Get["blog/"] = p => ShowBlog(blog, 0);
            Get["blog/page/{index:int}"] = p => ShowBlog(blog, p.index);
            Get["blog/post/{year:int}/{month:int}/{day:int}/{slug:string}"] = p => ShowArticle(blog, p.year, p.month, p.day, p.slug);
            Get["blog/archive"] = p => ShowArchive(blog);
            Get["blog/rss"] = p => blog.Rss();
        }

        private Negotiator ShowBlog(IBlog blog, int index)
        {
            const int pageLength = 3;
            Context.ViewBag.Index = index;
            Context.ViewBag.PageLength = pageLength;
            Func<int, string> link = p => string.Format("{0}/page/{1}", blog.BaseUri, p);
            Context.ViewBag.Prev = link(Math.Max(index - pageLength, 0));
            Context.ViewBag.Next = link(Math.Min(blog.Posts.Count() - 1, index + pageLength));
            return View[blog];
        }

        private Negotiator ShowArticle(IBlog blog, int year, int month, int day, string slug)
        {
            const int pageLength = 1;
            Context.ViewBag.PageLength = pageLength;

            var post = blog.Posts
                .Select((p, i) => new {post = p, index = i})
                .FirstOrDefault(a =>
                    year == a.post.Created.Year &&
                    month == a.post.Created.Month &&
                    day == a.post.Created.Day &&
                    slug.Equals(a.post.Slug, StringComparison.InvariantCultureIgnoreCase));

            var index = post != null ? post.index : 0;
            Context.ViewBag.Index = index;
            var previous = blog.Posts.ElementAt(Math.Max(0, index - pageLength));
            var next = blog.Posts.ElementAt(Math.Min(blog.Posts.Count() - 1, index + pageLength));

            Func<Post, string> link = p => string.Format("{0}/post/{1}/{2}/{3}/{4}", 
                blog.BaseUri, p.Created.Year, p.Created.Month, p.Created.Day, p.Slug);

            Context.ViewBag.Prev = link(previous);
            Context.ViewBag.Next = link(next);
            return View[blog];
        }

        private Negotiator ShowArchive(IBlog blog)
        {
            return View["archive", blog.Posts
                .GroupBy(post => post.Created.Year)
                .ToDictionary(yg => yg.Key, yg => yg
                    .GroupBy(mg => mg.Created.Month)
                    .OrderByDescending(mg => mg.Key)
                    .ToDictionary(
                        mg => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mg.Key),
                        mg => mg.OrderByDescending(d => d.Created)))
                ];
        }
    }
}