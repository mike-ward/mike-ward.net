Tweetz Update
2012-10-18T00:38:14
[![Twitter_Fail_Cisco (Mobile)](/content/images/blog/Tweetz-Update_11BD7/Twitter_Fail_Cisco-Mobile_thumb.jpg)](/content/images/blog/Tweetz-Update_11BD7/Twitter_Fail_Cisco-Mobile.jpg)Many of you have been experiencing issues with tweetz not working over the last several days. The reason was that twitter started shutting off access to their data via their version 1.0 API. I don’t follow the API changes as closely as as should. I’ve migrated tweetz to use the newer 1.1 version of the twitter API. Things appear to be working again.

The new API has more restrictions than the old API. Without going into details, you’re basically limited to 15 API calls per 15 minute window. That limitation is per time line (more or less) and does not include posting new tweets (you get 15 posts per 15 minute window for posts). An easy way to think of this is that the gadget can make one API call for each timeline once a per minute. API requests made after the rate limit is exceeded are rejected.

At first this doesn’t sound so bad but the limit is per user, not per instance. If you have two instances of tweetz running you don’t get 15 requests for one instance and 15 for the other, you get 15, period. Leave a version of tweetz running on another computer (like at the office) and that counts against your rate limit. The limit is “Per User” and they mean it.

Because it’s so easy to exceed your rate limit, I’ve added a new color to the status indicator. When your rate limit is exceed the indicator turns blue (the dot in the upper right corner of the gadget). Some how, blue just seems like the appropriate color in this case.

There were some issues with posting tweets after I migrated the gadget to the new API. I’ve since fixed them. The current version is 3.1.6.1 and is available on the [downloads page](/downloads).

I mentioned earlier that I’m working on a standalone desktop version of tweetz for Windows 8 because Windows 8 will not support gadgets. It’s coming along but I don’t think it will be ready on October 26th when Windows 8 launches. Desktop applications are harder to write. However, the new desktop client will be able to take advantage of the streaming version of the twitter API which will mostly fix the rate limits of current API.
