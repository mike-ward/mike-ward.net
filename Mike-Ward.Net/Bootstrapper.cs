using System;
using Nancy.Blog;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Pile;
using Nancy.TinyIoc;

namespace Mike_Ward.Net
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var blog = new Blog
            {
                Title = "Mike-Ward.Net",
                Description = ".NET, Technology, Life, Whatever",
                BaseUri = new Uri("http://localhost:12116/blog"),
                Author = "Mike Ward",
                Langauge = "en-US",
                Copyright = "Copyright (C) 2014 - Mike Ward"
            };
            container.Register<IBlog>(blog);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.StyleBundle("styles.css",
                new []
                {
                    "css/pure-min.css",
                    "css/*.css"
                });

            nancyConventions.StaticContentsConventions.ScriptBundle("scripts.js",
                new []
                {
                    "*.js"
                });
        }
    }
}