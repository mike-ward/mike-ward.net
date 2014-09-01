Including JavaScript Conditionally in ASP.Net
2006-09-15T12:53:56
In the course of building this Web site I've wanted several JavaScripts I use for ads and hit counting to be disabled when I'm developing locally on my laptop. I looked for more than a few minutes and couldn't get a definitive answer which was a bit surprising (read annoying). Some suggested using Asp:Literal, others said that code-behind was the only way. I found an easier way. Maybe this is obvious to all you old-time ASP.Net hacks but it certainly didn't jump out at me.

The trick is to use something called a render block. You can look it up in the help for more details. There are limits to what you can do with render blocks but then anything significantly complex shouldn't be done in a render block in the first place. In my case, I wanted to suppress a hit counter script when running locally. Here's what I came up with.
    
    <%@ Page Language="C#" %>  
    <% if (Request.IsLocal == false)  
        { %>  
          <script src="myscript.js" type="text/javascript"></script>  
    <%  } %>

The page directive goes at the top of the page. The render blocks are the portions between the <% %> delimiters.
