How to Create a Simple Chocolatey Package
2014-03-01T20:43:19
Haven't heard of [Chocolatey](http://chocolatey.org)? Rather than me rehash what it is you can [read about it here](http://www.hanselman.com/blog/IsTheWindowsUserReadyForAptget.aspx).

The documentation for creating a package is a bit fragmented and difficult to follow. It's actually easy once you see how one is done. So here goes.

First off, Chocolatey in not an installer. It automates the process of downloading a setup program and then running it. It's essentially a smart PowerShell script for downloading and running an installer. 

  1. Signup for a Chocolatey account. It's free. 
  2. In the, "My Account" page, copy the API Key. 
  3. Open a command prompt and run the following: 
    
    nuget setApiKey YOUR_API_KEY_HERE -Source [http://chocolatey.org/](http://chocolatey.org/)

  4. Create a new folder called, "example-package". Substitute "example" with your package name.
  5. Create a new file called, "example.nuspec". 
  6. Open the file in a text editor and insert the following contents 
    
    <?xml version="1.0"?>
    <package xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
             xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <metadata>
        <id>example</id>
        <title>Awesome example</title>
        <version>1.0</version>
        <authors>By You</authors>
        <owners>By You</owners>
        <summary>Yeah, its an awesome example</summary>
        <description>Did I mention its awesome?</description>
        <projectUrl>http://example.com/installer.msi</projectUrl>
        <tags>#example #awesome</tags>
        <licenseUrl>http://www.gnu.org/licenses/gpl-3.0.txt</licenseUrl>
        <requireLicenseAcceptance>false</requireLicenseAcceptance>
        <iconUrl>http://chocolatey.org/Content/Images/packageDefaultIcon-50x50.png
        </iconUrl>
        <dependencies>
          <dependency id="DotNet4.5.1" />
        </dependencies>
      </metadata>
    </package>

  7. Change the contents of the tags to reflect what's in your package. The, "DotNet4.5.1" dependency is an example of how to do a dependency. Remove or change it as required. Use the appropriate license and icon. 
  8. Create a subfolder called, "tools".
  9. In the, "tools" subfolder, create a file called, "ChocolateyInstall.ps1". 
  10. Edit the contents of, "ChocolateyInstall.ps1" as follows: 
    
    Install-ChocolateyPackage 'example' 'msi' '/s' 'http://example.com/setup.msi

    * The first parameter is the same name as the <id> in the, "example.nupec" file. 
    * The second parameter is one of the following: exe, msi, mui 
    * The third parameter is the command line switch for a silent install. Use the appropriate switch for the installer program. 
    * The forth parameter is the download URL of the installer. 
  11. Return to the folder where you created, "example.nuspec. 
  12. Build the package by running: 
    
    cpack example 

  13. Test your installation by running: 
    
    cinst example -source %cd%

  14. Once your satisfied with the results you can publish the package by running: 
    
    cpush example

Chocolatey can handle more complex situations. See the documentation for details. Good luck! 
