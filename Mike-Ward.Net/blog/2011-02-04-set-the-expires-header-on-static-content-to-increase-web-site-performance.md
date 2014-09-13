Set the Expires header on static content to increase web site performance
2011-02-04T13:27:26
Yahoo and Google recommend setting the **Expires** header of a web site’s static content (i.e. images) to some distant future date. This makes those components cacheable. It also avoids unnecessary HTTP requests on subsequent page views. If you’re using IIS7, just add the following to your Web.config.
    
    <system.webServer>  
      <staticContent>  
        <clientCache cacheControlMode="UseExpires"  
           httpExpires="Tue, 19 Jan 2038 03:14:07 GMT" />  
      <staticContent>  
    <system.webServer>  
    

  


Just remember that if you change any of your static content, you’ll have to change the file name.
