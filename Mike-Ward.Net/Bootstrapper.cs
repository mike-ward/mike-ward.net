using Nancy;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.Pile;

namespace Mike_Ward.Net
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.StyleBundle("styles.css",
                new[]
                {
                    "css/pure-min.css",
                    "css/*.css"
                });

            nancyConventions.StaticContentsConventions.ScriptBundle("scripts.js",
                new[]
                {
                    "*.js"
                });
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration { Password = @"GizmoGlen90" }; }
        }
    }
}