namespace Mike_Ward.Net
{
    using Nancy;

    public class SiteModule : NancyModule
    {
        public SiteModule()
        {
            Get["/"] = p => Response.AsRedirect("~/blog");
            Get["/tweetz"] = p => View["tweetz"];
            Get["/vscoloroutput"] = p => View["vscoloroutput"];
        }
    }
}