Desk Drive Roadmap
2008-07-16T21:44:26
I'm at an architecture conference this week which is why I'm a bit behind on my blogging schedule. However, I thought I would take a few minutes to talk about the next version of Desk Drive. Desk Drive has been amazingly popular and I get requests to modify it all the time. The top requests are:

  * Hide the tray icon 
  * Startup on login 
  * Position icons on desktop 
  * Localized versions 

I've pointed out that XP allows you to hide icons on the tray but it appears from the responses that that is not a satisfactory solution. Ok, I'll add an option to hide the silly tray icon. Starting the program a second time will bring up the settings dialog when the tray icon is hidden.

Startup on login is also an often requested item. I'm guessing most users don't know they can drag and drop the shortcut to the startup folder. Fair enough, I'll add it.

The one I'm not sure how to implement is how the saved positions on the desktop should work. I've had a fair number of requests but what I really need is a use case as to how this feature should work. Leave your feedback in the comments so others can comment.

As to localized versions, Desk Drive is localizable if you have the tools, namely Visual Studio 2008, but it's a pain and no one has bothered (and I don't blame them). The standard .Net satellite assembly approach for resource localization is over kill for such a small app like Desk Drive. To fix this issue, I've written an XmlResourceManager, which extends the .Net ResourceManager framework to use an Xml file as a resource source. I'll blog about this component in another post but the basic idea is that all the resources for all languages will exist in a single Xml file that is read at load time.

Modifying the Xml resource file will require nothing more than a text editor and a knowledge of the local language. Since the Xml file is read at load time, testing the results will be easy and immediate. I can't imagine an easier and more immediate mechanism. Look for these improvements in the next week or so.
