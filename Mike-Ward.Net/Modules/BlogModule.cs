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
            Get["blog/{index:int}"] = p => ShowBlog(blog, p.index);
            Get["blog/{slug}"] = p => ShowArticle(blog, p.slug);
            Get["blog/archive"] = p => ShowArchive(blog);
            Get["blog/rss"] = p => blog.Rss();
        }

        private Negotiator ShowBlog(IBlog blog, int index)
        {
            const int pageLength = 3;
            Context.ViewBag.Index = index;
            Context.ViewBag.PageLength = pageLength;
            Context.ViewBag.Prev = blog.BaseUri + Math.Max(index - pageLength, 0).ToString(CultureInfo.InvariantCulture);
            Context.ViewBag.Next = blog.BaseUri + Math.Min(blog.Posts.Count() - 1, index + pageLength).ToString(CultureInfo.InvariantCulture);
            return View[blog];
        }

        private Negotiator ShowArticle(IBlog blog, string slug)
        {
            const int pageLength = 1;
            Context.ViewBag.PageLength = pageLength;
            var index = blog.IndexFromSlug(slug);
            Context.ViewBag.Index = index;
            Context.ViewBag.Prev = blog.BaseUri + blog.Posts.ElementAt(Math.Max(0, index - pageLength)).Slug;
            Context.ViewBag.Next = blog.BaseUri + blog.Posts.ElementAt(Math.Min(blog.Posts.Count() - 1, index + pageLength)).Slug;
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