How to configure IIS 7 to allow downloading .exe files
2010-10-11T20:46:50
If you’re finding that you’re getting 404 errors when trying to download executable files, add the following to your web.config (IIS 7 only).
    
    <system.webServer>  
        <handlers>  
          <add name="Client exe" path="*.exe" verb="*" modules="StaticFileModule" resourceType="File" />  
        </handlers>  
    </system.webServer>

  


It’s not that this is hard, I just couldn’t find any documentation. After what seemed like way to long searching for an answer, I thought it might be helpful to post my solution, which I never did find on line.
