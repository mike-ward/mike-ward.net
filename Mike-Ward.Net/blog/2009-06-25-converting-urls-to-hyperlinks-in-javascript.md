Converting URLs to Hyperlinks in JavaScript
2009-06-25T02:14:18
I hunted around for a JavaScript method to convert URLs in a text stream to hyperlinks and came up short. I wrote this quickie method that works for the limited data I’ve thrown at it. There are likely more robust methods but darn if I could find one.
    
    function convertUrlsToLinks(text)
    {
        var matchUrl = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/gi
        return text.replace(matchUrl, '[<a href="$&">$&</a>]($&)');
    }

OK, JavaScript guru’s. Is there a better way?
