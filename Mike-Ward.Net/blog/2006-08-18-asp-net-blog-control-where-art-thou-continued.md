ASP.Net Blog Control, Where art thou? (continued)
2006-08-18T00:45:15
In[ part one](/BlogArticle.aspx?articleId=6d08d1d4-3a79-4ae4-9b3f-ada86eda4471) I discussed some of my motivation for writing my own blog software, not the least of which I'm cheap. But really, it's not all that hard once you know you're way around .Net. Perhaps the hardest part of .Net is just getting to know the breath and depth of the .Net library. Part one introduced you to XmlSerializer, a quick and easy way to serialize an object to XML and back again. But the object model was incomplete so let's fill that in and introduce a few new .Net 2.0 concepts along the way.

Remember the ArticleCollection class that was embedded in the Blog class from part one? Well, not surprisingly, it's a collection of BlogArticles. Here's the class.

public class BlogArticle  
{  
private Guid id = Guid.NewGuid();  
private string title = "New Article";  
private DateTime date = DateTime.Now;  
private string article;  
private BlogCommentCollection comments;

public Guid Id  
{  
get { return id; }  
set { id = value; }  
}

public string Title  
{  
get { return title; }  
set { title = value; }  
}

public DateTime Date  
{  
get { return date; }  
set { date = value; }  
}

public string Article  
{  
get { return article; }  
set { article = value; }  
}

public BlogCommentCollection Comments  
{  
get { return comments; }  
set { comments = value; }  
}  
}

Id member is a GUID. What's a GUID you say? Why it's a Global Unique Identifier. If you've ever programmed in COM (an earlier Microsoft technology filled with pain and loathing) you'll recognize the GUID. According to the documentation, it has a "very low probability of being duplicated." In this case low probability means not in this lifetime, or the next or the next million or so. There are lots of other ways to generate identifiers I suppose but this one is easy and I don't have to keep a counter around.

Title, date and article should be self explanatory and then there's another collection. This is just the collection of comments associated with the article. We'll explore comments later.

So that's one article, but of course our blog has multiple articles. Sounds like we need a collection and I've got just the ticket.

public class ArticleCollection : KeyedCollection<Guid, BlogArticle>  
{  
protected override Guid GetKeyForItem(BlogArticle item)  
{  
return item.Id;  
}  
}

Now we have two new things here. Generics and KeyedCollections. We'll start with the generics.

Generics let you tailor a method, class, structure, or interface to the precise data type it acts upon. In .Net 1.1, you would likely use an ArrayList for something like this. However, ArrayList offers no type safety, something we programmers desire. In effect, the generic lets us that a predefined behavior like maintaining things in a orderly list and apply it to a specific type. This has all sorts of advantages and saves you a few headaches along the way. You can read more on generics at MSDN or as always, just "Google it."

The KeyedCollection<> template is quite fun. There are lots of ways to keep lists of things. We could put in a plain old list. Problem with that is that we have to "walk" the list to find and item. A dictionary is another method. With a dictionary, we could access the article we want using the Id as a key to finding it. Better, but we end up keeping two lists. One for the keys and one for the articles. The KeyedCollection lies somewhere in between, acting like a dictionary but without the overhead.

KeyedCollections require an override to be implemented that identifies the key that is associated with the item (the article in this case). Since we generate a unique Id when we create a BlogArticle, it makes for a handy key for the KeyedCollection.

KeyedCollections have all the methods you would expect for a collection class like add, remove, and contains. And it shouldn't be a great leap to figure out what the BlogCommentCollection is all about. Here's the classes for BlogComment and BlogCommentCollection.

public class BlogComment  
{  
string author;  
string email;  
string comment;  
DateTime date = DateTime.Now;

public DateTime Date  
{  
get { return date; }  
set { date = value; }  
}

public string Author  
{  
get { return author; }  
set { author = value; }  
}

public string Email  
{  
get { return email; }  
set { email = value; }  
}

public string Comment  
{  
get { return comment; }  
set { comment = value; }  
}  
}

public class BlogCommentCollection : Collection<BlogComment>  
{  
}

And that pretty much rounds out the object model. A little basic yes, but then we're not writing a Blogger type service. Now I know some of you are thinking that I should have kept the comment collection separate and linked to it with the BlogArticle.Id. If I were doing a database backed design, I would agree, but heck, I just wanted to get the thing done and get back to other things (like finishing Calendar Gadget) and I really didn't want to deal with multiple files.

And what's cooler still, is that XmlSerializer understands this object model including the collections. That means as I add articles and comments, XmlSerializer keeps it all persisted in XML and I get to think only in terms of the object model.  

