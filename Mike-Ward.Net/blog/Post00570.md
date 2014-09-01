Visual Studio 2010 RC and Tablet PC’s
2010-03-03T01:12:40
![](http://i.msdn.microsoft.com/dd582936.VisualStudio_lg(en-us,MSDN.10).png)I’m one of those lucky blokes that got a tablet PC at [PDC 09](http://microsoftpdc.com/) last year. It’s a nice little laptop, similar to the [new 7" tab from T-Mobile](http://mobile-broadband.t-mobile.com/tablets/plus) and has good battery life and a bright screen. I’ve not used the touch interface much. Windows applications feel a bit too uncomfortable on a small touch screen.

I’ve been running [Visual Studio 2010 RC](http://msdn.microsoft.com/en-us/vstudio/dd582936.aspx) on my laptop for a while now. It seems to have a somewhat strained relationship with the tablet features.

One issue I was having was that I could not open several dialogs including the File Open Dialog and the Add References Dialog. The former was annoying but the later was down right intolerable. Whenever I tried to open any of these dialogs, all I got was a brief flicker of the program frame. No dialog. Total bummer.

I’ve come to find that the issue had to do with the Tablet PC Input Services. I had disabled this service (Microsoft’s recommendation) to work around a crash in intellisense. Later on the dialog issues started. I didn’t connect the two events because of the lag between the time I disabled the service and the dialogs not working.

Enabling the Tablet PC Input Service fixed the issue with the dialogs. I’m sure there’s a logical connection to why this should be but it’s certainly not obvious from an end user perspective. Anyways, I thought I would relay my experience in case anyone else encounters this issue. 
