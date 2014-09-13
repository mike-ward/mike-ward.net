XmlResourceManager
2008-07-31T23:25:21
The most recent release of Desk Drive now allows for localization by modifying a text file and adding the appropriate language code and strings. Recall that localizing applications in .Net generally involves creating satellite assemblies, one for each language. It usually requires special tools like the Visual Studio IDE or a resource management tool.

For Desk Drive, I needed something that made it very easy for others to provide the translations. Let's face, few people are going to go through the trouble to generate a satellite assembly for a freeware program like Desk Drive. But like many things in life, if you make it easy enough, someone will help you out.

XmlResourceManager extends the ResourceManager commonly used in .Net programs. The only real difference between the normal ResourceManager and XmlResourceManager is where the resources are stored. In the later case, it just an XML file with a simple format.

The class diagram for XmlResourceManager is as follows:

[![ClassDiagram1](/content/images/blog/XmlResourceManager_11321/ClassDiagram1_thumb.png)](/content/images/blog/XmlResourceManager_11321/ClassDiagram1.png)

It takes a bit of digging (thank goodness for Reflector) to figure out how resources are located and loaded in .Net. The idea, once you understand it is easy. The **ResourceManager** (and the derived **XmlResourceManager**) contains a list of **XmlResourceSet**. Each **XmlResourceSet** corresponds to a given language. When the **ResourceManager** calls **GetString**() for instance, it first checks if the string exists in the **XmlResourceSet** that corresponds to the UI language of the current thread. If the string is not located, it tries a culture neutral language. The ultimate fallback are the resources bound to the assembly itself.

**XmlResourceManager** essentially borrows the same logic and overrides the **InternalGetResourceSet** to instantiate an **XmlResourceSet**. **XmlResourceSet** in turn reads the actual resources using **XmlResourceReader**. The result is you can use the same logic for getting string resources currently employed in your program and simply substitute **XmlResourceManager** for **ResourceManager** in your code (and add the necessary XML resource file).

The XML file containing the localized strings looks something like this:
    
    xml version="1.0" encoding="utf-8" ?>
    <resources>
      <strings>
        <hello>
          <default>Hidefault>
          <en>Helloen>
          <de>Hallode>
        hello>
        <goodbye>
          <default>Byedefault>
          <en>Good byeen>
          <de>Tschüssde>
        goodbye>
      strings>
    resources>

The format is obvious. In this file the language specifiers are culture neutral meaning they don't specify a country code. If necessary, you can add langauge and country-codes as well (i.e. de-DE). Language-CountryCode is always considered first if it is available.

The **ResourceManager** will fall back to the embedded resources in the assembly as a last resort. Since we don't have embedded resources, I've specified the  tag has the **InvariantCulture**. This is the resource of last resort of a given string.

In an interesting twist, you need to override **GetDefaultReader** and return the type of the resource reader. I never traced the code far enough to figure out why this is necessary.
    
    public class XmlResourceSet : ResourceSet
    {
        public XmlResourceSet(Stream resourceStream, CultureInfo cultureInfo)
            : base(new XmlResourceReader(resourceStream, cultureInfo))
        {
        }
    
        public override Type GetDefaultReader()
        {
            return typeof(XmlResourceReader);
        }
    }

If you browse the code you'll notice that I used an plain **XmlReader** and walk the XML graphs manually. In most circumstances, I use an a buisness object and **XmlSerializer**. Walking XML graphs can be confusing and error prone. **XmlSerializer** generally does good job of serializing if you don't push it to hard.

However, in this case I opted to parse the graph manually. The reason is that it takes a fair bit of time to construct an **XmlSerializer** at runtime owing in part to its use of reflection. Usually the time spent constructing the serializer is not overly important, but since resources are usually accessed early in the life cycle of the program, I opted for speed as to not slow down program startup.

The code and test cases are available from the download page. For an example of using **XmlResourceManager**, consult the Desk Drive source code.

P.S. Just as I went to publish this, an article on [The Code Project](http://www.codeproject.com/KB/miscctrl/xml_localization.aspx) appeared with a similar solution. What timing!
