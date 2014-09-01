Queued Ajax Calls in JQuery
2009-10-29T03:04:16
When writing Ajax, you can sometimes get into situations where sending two Ajax calls close together will return results out of order. In other words, the first Ajax call will receive the second Ajax calls’ results. This seems to be a particular problem in IE and Windows Sidebar Gadgets that use IE to display.

Windows Sidebar gadgets are particularly vulnerable in that different instances of gadgets can get each others Ajax data. That’s becasue all gadgets run in the same process, namely sidebar.exe. Argggg! Sometimes I just want to strangle Microsoft. I mean come guys, no one ever thought that two Ajax calls might occur at the same time. LAME!

OK, enough flames. The first step is to at least cut down on the opportunity of “crosstalk” by queuing the Ajax calls within a gadget. I found a several, “Queued Ajax Plugins” for JQuery. Oddly, I could not get any of them to work in JQuery 1.3. The problem appears to be due to a change in the JQuery.queue() method. Apparently, in JQuery 1.2, queue automatically started a dequeue when the first item was added.

I took the simplest of these plugins and modified it to start a dequeue when the first item is added.

Updated: My earlier code was flawed. The code below appears to work much better
    
    var currentAjaxRequest = null;  
      
    jQuery.ajaxQueue = function(ajaxOptions)  
    {  
        var success = ajaxOptions.success;  
        var error = ajaxOptions.error;  
        var complete = ajaxOptions.complete;  
      
        ajaxOptions.success = function()  
        {  
            if (success) { try { success.apply(this, arguments); } catch (e) { } }  
        };  
        ajaxOptions.error = function()  
        {  
            if (error) { try { error.apply(this, arguments); } catch (e) { } }  
        };  
        ajaxOptions.complete = function()  
        {  
            if (complete) { try { complete.apply(this, arguments); } catch (e) { } }  
            currentAjaxRequest = null;  
            $(window).dequeue("ajax");  
        };  
        $(window).queue("ajax", function()  
        {  
            currentAjaxRequest = jQuery.ajax(ajaxOptions);  
        });  
        if (currentAjaxRequest === null) { $(window).dequeue("ajax"); }  
    };  
    

  


  


This works just like the JQuery.ajax and uses the same syntax. It’s not perfect, but it’s a start.
