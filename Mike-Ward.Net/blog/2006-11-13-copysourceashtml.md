CopySourceAsHtml
2006-11-13T00:18:40
[CopySourceAsHtml ](http://www.jtleigh.com/people/colin/software/CopySourceAsHtml/)is a free Visual Studio 2005 add-in that lets you copy source code as HTML. It even preserves the color coding. CopySourceAsHtml addes itself to the right-click menu so it's easy to use. There are many options for formatting. Very handy for blog postings. Below is an example.

private void ReplySuccess(string message)

{

Page.Response.ContentType = "text/xml";

XmlWriterSettings xmlSettings = newXmlWriterSettings();

xmlSettings.Encoding = new System.Text.UTF8Encoding(false);

using (XmlWriter writer = XmlWriter.Create(OutputStream, xmlSettings))

{

writer.WriteStartDocument();

writer.WriteStartElement("methodResponse");

writer.WriteStartElement("params");

writer.WriteStartElement("param");

writer.WriteStartElement("value");

writer.WriteElementString("string", message);

writer.WriteEndDocument();

writer.Flush();

}

}
