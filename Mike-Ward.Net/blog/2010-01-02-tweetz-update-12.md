tweetz Update #12
2010-01-02T13:32:03
**What’s New**

  * “More” Links – Added a link at the end of the updates (scroll to bottom to see) that fetches the next 20 updates. 
  * Ctrl+S – Ctrl+S to send an update that you’re composing. Always on. “Send on Enter” is still available by option. 
  * untiny.me – Switched to [http://untiny.me](http://untiny.me) for reverse link lookup. [http://long.to](http://long.to) was not expanding [http://bit.ly](http://bit.ly) links. 
  * Priority Queue – Added a priority queue to the Ajax queue added earlier. 
  * Timestamps – Only the first 20 tweets timestamps were updated. Fixed. 
  * Search fetches 50 most recent updates (up from 20) 
  * Version number in settings dialog. 
  * New logo 

![more-link](http://az667460.vo.msecnd.net/cdn/images/blog/tweetzUpdate12_796A/morelink.png)The most visible change are the “More Links”. This works similar to the “More” link on your twitter home page. Scroll to the bottom and click the “More” link to get the next 20 updates.

In the last release I added a “Send on Enter” option to post updates you’re composing by pressing the enter key. It occurred to me afterwards that there is a more standard (and perhaps more appropriate) shortcut for doing this - Ctrl+S. Should have thought of that one sooner.

Tweetz has always supported reverse lookups on, “Shortened links” that are the norm in twitter. Looking up these links turns out to be a significant performance bottleneck. Also, the nature of Ajax updates is such that parallel requests can return results to the wrong sender. To combat this, I added an Ajax queue to serialize requests in the last release. This reduces the opportunity for crosstalk across requests. However, there’s a dark side. Because the requests are executed in the order they arrive, if the queue gets long, response times for updates can get very slow.

The issue is all those reverse lookups. It’s not unusual to have 50 or more reverse lookups in the queue waiting to be serviced. If there are many pending requests in the queue, requests to post updates are not serviced for a long time. This has the appearance of hanging the application.

The solution is to give priority to the more important requests. This is a situation that just screams for a priority queue. And that’s what I did. The reverse lookups always get demoted to the lowest priority now which should make for a more responsive application.

Fixed a bug in how timestamps were updated. Only the last 20 updates on a given panel were being updated.

I’m planning to add a “More Link” to search results as well. It’s a lower priority. In the meantime, I’ve bumped the number of returned results to 50.

![logo](http://az667460.vo.msecnd.net/cdn/images/blog/tweetzUpdate12_796A/logo.png) There’s a new logo because I never liked the old one and finally did something about it.

Version number appears in the settings dialog for easier reference.

**Futures**

When I first started writing tweetz, I thought a few weekends and I’d have it done. Problem is, I’m having way too much fun writing it. I have plenty of other projects on the back-burner but for the moment, this is where my attention is focused.

The next feature I intend to add is [OAuth](http://oauth.net) support. Twitter is slowly phasing out “username/password” authentication for API requests in favor of OAuth. OAuth is an open source protocol that allows applications like tweetz to update your twitter status without having to surrender your username/password.

Twitter appears to be making some features available only to OAuth API requests. In fact, the only way to get the “sent from [application]” tag line to work is to register the application with twitter and send updates using OAuth.

This is a major change requiring additional handshaking and UI changes. I’ve started down this road already but it’s more challenging to implement than I first thought. The JavaScript support for OAuth is lacking and there are few examples so it’s one of those, “Try and retry until you get it to work” situations.

After that, I’m thinking twittpic support might be a nice addition. Of course, I’m always open to suggestions.

Available on the [downloads page](/downloads).
