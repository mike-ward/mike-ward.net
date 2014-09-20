using System;
using Mike_Ward.Net.Modules;
using Nancy;
using Nancy.Conventions;
using Nancy.Pile;

namespace Mike_Ward.Net
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Clear();
            nancyConventions.StaticContentsConventions.AddDirectory("cdn/static");
            nancyConventions.StaticContentsConventions.AddDirectory("cdn/downloads");
            nancyConventions.StaticContentsConventions.AddDirectoryWithExpiresHeader("cdn/images", TimeSpan.FromDays(365));
            nancyConventions.StaticContentsConventions.StyleBundle("cdn/styles.css", new[] { "css/pure-min.css", "css/*.css" });
            nancyConventions.StaticContentsConventions.ScriptBundle("cdn/scripts.js", new[] { "*.js" });
        }
    }
}