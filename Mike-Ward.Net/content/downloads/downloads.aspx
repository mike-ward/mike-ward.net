<%@ Page Title="Downloads | Blue Onion Software" Language="C#" MasterPageFile="~/master-page.master" %>

<%@ OutputCache Duration="20" VaryByParam="*" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <meta name="Description" content="Download your favorite Blue Onion programs including Desk Drive, Tweetz and Simply Weather." />
  <style type="text/css">
    table { border-spacing: 0; line-height: 20px; }
    table a { text-decoration: none; }
    td { border-top: double #dbdbdb; padding: 10px 30px 10px 5px; text-align: left; vertical-align: top; margin-right: -1px; }
    .download:before { content: url(images/file-download.png); margin-right: 4px; vertical-align: middle; }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
  <h1>Downloads</h1>
  <p>(a.k.a. The Goods)</p>
  <p>
    <script type="text/javascript"><!--
      google_ad_client = "pub-1981154560626519";
      /* bo.bottom.downloads */
      google_ad_slot = "6577379811";
      google_ad_width = 728;
      google_ad_height = 90;
    //-->
    </script>
    <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
    </script>
  </p>
  <table>
    <%-- Bloget --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/bloget.zip">Bloget Beta 1</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/Bloget_Source_Beta_1.zip">Bloget Source Code</asp:HyperLink>
    </td><td>Includes a sample Web site and the binary (note the singular form of binary) </td></tr>
    <%-- Calendar Gadget --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/CalendarGadget.msi">CalendarGadget.msi</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/bigclock.cgs">bigclock.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/blackglass.cgs">blackglass.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/firstclock.cgs">firstclock.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/blackglass.cgs">blackglass.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/grayclock2.cgs">grayclock2.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/grayclock3.cgs">grayclock3.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/mountain.cgs">mountain.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/purplehaze.cgs">purplehaze.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/yuckyblue.cgs">yuckyblue.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/todayis.cgs">todayis.cgs</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/cg/scenic.cgs">scenic.cgs (~10 MB)</asp:HyperLink><br />
    </td><td>This is an alpha version so your mileage may vary. The .cgs files are calendar skins. Once downloaded, you
      can just drag and drop them on the Calendar. There's a built in designer that allows you to edit the existing
      skins or create new ones. You can read more about <a href="http://blueonionsoftware.com/blog.aspx?p=57ffc3f5-cf34-41b5-baee-c2993aa1cf66">
        here</a>. <i><br />
          Version 0.1.0 - October 25, 2008</i> </td></tr>
    <%-- FreeSnap --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/FreeSnap.msi">FreeSnap.msi</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/FreeSnap64.msi">FreeSnap64.msi</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/FreeSnapSource.zip">FreeSnapSource.zip</asp:HyperLink>
    </td><td>Move and resize windows with your keypad. Now available in 32 and 64 bit versions. <i><br />
      Version 1.5.3 - June 6, 2009</i> </td></tr>
    <%-- DeskDrive --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/DeskDrive.exe">DeskDrive.exe</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/DeskDrive64.exe">DeskDrive64.exe</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/DeskDriveSource.zip">DeskDriveSource.zip</asp:HyperLink>
    </td><td><a href="deskdrive.aspx">Automatic drive/media shortcuts for your desktop</a>.<br />
      <i>Version 1.8.5 - November 20, 2011</i> </td></tr>
    <%-- Desk View --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/Deskview.zip">Deskview.zip (10K)</asp:HyperLink>
    </td><td>Deskview changes your desktop icons from large to small (and back again). It's a perfect complement to
      Desk Drive.
      <asp:HyperLink runat="server" NavigateUrl="http://blueonionsoftware.com/blog.aspx?p=e222d696-ec4c-4f5a-b1e1-affd9b02182f">Read more...</asp:HyperLink>
    </td></tr>
    <%-- Calendar --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/CalendarSetup.msi">CalendarSetup.msi</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/CalendarSetup64.msi">CalendarSetup64.msi</asp:HyperLink><br />
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/CalendarSource.zip">CalendarSource.zip</asp:HyperLink>
    </td><td>Simple and functional. One of the first .Net programs I ever wrote (kinda shows too). Still, it's proven
      popular over the year and I still use it daily. <i><br />
        Last update: Version 2.2.2 - October 21, 2008</i> </td></tr>
    <%-- Noncontiguous Memory Stream --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/noncontiguousmemorystream.zip">NonContiguousMemoryStream.zip</asp:HyperLink>
    </td><td>An implementation of System.IO.MemoryStream that does not use the large heap. Includes C# source code </td>
    </tr>
    <%-- SimpleZip --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/SimpleZip.zip">SimpleZip.zip</asp:HyperLink>
    </td><td>A light weight implementation of a .ZIP archive generator. Includes C# source code </td></tr>
    <%-- Simply Weather --%>
    <tr><td>
      <asp:HyperLink CssClass="download" ID="simpleweather" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/SimplyWeather.gadget"
        Target="_blank">SimplyWeather.gadget</asp:HyperLink><br />
      <i>version 1.3.1.3</i><br />
      <i>June 6, 2011</i> </td><td>A Vista/Windows 7 Sidebar gadget that shows the current weather conditions and forecast
        for the next 3 days in a compact, no nonsense format. See <a href="http://blueonionsoftware.com/gadgets.aspx">Vista
          Sidebar Weather Gadget</a> for details. </td></tr>
    <%-- Stop watch --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/StopWatch.gadget"
        Target="_blank">Stopwatch.gadget</asp:HyperLink>
    </td><td>A Windows Vista Sidebar stopwatch gadget and nothing more. See <a href="http://blueonionsoftware.com/Blog.aspx?p=0504105e-454a-49a8-9e9a-335c3dfcce08">
      Vista Sidebar Stopwatch Gadget</a> for details. <i><br />
        Last update: September 26, 2010</i> </td></tr>
    <%-- Calculator --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="http://gallery.live.com/liveItemDetail.aspx?li=69430d4e-9452-4b8b-b00b-a43e4e91d41e&bt=1&pl=1"
        Target="_blank">Calculator.gadget</asp:HyperLink>
    </td><td>A Windows Sidebar Calculator gadget. Allows for the evaluation of expressions rather than trying to emulate
      an actual calculator. Far more useful IMHO. </td></tr>
    <%-- AdSensor --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="http://blueonionsoftware.com/blog.aspx?p=bf5a9431-7306-4ff0-80c5-6273e45c54e5"
        Target="_blank">AdSensor.gadget</asp:HyperLink>
    </td><td>AdSensor has been retired. See <a href="http://blueonionsoftware.com/blog.aspx?p=bf5a9431-7306-4ff0-80c5-6273e45c54e5">
      AdSensor Retired</a> </td></tr>
    <%-- Market Report --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/MarketReport.gadget"
        Target="_blank">MarketReport.gadget</asp:HyperLink>
    </td><td>Keep track of the Dow, Nasdaq and S&amp;P 500 market indices with this handy little gadget. Use your mouse
      wheel to change the background or click the title to go to the Yahoo finance page. See <a href="http://blueonionsoftware.com/tweetz.aspx">
        Market Report Sidebar Gadget Released</a> for details. <i><br />
          Last update: November 26, 2011</i> </td></tr>
    <%-- Tweetz3 --%>
    <tr><td>
      <a href="download.aspx?filename=Downloads/tweetz31.gadget" id="tweetz" class="download">tweetz 3.1</a>
    </td><td>Version 3.1 features a unified timeline, better language support and greater reliability. <a href="http://blueonionsoftware.com/blog.aspx?p=70bf5ba9-6ab1-4512-a8fb-f2e8cc73ea8b">
      Read more...</a> <i><br />
        Version 3.1.5.2, June 19, 2011</i>
    </td></tr>
    <%-- tweetc --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/tweetc.zip" Target="_blank">tweetc.zip</asp:HyperLink>
    </td><td>A twitter gadget for the Windows command line. Give it a try and let me know what you like (and don't)
      about it. <a href="http://blueonionsoftware.com/blog.aspx?p=b46a526d-03ea-40a2-8563-6f66f4838a57">Read more...</a>
      <i><br />
        Last update: October 27, 2009</i> </td></tr>
    <%-- Throw --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/Throw.zip">Throw.zip</asp:HyperLink>
    </td><td>A handy set of C# routines for checking conditions and raising exceptions. Intended primarily for checking
      parameters on methods, these routines make it easy to validate parameters in a single line of code. You can read
      more about these routines <a href="http://blueonionsoftware.com/blog.aspx?p=b5b9e553-3e10-40ae-9f59-e38f1c50e2d6">
        here</a>. </td></tr>
    <%-- Xml Resource Manager --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/XmlResourceManager.zip">XmlResourceManager.zip</asp:HyperLink>
    </td><td>XmlResourceManager extends the ResourceManager commonly used in .Net programs. The only real difference
      between the normal ResourceManager and XmlResourceManager is where the resources are stored. In the later case,
      it just an XML file with a simple format. <a href="http://blueonionsoftware.com/blog.aspx?p=9f0af0a8-5899-4bdd-960b-5cfd18e80e35">
        (Read more...)</a> </td></tr>
    <%-- JSLint for VS --%>
    <tr><td>
      <asp:HyperLink CssClass="download" runat="server" NavigateUrl="~/download.aspx?filename=Downloads/jslint.zip">jslint.zip</asp:HyperLink>
    </td><td><a href="http://jslint.com">JSLint</a> for Visual Studio. A tool to run JSLint against your JavaScript
      code without leaving the IDE. <a href="http://blueonionsoftware.com/blog.aspx?p=93c5e5ac-5e85-4f19-bc1b-a6bc80ea5b7c">
        (Read more...)</a> </td></tr>
  </table>
  <p>&nbsp;</p>
  <script type="text/javascript"><!--
    google_ad_client = "pub-1981154560626519";
    /* bo.bottom.downloads */
    google_ad_slot = "6577379811";
    google_ad_width = 728;
    google_ad_height = 90;
    //-->
  </script>
  <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
  </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarPlaceHolder" runat="Server">
  <p>
    <script type="text/javascript"><!--
      google_ad_client = "pub-1981154560626519";
      /* bo.sidebar.freesnap */
      google_ad_slot = "7174062206";
      google_ad_width = 120;
      google_ad_height = 600;
    //-->
    </script>
    <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
    </script>
  </p>
</asp:Content>
