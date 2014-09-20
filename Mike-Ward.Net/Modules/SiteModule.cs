using Nancy.Responses;
using Nancy.Responses.Negotiation;

namespace Mike_Ward.Net
{
    using Nancy;

    public class SiteModule : NancyModule
    {
        public SiteModule()
        {
            Get["/deskdrive"] = p => CreateView("deskdrive");
            Get["/tweetz"] = p => CreateView("tweetz");
            Get["/tweetz-help"] = p => CreateView("tweetz-help");
            Get["/simplyweather"] = p => CreateView("simplyweather");
            Get["/vscoloroutput"] = p => CreateView("vscoloroutput");
            Get["/freesnap"] = p => CreateView("freesnap");
            Get["/calendar"] = p => CreateView("calendar");
            Get["/gadgets"] = p => CreateView("gadgets");
            Get["/calendargadget"] = p => CreateView("calendargadget");
            Get["/downloads"] = p => CreateView("downloads");
            Get["/about"] = p => CreateView("about");
            Get["/installmonetizer"] = p => CreateView("installmonetizer");
            Get["/robots.txt"] = p => new GenericFileResponse("robots.txt");

            Get["/download/{cg?}/{file}"] = p =>
            {
                ViewBag.File = (p.cg != null) ? p.cg + "/" + p.file : p.file;
                return CreateView("download");
            };
        }

        private Negotiator CreateView(string viewName)
        {
#if !DEBUG
            ViewBag.BaseCdnUri = "http://az667460.vo.msecnd.net/";
#endif
            return View[viewName];
        }
    }
}