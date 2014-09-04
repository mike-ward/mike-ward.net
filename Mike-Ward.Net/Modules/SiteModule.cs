namespace Mike_Ward.Net
{
    using Nancy;

    public class SiteModule : NancyModule
    {
        public SiteModule()
        {
            Get["/"] = p => Response.AsRedirect("~/blog");
            Get["/deskdrive"] = p => View["deskdrive"];
            Get["/tweetz"] = p => View["tweetz"];
            Get["/simplyweather"] = p => View["simplyweather"];
            Get["/vscoloroutput"] = p => View["vscoloroutput"];
        }
    }
}