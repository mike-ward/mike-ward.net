Maintaining User Settings when Upgrading
2008-08-10T13:16:01
A Desk Drive user sent me a bug report complaining that his settings were not maintained when he upgraded from one version to the next. After checking into it I discovered he was right. The **Settings** class in .Net maintains settings in a **user.config** style that is stored in a folder that corresponds to the program version.

Being a dutiful programmer, I always bump the assembly version when new fixes or features are released. As a result, the user settings from the previous version are "lost" in the sense that the program no longer accesses them due to the change in the settings folder name. This rather annoyed me at first. After all, what good is a settings class if it doesn't migrate settings from version to version?

I suspect there are good reasons why settings are not migrated automatically by the framework (side by side execution for instance?). Still, it's darn annoying for users.

But like so many things in .Net, if you look a little harder, there is almost always a solution when the problem is commonplace. In this case, the **Settings** class has a method called Upgrade(). Using it requires adding some additional code at program startup.
    
    static void UpgradeSettings()
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        var version = assembly.GetName().Version;
    
        if (version.ToString() != Properties.Settings.Default.ApplicationVersion)
        {
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.ApplicationVersion = version.ToString();
            Properties.Settings.Default.Save();
        }
    }

The trick here is to store an application version string in the settings (default value = 0) and compare it to the executing assemblies' version string. If they don't match, call **Settings.Upgrade()**. Don't forget to save the new version string.
