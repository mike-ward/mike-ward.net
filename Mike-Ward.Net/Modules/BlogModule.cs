using Nancy;
using Nancy.Blog;

namespace Mike_Ward.Net.Modules
{
    public class BlogModule : NancyModule
    {
        public BlogModule(IBlog blog)
        {
            Get["/blog"] = p => View["blog"];
        }
    }
}