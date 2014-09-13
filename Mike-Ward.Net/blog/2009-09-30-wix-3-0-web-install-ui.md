Wix 3.0 Web Install UI
2009-09-30T17:00:14
One of the best ways to write installers for Windows programs is to use Wix 3.0. Recently released, its an open source product from Microsoft that uses XML markup to author Windows installers that use the Windows built-in installer engine (msiexec.com).

It’s also one of the hardest to understand and learn installer technologies since it mirrors the actual structure of a Windows compliant installer. Despite the steep learning curve, I think it is the best technology available today to author and maintain installers. Lots of pain but also lots of gain.

Wix 3.0 includes many new extensions for handling all sorts of install tasks including configuring IIS Web applications. While there are tasks to create virtual directories and application pools, there is no built-in UI for installing Web applications.

Wix lets you define your own UI’s but it’s a daunting task to say the least. Fortunately, the Wix source contains the markup for these UI’s. Modifying them is still a challenge but at least you’re not starting from scratch.

What I’ve done here is minimal but can serve as a spring board to further modifications. You should be comfortable with working in Wix before taking on UI changes like this.
    
    xml version="1.0" encoding="UTF-8"?>
    
    
    
    
    <Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
      <Fragment>
        <UI Id="WixUI_InstallWeb">
          <TextStyle Id="WixUI_Font_Normal" FaceName="Tahoma" Size="8" />
          <TextStyle Id="WixUI_Font_Bigger" FaceName="Tahoma" Size="12" />
          <TextStyle Id="WixUI_Font_Title" FaceName="Tahoma" Size="9" Bold="yes" />
    
          <Property Id="DefaultUIFont" Value="WixUI_Font_Normal" />
          <Property Id="WixUI_Mode" Value="InstallDir" />
    
          <DialogRef Id="BrowseDlg" />
          <DialogRef Id="DiskCostDlg" />
          <DialogRef Id="ErrorDlg" />
          <DialogRef Id="FatalError" />
          <DialogRef Id="FilesInUse" />
          <DialogRef Id="MsiRMFilesInUse" />
          <DialogRef Id="PrepareDlg" />
          <DialogRef Id="ProgressDlg" />
          <DialogRef Id="ResumeDlg" />
          <DialogRef Id="UserExit" />
    
          <Publish Dialog="BrowseDlg" Control="OK" Event="DoAction" Value="WixUIValidatePath" Order="3">1Publish>
          <Publish Dialog="BrowseDlg" Control="OK" Event="SpawnDialog" Value="InvalidDirDlg" Order="4">[CDATA[WIXUI_INSTALLDIR_VALID<>"1"]]>Publish>
    
          <Publish Dialog="ExitDialog" Control="Finish" Event="EndDialog" Value="Return" Order="999">1Publish>
    
          <Publish Dialog="WelcomeDlg" Control="Next" Event="NewDialog" Value="InstallWebDlg">1Publish>
    
          
    
          <Publish Dialog="InstallWebDlg" Control="Back" Event="NewDialog" Value="WelcomeDlg">1Publish>
          <Publish Dialog="InstallWebDlg" Control="Next" Event="SetTargetPath" Value="[WIXUI_INSTALLDIR]" Order="1">1Publish>
          <Publish Dialog="InstallWebDlg" Control="Next" Event="DoAction" Value="WixUIValidatePath" Order="2">NOT WIXUI_DONTVALIDATEPATHPublish>
          <Publish Dialog="InstallWebDlg" Control="Next" Event="SpawnDialog" Value="InvalidDirDlg" Order="3">[CDATA[NOT WIXUI_DONTVALIDATEPATH AND WIXUI_INSTALLDIR_VALID<>"1"]]>Publish>
          <Publish Dialog="InstallWebDlg" Control="Next" Event="NewDialog" Value="VerifyReadyDlg" Order="4">WIXUI_DONTVALIDATEPATH OR WIXUI_INSTALLDIR_VALID="1"Publish>
          <Publish Dialog="InstallWebDlg" Control="ChangeFolder" Property="_BrowseProperty" Value="[WIXUI_INSTALLDIR]" Order="1">1Publish>
          <Publish Dialog="InstallWebDlg" Control="ChangeFolder" Event="SpawnDialog" Value="BrowseDlg" Order="2">1Publish>
    
          <Publish Dialog="VerifyReadyDlg" Control="Back" Event="NewDialog" Value="InstallWebDlg" Order="1">NOT InstalledPublish>
          <Publish Dialog="VerifyReadyDlg" Control="Back" Event="NewDialog" Value="MaintenanceTypeDlg" Order="2">InstalledPublish>
    
          <Publish Dialog="MaintenanceWelcomeDlg" Control="Next" Event="NewDialog" Value="MaintenanceTypeDlg">1Publish>
    
          <Publish Dialog="MaintenanceTypeDlg" Control="RepairButton" Event="NewDialog" Value="VerifyReadyDlg">1Publish>
          <Publish Dialog="MaintenanceTypeDlg" Control="RemoveButton" Event="NewDialog" Value="VerifyReadyDlg">1Publish>
          <Publish Dialog="MaintenanceTypeDlg" Control="Back" Event="NewDialog" Value="MaintenanceWelcomeDlg">1Publish>
    
          <Property Id="ARPNOMODIFY" Value="1" />
    
          <Dialog Id="InstallWebDlg" Width="370" Height="270" Title="!(loc.InstallDirDlg_Title)">
            <Control Id="Next" Type="PushButton" X="236" Y="243" Width="56" Height="17" Default="yes" Text="!(loc.WixUINext)" />
            <Control Id="Back" Type="PushButton" X="180" Y="243" Width="56" Height="17" Text="!(loc.WixUIBack)" />
            <Control Id="Cancel" Type="PushButton" X="304" Y="243" Width="56" Height="17" Cancel="yes" Text="!(loc.WixUICancel)">
              <Publish Event="SpawnDialog" Value="CancelDlg">1Publish>
            Control>
    
            <Control Id="Description" Type="Text" X="25" Y="23" Width="280" Height="15" Transparent="yes" NoPrefix="yes" Text="!(loc.InstallDirDlgDescription)" />
            <Control Id="Title" Type="Text" X="15" Y="6" Width="200" Height="15" Transparent="yes" NoPrefix="yes" Text="!(loc.InstallDirDlgTitle)" />
            <Control Id="BannerBitmap" Type="Bitmap" X="0" Y="0" Width="370" Height="44" TabSkip="no" Text="!(loc.InstallDirDlgBannerBitmap)" />
            <Control Id="BannerLine" Type="Line" X="0" Y="44" Width="370" Height="0" />
            <Control Id="BottomLine" Type="Line" X="0" Y="234" Width="370" Height="0" />
    
            <Control Id="FolderLabel" Type="Text" X="20" Y="60" Width="290" Height="30" NoPrefix="yes" Text="!(loc.InstallDirDlgFolderLabel)" />
            <Control Id="Folder" Type="PathEdit" X="20" Y="100" Width="320" Height="18" Property="WIXUI_INSTALLDIR" Indirect="yes" />
            <Control Id="ChangeFolder" Type="PushButton" X="20" Y="120" Width="56" Height="17" Text="!(loc.InstallDirDlgChange)" />
    
            <Control Id="VirtualDirLabel" Type="Text" X="20" Y="160" Width="290" Height="10" NoPrefix="yes" Text="Virtual Directory:" />
            <Control Id="VirtualDir" Type="Edit" X="20" Y="172" Width="320" Height="18" Property="WIXUI_VIRTUALDIR" Indirect="yes" />
          Dialog>
        UI>
    
        <UIRef Id="WixUI_Common" />
      Fragment>
    Wix>

This is the Wix “InstallDir” dialog set modified to accept the a virtual directory. Reference it in you setup as follows:
    
    <UIRef Id="WixUI_InstallWeb" />
    <Property Id="WIXUI_INSTALLDIR" Value="INSTALLDIR" />
    <Property Id="WIXUI_VIRTUALDIR" Value="VIRTUALDIR" />
    <Property Id="VIRTUALDIR">[CDATA[simplyweather]]>Property>

The VIRTUALDIR property will contain the specified virtual directory. In this case, it defaults to “simplyweather” unless the user modifies it during the install process. The dialog is modified to allow the user to change it if necessary.

I’ll likely enhance this later to allow different Web sites (currently, only “Default Web Site” is supported, custom application pools and other settings.
