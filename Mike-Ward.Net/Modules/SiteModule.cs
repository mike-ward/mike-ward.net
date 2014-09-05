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
            Get["/freesnap"] = p => View["freesnap"];
            Get["/calendar"] = p => View["calendar"];
            Get["/gadgets"] = p => View["gadgets"];
            Get["/calendargadget"] = p => View["calendargadget"];
            Get["/downloads"] = p => View["downloads"];
            Get["/about"] = p => View["about"];
        }
    }
}