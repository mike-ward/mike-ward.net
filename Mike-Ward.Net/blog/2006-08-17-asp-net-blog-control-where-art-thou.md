ASP.Net blog control, Where art thou?
2006-08-17T00:43:21
One of the things I needed for the new site is a blog. Now there are lots of way to blog these days from custom software to services. However, I wanted something that would integrate with my site. I also wanted to have access to the data store. Oddly, however, there is not much in the way of free Asp.Net blogging components. This strikes me as odd since it is a relatively easy thing to write.

So, not having anything available I did what any programmer in my situation does - write one myself. Since my needs are modest when it comes to blogging I implemented a minimal set of features. I needed to add and edit articles, accept comments, produce an index and syndicate a feed. Also, since I'm not what you call a prolific writer, a simple file based storage system should suffice. Over the next half dozen entries or so, I'll discuss my journey and some of the cool things I discovered about Asp.Net.

To begin with (sounds like the opening to some famous novel) I need to store data. I'm not really into databases unless I really need them and so I went with an XML file. No surprise here. XML is a machine readable format and .Net has excellent support. The real question of course is how to read and write the XML?

There again are many options but I went for the easiest and most straightforward solution which was to read and write the file in its entirety. Yeah, I know this is not efficient and all that but frankly, until I get 500 or 1000 entries, it just doesn't take all the much horsepower to read and write the entire file.

Also, I don't like to think in terms of XML per-se. It's just a serialization methodology and so I don't want to have XML references littered all over my code. Instead, I like to think in terms of object models.

And so that's where we'll begin. A blog is really just a collection of articles and maybe some comments about those articles. You could spice it up with categories and such but that's what a good search is for in my opinion. So let's write a blog class.
    
    public class Blog  
    {  
      string title;  
      string description;  
      ArticleCollection articles;
    
      public string Title  
      {  
        get { return title; }  
        set { title = value; }  
      }
    
      public string Description  
      {  
        get { return description; }  
        set { description = value; }  
      }
    
      public ArticleCollection Articles  
      {  
        get { return articles; }  
        set { articles = value; }  
      }
    
      public void Save(Stream stream)  
      {  
        XmlSerializer xs = new XmlSerializer(typeof(Blog));  
        xs.Serialize(stream, this);  
      }
    
      static public Load(Stream stream)  
      {  
        XmlSerializer xs = new XmlSerializer(typeof(Blog));  
        return (Blog)xs.Deserialize(stream);  
      }   
    }

OK, I left a lot of stuff out like error checking and never mind what the ArticleCollection object is just yet. What's interesting about all this is that all the reading and writing of XML is done in about 4 lines of code. The XML emitted and read by these lines hides all the difficult tasks serializing/deserializing the object to and from XML. You can read more about XmlSerializers in the MSDN online help and else where (just Google it). 

Next time I'll discuss the mysterious ArticleCollection object and how XmlSerializers work with collections.
