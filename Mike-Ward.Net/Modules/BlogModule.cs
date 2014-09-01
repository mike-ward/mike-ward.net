using Nancy;

namespace Mike_Ward.Net.Modules
{
    public class BlogModule : NancyModule
    {
        public BlogModule()
        {
            Get["/blog"] = p => View["blog"];
        }
    }
}