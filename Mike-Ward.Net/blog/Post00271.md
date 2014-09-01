Configuring the ASP.NET Health Monitor
2008-04-09T22:34:11
One of the things I really like about programming in .NET and ASP.NET is all the cool built-in functionality in the framework. The ASP.NET health monitor is an excellent example.

ASP.NET health monitoring gives you an easy way to monitor the health of an ASP.NET application and to get detailed run-time information about ASP.NET resources (to instrument the application). Health monitoring contains ready-to-use Web health-monitoring events classes (Web events) and health-monitoring providers (listeners). Web events package health-event information.

ASP.NET health monitoring enables you to do the following tasks:

  * Monitor the performance of an application to make sure that it is healthy. 
  * Rapidly diagnose applications or systems that are failing. 
  * Appraise significant events during the life cycle of an application. 
  * Monitor live ASP.NET applications, individually or across a Web farm. 
  * Log events that do not necessarily relate to errors in an ASP.NET application. 

Setting up monitoring involves editing the Web.config file for your Web site. The examples in the documentation are not as clear as they could be. Here's a configuration I use that sends an email any time an error is detected.
    
    <system.web>
    <healthMonitoring enabled="true">
      <eventMappings>
        <clear />
        <add name="All Errors" type="System.Web.Management.WebBaseErrorEvent"
                 startEventCode="0" endEventCode="2147483647" />
      </eventMappings>
    
      <providers>
        <clear />
        <add name="mailWebEventProvider"
             type="System.Web.Management.SimpleMailWebEventProvider"
             to="you@somedomain.com"
             buffer="false"
             subjectPrefix="WebEvent has fired"/>
      </providers>
    
      <rules>
        <clear />
        <add name="Testing Mail Event Providers"           
          eventName="All Errors"           
          provider="mailWebEventProvider"          
          profile="Default"          
          minInstances="1" 
          maxLimit="Infinite"
          minInterval="00:01:00"
          custom="" />
      </rules>
    </healthMonitoring>
    </system.web>
    
    <system.net>
    <mailSettings>
      <smtp deliveryMethod="network" from="webapp@somedomain.com">
        <network
          host="your-smtp-server"
          port="25"
          defaultCredentials="true" />
      </smtp>
    </mailSettings>
    </system.net>

In addition to the healthmonitoring settings, you'll also need to configure the mail settings as shown. Make sure to change the email and host values as well.

When an error is detected, you'll get an email detailing the time of the error, the url, host info and most importantly, a stack trace. There are also ways to configure healthmontoring to write to a database. Custom events and providers are also supported.
