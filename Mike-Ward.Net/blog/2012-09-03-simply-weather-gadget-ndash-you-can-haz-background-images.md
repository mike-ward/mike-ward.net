Simply Weather Gadget &ndash; You can Haz Background Images
2012-09-03T12:36:59
In addition to custom colored backgrounds, you can also use an image for the background. It's super tricky to do this so I want you to read these directions carefully.

> Drag and drop an image from Windows Explorer onto the gadget

OK, so it isn't tricky. There are some limitations (aren't there always?). Images larger than 150 x 250 will be cropped (upper-left corner). Images are not scaled. Smaller images are tiled.

I find backgrounds with subtle transitions look best. Here's the gadget with the image of a blue sky at sunset. The image is much bigger than the gadget but the gradation of the sky in the upper-left corner is just right.

![sw](http://az667460.vo.msecnd.net/cdn/images/blog/Simply-Weather-Gadget--You-can-Haz-Backg_CB78/sw.png)

Available on the [downloads page](/downloads).

I've also put together a [starter-set of images](/downloads/bgs.zip) for use as backgrounds.

Recap: Google recently turned off their weather API, the one that Simply Weather used. It was really the best of the free weather API's in that it had worldwide support and provided translations for 80 different languages. I've since migrated to Microsoft's MSN weather API. It's the only free weather API with 3 day forecasts (4 in MSN's case). It however lacks the international support both in number of reporting stations and language translations that the Google weather API had.

I don't fault Google or any other service provider for removing support. Acquiring and maintaining weather data costs money and you can't expect providers to give their data away for free. The fact that MSN supplies as much data as it does is a gift.

If you live in the United States, you won't see much of a difference. Outside the United States, the coverage is spotty (the US is one of the few governments that supplies weather data for free). I've looked into the Weather Underground's API (I suspect this is what Google used since the features are so similar). I have no idea how much data the gadget pulls worldwide but I'm guessing it would cost between $100 to $300 per month based on their rate schedule.

After updating the API, I made some other improvements.

Tooltips: It seems like a simple thing but really it isn't. The old "browser based" tooltips were nice but they only worked when the gadget had input focus (you had to click on the gadget first). This has always bugged me. There are jQuery tooltip plugins but they don't work well in the confined spaces of a gadget. In the end, I heavily modified some code I found in a blog article. It works just like it should but believe me when I say there are many hours that went into it. It's the seemingly simple stuff that is sometimes the hardest.

Background/Foreground colors: I would get an email about once a week begging me for more background colors. Now you can pick anyone that suits you. Adding this feature required the removal of the rounded corners on the background. If anyone complains I just tell them it's the new modern Windows 8 look :)

Image backgrounds: Images can make nice backgrounds so I added it. The drag and drop logic to do this is remarkably simple but requires a "trick" in order to make it work in gadgets. It took quite a few hours to run this one down. 

Feels Like Temperature and Observation Time: MSN's API provides this data so I added it the gadget (hover your mouse cursor over current temperature)

Alerts: The new API indirectly gives me access to alerts, watches and warnings. It does not give me access to advisories. I could pull those from the National Weather Service but their API does not work with zip codes. You need a FIPS code (you don't want to know).

So there you have it. A seemingly simple gadget with a fair bit of research behind it. Finding resources and getting things "just right" is harder than it looks. Fortunately, I enjoy programming so I'm not complaining.

Enjoy the gadget, send me feedback and please include the location you entered into the gadget when reporting problems.
