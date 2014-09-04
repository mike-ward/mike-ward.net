namespace Mike_Ward.Net
{
    using Nancy;

    public class SiteModule : NancyModule
    {
        public SiteModule()
        {
            Get["/"] = p => Response.AsRedirect("~/blog");
            Get["/vscoloroutput"] = p => View["vscoloroutput"];
        }
    }
}