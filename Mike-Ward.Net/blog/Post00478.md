Asynchronous XMLHttpRequests in JavaScript
2009-06-22T01:29:25
XMLHttpRequest (XHR) is a [DOM](http://en.wikipedia.org/wiki/Document_Object_Model) [API](http://en.wikipedia.org/wiki/Application_programming_interface) that can be used inside a [web browser](http://en.wikipedia.org/wiki/Web_browser) [scripting language](http://en.wikipedia.org/wiki/Scripting_language), such as [JavaScript](http://en.wikipedia.org/wiki/JavaScript), to send an [HTTP request](http://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol) directly to a [web server](http://en.wikipedia.org/wiki/Web_server) and load the [server response](http://en.wikipedia.org/wiki/Response) data directly back into the scripting language. Once the data is within the scripting language, it is available as both an [XML](http://en.wikipedia.org/wiki/XML) document, if the response was valid XML markup, and as [plain text](http://en.wikipedia.org/wiki/Plain_text). (Thank you Wikipedia).

Generally, you’ll want to make these calls asynchronously so you don’t block the UI thread. Most examples go something like this.
    
    var xhReq;
    function ajax()
    {
      xhReq = new XMLHttpRequest();
      xhReq.open("GET", "sumGet.phtml?figure1=5&figure2;=10", true);
      xhReq.onreadystatechange = onSumResponse;
      xhReq.send(null);
    }
    
    function onSumResponse() 
    {
      if (xhReq.readyState != 4)  { return; }
      var serverResponse = xhReq.responseText;
      ...
    }

Since the callback does not provide the original request object, the request is saved in global variable. Yuck! Also, if you have more than one request you’ll need more than one global variable. Double Yuck!

Fortunately, JavaScript supports closures so you can use an anonymous method inline as follows.
    
    function ajax()
    {
      var xhReq = new XMLHttpRequest();
      xhReq.open("GET", "sumGet.phtml?figure1=5&figure2;=10", true);
      xhReq.onreadystatechange = function() 
      {
        if (xhReq.readyState != 4)  { return; }
        var serverResponse = xhReq.responseText;
        ...
      };
    
      xhReq.send(null);
    }

Even though xhReq is local, it can still be referenced in the callback function because of something called a “Closure”. Not all languages support closures, but JavaScript is one of them. In this case, the “Closure” allows us to use xhReq in our callback function even though the callback function will execute long after the **ajax** function finishes.

For simple callbacks, this is a good way to go since it keeps the logic together. However, there are times when you may want to have the callback in a separate, named function because it is lengthy or so it can be reused by other code. It may look like your stuck, but the answer is simple. Use an anonymous function to call your named function and pass the request object as a parameter.
    
    function ajax()
    {
      var xhReq = new XMLHttpRequest();
      xhReq.open("GET", "sumGet.phtml?figure1=5&figure2;=10", true);
      xhReq.onreadystatechange = function() { onSumResponse(xhReq); };
      xhReq.send(null);
    }
    
    function onSumResponse(request) 
    {
      if (request.readyState != 4)  { return; }
      var serverResponse = request.responseText;
      ...
    }

We can now call **ajax()** as often as we wish without worrying about side-effects to global variables and our callback function is “local” to invocation of the request.

It may look a little odd to write functions as parameters to functions, but once you get use to it, it can make for better, more useful code.
