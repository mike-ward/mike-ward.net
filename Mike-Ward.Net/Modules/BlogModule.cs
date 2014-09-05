﻿using System;
using System.Globalization;
using System.Linq;
using Mike_Ward.Net.models;
using Nancy;
using Nancy.Responses.Negotiation;

namespace Mike_Ward.Net.Modules
{
    public class BlogModule : NancyModule
    {
        public BlogModule(IBlogModel model)
        {
            Get["blog/"] = p => ShowBlog(model, 0);
            Get["blog/page/{index:int}"] = p => ShowBlog(model, p.index);
            Get["blog/post/{year:int}/{month:int}/{day:int}/{slug}"] = p => ShowArticle(model, p.year, p.month, p.day, p.slug) ?? 404;
            Get["blog/archive"] = p => ShowArchive(model);
            Get["blog/rss"] = p => model.Blog.Rss();
        }

        private Negotiator ShowBlog(IBlogModel model, int index)
        {
            const int pageLength = 3;
            Context.ViewBag.Index = index;
            Context.ViewBag.PageLength = pageLength;
            Func<int, string> link = p => string.Format("{0}/page/{1}", model.Blog.BaseUri, p);
            Context.ViewBag.Prev = link(Math.Max(index - pageLength, 0));
            Context.ViewBag.Next = link(Math.Min(model.Blog.Posts.Count() - 1, index + pageLength));
            return View[model];
        }

        private Negotiator ShowArticle(IBlogModel model, int year, int month, int day, string slug)
        {
            const int pageLength = 1;
            Context.ViewBag.PageLength = pageLength;

            var post = model.Blog.Posts
                .Select((p, i) => new {post = p, index = i})
                .FirstOrDefault(a =>
                    year == a.post.Created.Year &&
                    month == a.post.Created.Month &&
                    day == a.post.Created.Day &&
                    slug.Equals(a.post.Slug, StringComparison.InvariantCultureIgnoreCase));

            if (post == null) return null;

            var index = post.index; 
            Context.ViewBag.Index = index;
            var previous = model.Blog.Posts.ElementAt(Math.Max(0, index - pageLength));
            var next = model.Blog.Posts.ElementAt(Math.Min(model.Blog.Posts.Count() - 1, index + pageLength));

            Context.ViewBag.Prev = previous.PermaLink;
            Context.ViewBag.Next = next.PermaLink;
            return View[model];
        }

        private Negotiator ShowArchive(IBlogModel model)
        {
            return View["archive", model.Blog.Posts
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