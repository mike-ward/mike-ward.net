Creating Custom Configuration Sections in Web.config
2013-04-24T16:55:00
> Most ASP.Net web applications have some amount of configuration. In ASP.Net you can add configuration settings to the Web.config under the _<appSettings>_ section. Here's an example:
    
    <appSettings>  
        <add key="name" value="Mike" />  
    </appSettings>

  


Configuration settings can be retrieved as follows:
    
    ConfigurationManager.AppSettings["name"]

  


If you only have a handful of settings, _<appSettings>_ is convenient and easy. However, there is no schema to enforce compliance and specifying collections is awkward. It also quickly becomes unwieldy as the number of settings grows. I've seen projects resort to naming conventions to keep things orderly. There's a better way.

Custom configuration sections allow for a more rigorous specification of configuration settings and can include default and required values. IntelliSense support is also enabled. Here's an example of my blog configuration.
    
    <BlogConfiguration   
      title="Mike Ward's Technology Blog"   
      description=".Net, Technology, Life, Whatever... "   
      link="/blog"   
      images="/cdn/images/blog"   
      postsPerPage="4"   
      adsPerPage="2"   
      email="mike@mike-ward.net"   
      firstname="Mike"   
      lastname="Ward"   
      copyright="Copyright (c) 2013 Mike Ward - All rights reserved"   
      timezone="Eastern Standard Time"   
      dateformat="MMMM d, yyyy"   
      username="bla"   
      password="bla-bla-bla">  
      <categories>  
        <add id="0" title=".Net" description="Microsoft .Net Technlogies" />  
        <add id="1" title="ASP.Net" description="Microsoft ASP.Net Technlogies" />  
        <add id="2" title="Bloget" description="My ASP Webforms Blog Control" />  
        <add id="3" title="Browser" description="Browser related (all browsers)" />  
        <add id="4" title="C#" description="Microsoft's C# Language" />  
        <add id="5" title="Freebies" description="You know you want it" />  
        <add id="6" title="Life" description="Because there's more to life than programming (I think)" />  
        <add id="7" title="Applications" description="Desktop applications are so 90's" />  
        <add id="8" title="Programming" description="General programming topics" />  
        <add id="9" title="Security" description="It's an illusion" />  
        <add id="10" title="Technology" description="Gadgets, cars, etc." />  
        <add id="11" title="Science" description="Bubble, gurgle, boil..." />  
        <add id="12" title="PC Tips" description="How to use that F@#$ing thing" />  
        <add id="13" title="Desktop Gadgets" description="Something I really miss about in Windows" />  
        <add id="14" title="Links" description="Links to stuff I find interesting" />  
        <add id="15" title="Naughty &amp; Nice" description="Feed back about buying from vendors" />  
        <add id="16" title="F#" description="Microsoft's very cool F# Language" />  
        <add id="17" title="Nancy Framework" description="Lightweight, low ceremony ASP.Net MVC framework" />  
      </categories>  
    </BlogConfiguration>

To my eye, this is easier to manage. There's a clear indication of what the configuration is for (_<BlogConfiguration>_), there's less, "tag soup" using XML attributes and I clearly can't spell, "Technologies".

It's relatively straight forward to write one these. To begin with, define a class as follows:
    
    using System.Configuration;  
       
    public class BlogConfiguration : ConfigurationSection  
    {  
        [ConfigurationProperty("title", IsRequired = true)]  
        public string Title  
        {  
            get { return this["title"] as string; }  
        }  
       
        [ConfigurationProperty("postsPerPage", IsRequired = false, DefaultValue = 3)]  
        public int PostsPerPage  
        {  
            get { return (int)this["postsPerPage"]; }  
        }  
       
        [ConfigurationProperty("categories", IsRequired = false)]  
        public BlogCategoryConfigurationCollection Categories  
        {  
            get { return this["categories"] as BlogCategoryConfigurationCollection; }  
        }  
    }

  


I've removed most of the properties for clarity. There's a [gist of this class](https://gist.github.com/blueonion/5453384) available.

The _[[ConfigurationProperty](http://msdn.microsoft.com/en-us/library/system.configuration.configurationproperty.aspx)]_ attribute defines the name of configuration attribute. You can also specify additional attributes including whether the property is required and its default value.

The _Categories_ configuration requires two classes. One to define a "Category Element" and another to define the collection.
    
    public class BlogCategoryConfigurationElement : ConfigurationElement  
    {  
        [ConfigurationProperty("id", IsRequired = true)]  
        public string Id  
        {  
            get { return this["id"] as string; }  
        }  
       
        [ConfigurationProperty("title", IsRequired = true)]  
        public string Title  
        {  
            get { return this["title"] as string; }  
        }  
       
        [ConfigurationProperty("description", IsRequired = true)]  
        public string Description  
        {  
            get { return this["description"] as string; }  
        }  
    }  
       
    public class BlogCategoryConfigurationCollection : ConfigurationElementCollection  
    {  
        public BlogCategoryConfigurationElement this[int index]  
        {  
            get { return BaseGet(index) as BlogCategoryConfigurationElement; }  
            set  
            {  
                if (BaseGet(index) != null)  
                {  
                    BaseRemoveAt(index);  
                }  
                BaseAdd(index, value);  
            }  
        }  
       
        protected override ConfigurationElement CreateNewElement()  
        {  
            return new BlogCategoryConfigurationElement();  
        }  
        
        protected override object GetElementKey(ConfigurationElement element)  
        {  
            return ((BlogCategoryConfigurationElement)element).Id;  
        }  
    }

  


The _[ConfigurationElement](http://msdn.microsoft.com/en-us/library/system.configuration.configurationelement.aspx)_ is much like the _[ConfigurationSection](http://msdn.microsoft.com/en-us/library/system.configuration.configurationsection.aspx)_. In this case it is used to define the structure of a category. 

The _[ConfigurationElementCollection](http://msdn.microsoft.com/en-us/library/system.configuration.configurationelementcollection.aspx)_ is more work. The required elements are an indexer, a factory method to create a new element and a method to retrieve the element's key. Standard fare for collection overrides.

Finally, the Web.config has to be told about the new custom configuration section. This also wires-up IntelliSense support.
    
    <configuration>  
      <configSections>  
        <section name="BlogConfiguration" type="bloget2.Models.BlogConfiguration" />  
      </configSections>  
      ...  
    </configuration>

  


To reference the configuration in your code:
    
    var blogConfiguration = (BlogConfiguration)ConfigurationManager.GetSection("BlogConfiguration");  
    blog.Title = blogConfiguration.Title;  
    ...

  


Notice the use of properties instead of string-based indexers.

Related links:

  * [How to: Create Custom Configuration Sections Using ConfigurationSection](http://msdn.microsoft.com/en-us/library/2tw134k3(v=vs.100).aspx)
  * [Custom Configuration Sections in 3 Easy Steps](http://haacked.com/archive/2007/03/11/custom-configuration-sections-in-3-easy-steps.aspx)
  * [Custom Configuration Sections in app.config or web.config](http://weblogs.asp.net/brijmohan/archive/2011/04/22/custom-configuration-sections-in-app-config-or-web-config.aspx)
