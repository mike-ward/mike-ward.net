Force jQuery 1.5 to always allow cross-site scripting
2011-02-02T01:41:07
[jQuery 1.5](http://jquery.com) has just been released and there’s lots of new goodness. Perhaps the most significant change is the new pluggable [Ajax](http://en.wikipedia.org/wiki/Ajax_(programming)) module. However, when I added jQuery 1.5 to my [tweetz](/tweetz) sidebar gadget, it no longer worked. Stranger still was the Ajax error message: “No Transport”. What did that mean? 

Puzzled, I did a bit of code spelunking and found that jQuery tests to see if [cross-site scripting](http://en.wikipedia.org/wiki/Cross-site_scripting) is allowed. Gadgets use the IE engine which blocks cross-site scripting under normal browser conditions. Gadgets however allow cross-site scripting and likely tweak something in the IE engine to enable it to do so.

The jQuery Ajax method does have a parameter (`crossDomain: true`) that enables cross-site scripting. Unfortunately, adding this switch had no affect. jQuery doesn’t directly support Windows 7 gadgets, which is perhaps why this switch didn’t work.

So back to the code. A bit more spelunking and I found where the test for cross-site scripting was made. Cross-site scripting is controlled (in part) by the `jQuery.support.cors` variable. Adding the following to my gadget fixed the issue.
    
    jQuery.support.cors = true; // force cross-site scripting (as of jQuery 1.5)

The “No Transport” error appears to be a catch-all message meaning, “I couldn’t find a method to send your request”. A bit obtuse of an error message perhaps. Good thing there was source to examine.
