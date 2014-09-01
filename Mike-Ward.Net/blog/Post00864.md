Async Event Handlers in C#
2013-09-25T14:28:25
Recently, C# added a nifty [async/await](http://msdn.microsoft.com/en-us/library/vstudio/hh191443.aspx) facility. I have not used it extensively due to the new and unfamiliar _async/await_ declarations. I'm slowly warming up to it however. Here's a two-liner that speaks volumes to the expressiveness of the _aysnc/await_.
    
        hyperlink.ToolTip = link;  
        hyperlink.ToolTipOpening += async (s, e) => hyperlink.ToolTip = await LongUrl.Lookup(link);

  


This works beautifully. The tooltip on the hyperlink opens immediately with the shortened URL (_link_). The handler then tries to find the original URL that the shortened URL resolves to using an online service (once the long URL is found, it's cached). When the long URL is resolved the tooltip instantly updates.

It can take several seconds to resolve this so a blocking operation is not appropriate. With the _async/await_ keywords, it reads like a synchronous operation, but works asynchronously. 

The _LongUrl.Lookup_ method needs to be marked _async_ as well. Here's the implementation for reference.
    
        public static class LongUrl  
        {  
            private static readonly ConcurrentDictionary<string, string> ShortToLongUrl =   
                new ConcurrentDictionary<string, string>();  
      
            public async static Task<string> Lookup(string link)  
            {  
                try  
                {  
                    string longUrl;  
                    if (ShortToLongUrl.TryGetValue(link, out longUrl))  
                    {  
                        return longUrl;  
                    }  
      
                    var url = "http://api.longurl.org/v2/expand?format=json&url=" + OAuth.UrlEncode(link);  
                    var request = WebRequestWrapper.Create(new Uri(url));  
                    request.UserAgent = "tweetz/5.0";  
                    request.Timeout = 1500;  
                    using (var response = await request.GetResponseAsync())  
                    {  
                        var serializer = new DataContractJsonSerializer(typeof (LongUrlResponse));  
                        var longUrlResponse =   
                            (LongUrlResponse)serializer.ReadObject(response.GetResponseStream());  
                        if (string.IsNullOrWhiteSpace(longUrlResponse.LongUrl) == false)  
                        {  
                            if (ShortToLongUrl.Count > 1000) ShortToLongUrl.Clear();  
                            ShortToLongUrl.TryAdd(link, longUrlResponse.LongUrl);  
                            return longUrlResponse.LongUrl;  
                        }  
                    }  
                }  
                catch (Exception ex)  
                {  
                    Console.WriteLine(ex.Message);  
                }  
                return link;  
            }  
        }  
      
        [DataContract]  
        public class LongUrlResponse  
        {  
            [DataMember(Name = "long-url")]  
            public string LongUrl { get; set; }  
        }

  
At compile time, the async/await mechanism injects a significant chunk of code in the form of a state machine to handle waiting for a response. In many cases this a fair tradeoff given the economy of expression and "serial-like" layout of code.
