using System;
using System.Collections.Generic;
using Nancy;
using Nancy.Conventions;

namespace Mike_Ward.Net.Modules
{
    public static class StaticContentConventionHelper
    {
        public static void AddDirectoryWithExpiresHeader(
            this IList<Func<NancyContext, string, Response>> conventions,
            string requestedPath,
            TimeSpan expiresTimeSpan,
            string contentPath = null,
            params string[] allowedExtensions)
        {
            var responseBuilder = StaticContentConventionBuilder.AddDirectory(requestedPath, contentPath, allowedExtensions);
            conventions.Add((context, root) =>
            {
                var response = responseBuilder(context, root);
                if (response != null)
                {
                    response.Headers.Add("Expires", DateTime.Now.Add(expiresTimeSpan).ToString("R"));
                }
                return response;
            });
        }
    }
}