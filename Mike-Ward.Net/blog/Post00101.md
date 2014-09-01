Blog Rolls Automated
2007-01-04T03:12:55
On many blogs, including this one, you’ll see a list of blogs the blog author subscribes to. This is commonly referred to as a “Blog Roll”. Many blogging engines include builtin support for blog rolls. I considered adding this to Bloget at one point but it runs counter to the Bloget’s design philosophy. Bloget’s design is a bit different than other blogging engines in that it supplies the parts to create a blog, but leaves the implementation up to developer. This “do it yourself” approach has advantages and disadvantages. The advantage of course is that Bloget can be implemented into existing sites with minimal effort. The disadvantage is that you have to supply the Web site pages and layout.

So when it came time to add a blog roll to this site, I thought about supplying a blog roll control. Except that in ASP.NET they already supply one – almost. 

Enter the **** Web server control. This little gem transforms an XML file to HTML using an XSL transform. Now don't run away just yet if you're not familiar with these terms. We'll go through it a step at a time.

If you're into reading blogs, then you're likely using some kind of [aggregator](http://en.wikipedia.org/wiki/News_aggregator) (a.k.a news reader). I'm a fan of [Bloglines.com](http://bloglines.com) but there are many others including [Google Reader](http://www.google.com/reader), [Yahoo](http://www.yahoo.com), etc. Off line readers exist as well like [Great News](http://www.curiostudio.com/) and [Feed Demon](http://www.newsgator.com/NGOLProduct.aspx?ProdId=FeedDemon). Just about every one of these tools will export the blogs you're reading into an XML file. This file follows a standard format called [OPML](http://www.opml.org/about) (Outline Processor Markup Language). And since it's a standard format and it's in XML, we can do a little processing to turn it into something suitable for display on a Web page.

What's needed is something that will read your OPML file and emit HTML. This is where XSL Transforms come into the picture. XSL (Extensible Stylesheet Language) can apply transformation rules to an XML file creating an entirely new file that is a "transformed" version of the original XML file. 

Sounds tricky, and it can be, but because OPML is such a simple format, writing an XSL transform to convert it to HTML is also simple. Here's the one I use for this Web site.

<xml version ="1.0"encoding="utf-8"?>  
<xsl:stylesheet version="1.0" xmlns:xsl=[http://www.w3.org/1999/XSL/Transform](http://www.w3.org/1999/XSL/Transform)>  
<xsl:output method="html" indent="yes"/>  
<xsl:template match="opml">  
<xsl:for-each select="body/outline">  
<a href="{@htmlUrl}"><xsl:value-of select="@text"/>a><br/>  
</xsl:for-each>  
</xsl:template>  
</xsl:stylesheet>

Most of this code is just boiler plate needed to specify that it is an XSL template. The interesting bit is in the middle of the code.

< a href ="{@htmlUrl}"><xsl:value-of select="@text"/></>a><br/>

Now this isn't so bad. We're just building a link and adding a line break. The **{@htmlUrl}** and **@text** portions are substituion parameters. This template just loops through the OPML file and for each entry it encounters it replaces the **@htmlUrl** parameter with the blog's URL and the **@text** parameter with the blog's title. Changing the format to suit your tastes is easy. Let's say you want to make it bold.

**<b><** **a** **href** **=** **"{@htmlUrl}"><xsl:value-of select="@text"/></a></b>**<br/>

I think you see the point. Save this code to a file and call it something interesting like BlogRoll.xsl.

All that's left is to choose where to put place our blog roll on the page. Here's where the **** server control comes in. As you can see below, the **** server control takes two parameters. The **DocumentSource** is your exported OPML file, and the **TransformSource** is the XSL file you saved. Add this to your page.

< asp : Xml ID ="XmlBlogRoll" runat ="server"   
DocumentSource="~/App_Data/export.xml"   
TransformSource="~/BlogRoll.xsl" />  
  


When you display the page, you should see your blog roll. Now this was perhaps a bit of work but now you have a data driven blog roll. Anytime you want to update your blog roll, go to your news reader, export your blog roll to a file, and upload it.
