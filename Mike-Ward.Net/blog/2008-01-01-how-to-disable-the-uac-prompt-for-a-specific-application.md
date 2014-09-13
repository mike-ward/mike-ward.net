How to disable the UAC prompt for a specific application
2008-01-01T15:39:11
Sometimes, you want to disable UAC prompt for certain applications on a Windows Vista computer without disabling UAC for the whole computer.

From [http://support.microsoft.com/kb/946932](http://support.microsoft.com/kb/946932)

Using the tool and steps below, you may disable UAC prompt for the specific application. This does not disable the User Acount Control feature for the whole computer.

  1. Download and install the Application Compatibility Toolkit from this link:   
Microsoft Application Compatibility Toolkit 5.0   
[http://www.microsoft.com/downloads/details.aspx?FamilyId=24DA89E9-B581-47B0-B45E-492DD6DA2971&displaylang;=en](http://www.microsoft.com/downloads/details.aspx?FamilyId=24DA89E9-B581-47B0-B45E-492DD6DA2971&displaylang=en)
  2. In the Start menu, locate the new folder. Find the shortcut icon for **Compatibility Administrator**. Right click it and clik **Run as administrator**. 
  3. In the left hand pane, right-click on the database under **Custom Databases** and select **Create New,** and select **Application Fix**. 
  4. Enter the name and other details of the application you want to alter behavior on and then browse to it to select it. Click Next. 
  5. Click Next until you are in the **Compatibility Fixes** screen. 
  6. On the **Compatibility Fixes** screen, find the item **RunAsInvoker**, and check it. (Tip: you can also make the selected programs run as administrator with this technique, just select **RunAsAdministrator** instead) 
  7. Click Next and then Finish. 
  8. Select File and Save As. Save the file as a filename.SDB type file in a directory you will easily find it. 
  9. Copy the .sdb file to the Vista computer you want to alter the elevation prompt behavior on. 
  10. Click Start>All Programs>Accessories. Right click **Command Prompt **and click **Run as administrator**. 

Run the command below:

**sdbinst _\_.sdb**

For example, if you saved the .SDB file as **_abc.sdb _**in the **_c:\Windows _**folder, the command should be like this:****

**sdbinst c:\windows\abc.sdb**

It should prompt: Installation of  complete.
