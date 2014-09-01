using Nancy.Conventions;
using Nancy.Pile;

namespace Mike_Ward.Net
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.StyleBundle("styles.css",
                new []
                {
                    "css/pure-min.css"
                });
        }
    }
}