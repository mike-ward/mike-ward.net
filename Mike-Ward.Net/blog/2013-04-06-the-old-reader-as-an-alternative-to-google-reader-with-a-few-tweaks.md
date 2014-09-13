The Old Reader as an Alternative to Google Reader (with a few tweaks)
2013-04-06T15:24:16
Since Google’s announcement that it’s [killing it’s awesome Google Reader](http://googlereader.blogspot.com/2013/03/powering-down-google-reader.html), I’ve been looking for an alternative. [The Old Reader](https://theoldreader.com) has a similar feel and includes the social bookmarks that Google elminated a few years ago from it’s reader. Like other readers, it has a few issues but it fits well enough with my style of use.

There are however, some layout issues I find annoying. The font is too small, images don’t flow well with text, the colors are distracting and the page width is too wide. Fortunately, these are all easily corrected with a user style sheet. If you’re using Google Chrome, there’s an extension called [Stylish](http://userstyles.org/), that allows you to inject your own style sheet into a web site.

In about 5 minutes I took care of the issues with the following style-sheet. It’s not extensive and addresses only the content area of the web site but it does make it feel a bit more like Google Reader.
    
    body { font-family: verdana; font-size: 14px; }
    div.post { width: 728px; line-height: 20px; }
    div.post .label-feed { background-color: #f9f9f9; color: #333; text-shadow: none;  }
    div.content img { display: block; }
    div.content a { color: #448; }
    
