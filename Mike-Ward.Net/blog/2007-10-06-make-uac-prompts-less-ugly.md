Make UAC Prompts Less Ugly
2007-10-06T00:19:56
Is it me or is the UAC prompt jarring? It dims the entire screen but instead of a smooth transition, it flashes. It then pops up a dialog and after you click "Continue", it "flashes" back to the desktop. It's jarring and entirely unnecessary. In Vista Business and Vista Ultimate you can run the Security Policy Manager (secpol.msc) and disable this flashing behavior. But in Vista Home and Home Premium, Security Policy Manager is not included. There is a way around this however. If you're comfortable using the registry editor (insert usual warning here about doing irreparable harm to your computer) it's easy to make this prompt a bit more friendlier.

`[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System]   
"PromptOnSecureDesktop"=dword:00000000`

Setting PromptOnSecureDesktop to zero will turn off the "jarring" behavior of UAC prompts. Instead, you get a dialog, plain and simple.

![](http://s3.amazonaws.com/BlueOnionSoftware/Blog/uac.png)

If you're running as admin, you can disable the prompt entirely as follows:

`[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System]   
"ConsentPromptBehaviorAdmin"=dword:00000000`
