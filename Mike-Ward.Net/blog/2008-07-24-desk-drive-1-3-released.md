Desk Drive 1.3 Released!
2008-07-24T23:43:54
This release of Desk Drive requires your help. I've added the ability to "Localize" Desk Drive without special tools. I wrote an extension to .Net's Resource Manager that pulls resources from an XML file rather than satellite assemblies. If you don't understand what that means, don't worry. All it means is that Desk Drive can be localized to new languages by editing one simple file (DeskDrive.exe.xml).

[![deskdrive](/cdn/images/blog/DeskDrive1.3Released_11570/deskdrive_thumb.png)](/cdn/images/blog/DeskDrive1.3Released_11570/deskdrive.png)

The format of the file is as follows:
    
    <resources>
      <strings>
        <notifyIcon>
          <default>Desk Drivedefault>
          <de>Desk-Laufwerkde>
        notifyIcon>
        <showToolStripMenuItem>
          <default>Settings...default>
          <de>Einstellungende>
        showToolStripMenuItem> ...

Adding a new language only requires adding new country code with the appropriate string. No special tools (other than a text editor), no compilers, no satellite assemblies.

I've made a lame attempt at adding German. Your job is to add other languages. There are only 22 strings to translate so it shouldn't take long. When you've finished adding a new language, send me the XML file and I'll merge it into the distribution.
