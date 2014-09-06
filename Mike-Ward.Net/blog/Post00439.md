Vista Weather Gadget Updated with Alerts
2009-03-02T02:17:03
Pressing forward with more improvements, the latest version of my Simply Weather gadget now monitors for weather alerts. Alerts are advisories, watches and warnings issued by the weather service for unusual weather events. When an alert is detected, the “Wind” information changes to a highlight color with a description of the alert. 

[![image](/content/images/blog/VistaWeatherGadgetUpdatedwithAlerts_11111/image_thumb.png)](/content/images/blog/VistaWeatherGadgetUpdatedwithAlerts_11111/image.png)

If you hover over the description (click on the gadget to give it input focus first), it displays a tool tip of when the alert expires.

I’ve also made the “Offline” behavior a bit more friendly. When offline, the gadget leaves the last readings up and puts an asterisk next to the location name to indicate that the data is not current.

Detecting if you’re on or offline is a bit tricky. You can always just wait for a request for data to time out but that can upwards of 30 seconds. After a bit of surfing I discovered that Internet Explorer has a “Behavior” extension. Here’s a code snippet that demonstrates how to detect connection status (Internet Explorer only)
    
    function Offline()
    {
      document.body.style.behavior = "url(#default#clientCaps)";
      return document.body.connectionType == "offline";
    }

Finally, a few of you have written to tell me the gadget is not working for you. I have not ascertained what the issue is just yet. In the meantime, I’ve added more checks and debugging. Hopefully we’ll zero in on it soon.

Available on the downloads page.
