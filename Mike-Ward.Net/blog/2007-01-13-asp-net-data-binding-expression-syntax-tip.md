ASP.NET Data Binding Expression Syntax Tip
2007-01-13T16:28:50
[Bloget™](/bloget) uses ASP.NET's built in [template syntax](http://msdn2.microsoft.com/en-us/library/ms178657.aspxTemplated%20Server%20Control%20Example) for customization (other ASP.NET templated server controls include [Repeater](http://msdn2.microsoft.com/en-us/library/system.web.ui.webcontrols.repeater.aspx) and [GridView](http://msdn2.microsoft.com/en-us/library/system.web.ui.webcontrols.gridview.aspx)). It's one of those killer ASP.NET features (IMHO) that doesn't get enough press. Coupled with data binding, it makes for a formidable template system that I use to develop Bloget blogs. Recently however, I stumbled trying to do something seemingly simple. First, however, let's quickly review the [Data Binding Syntax](http://msdn2.microsoft.com/en-us/library/ms178366.aspx) in ASP.NET
    
    <asp:Hyperlink NavigateUrl='<%# Container.ItemPermaLink %>'  
      runat="server">permalink</asp:HyperLink>

This is an example from a Bloget template I'm developing. The **<%# %>** contains a _data binding expression_. The **Container** is the naming container that Bloget is hosted in and is the standard way to access data bound objects in a template. When the template is realized, **Container.ItemPermaLink** will expand to the actual permalink for the item. So far so simple.

Where I stumbled was when I wanted to build a custom link to Digg, a popular bookmarking site. The format of the URL to submit a link is as follows:
    
    http://digg.com/submit?phase=2&url=<link>&title=<title>

The <link> and <title> portions are replaced by the link and title of the blog article at runtime. The documentation for [Data Binding Expressions](http://msdn2.microsoft.com/en-us/library/ms178366.aspx) and every [example](http://msdn2.microsoft.com/en-us/library/95k0273d.aspx) I could find suggest that only a _data binding expression_ can be contained in the **<%# %>** portion. Well I'm here to say it ain't so! You can actually use C# (or VB) in these expressions. It may be common knowledge, but if it is, I couldn't find it. Armed with this new knowledge, it becomes straightforward to build the link.
    
    <asp:HyperLink NavigateURL='<%# string.Format(  
      "http://digg.com/submit?phase=2&amp;url={0}&amp;title={1}",  
      Container.ItemPermaLink, Container.ItemTitleUrlEncoded) %>'  
      runat="server">Digg this!</asp:HyperLink>

This works fine in ASP.NET 2.0. I don't use ASP.NET 1.1 so your mileage may vary.

Technorati tags: [ASP.NET](http://technorati.com/tags/ASP.NET), [C#](http://technorati.com/tags/C#), [Bloget](http://technorati.com/tags/Bloget)
