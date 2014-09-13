Wireless Laptop won't Print to Networked Printer (Solved!)
2006-09-28T22:28:28
Well this might be obvious to a many of you out there but it had me stumped for a while. My corporate laptop works fine on my home wireless network except I can't print. I could ping the printer and the printer install program could also detect the printer but all attempts to print failed. It finally dawned on me to turn on the pop-up alerts in ZoneAlarm, the corporate firewall software installed on the laptop and try to print again. Sure enough, spoolsve.exe was being blocked. But why?

Well, as it turns out the laptop, when running on my home network is in the Internet zone. By default, ZoneAlarm blocks the print spooler in this zone. It's easy to fix. Here's a screen shot of what has to change.

![](/Blog/zonealarm.png)

Now the question is what are the security risks with enabling this setting? I don't know. Perhaps someone out there can comment?
