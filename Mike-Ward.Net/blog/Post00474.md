jQuery Delay Function
2009-06-09T01:16:34
Oddly, jQuery does not have delay function. The usual technique, from what I gather, is to use the animate function. Most examples use the opacity property as an animation target.
    
    $(selector).animate( { opacity: 1}, 3000, function() { /* callback */ });

This works beautifully, but it does affect the “opacity” setting. Most of the time, it’s not an issue, unless you’re working on an element with a non-default opacity.

Interestingly, “animate({ }, 3000)” doesn’t work. 

Then I tripped across this code at [http://james.padolsey.com/javascript/jquery-delay-plugin/](http://james.padolsey.com/javascript/jquery-delay-plugin/)
    
    $.fn.delay = function(time, callback){
        // Empty function:
        jQuery.fx.step.delay = function(){};
        // Return meaningless animation, (will be added to queue)
        return this.animate({delay:1}, time, callback);
    }

Nice, but then some comments on [http://stackoverflow.com/questions/316278/timeout-jquery-effects](http://stackoverflow.com/questions/316278/timeout-jquery-effects) allowed me to modify it even further.
    
    $.fn.delay = function(time, callback)
    {
        return this.animate({ opacity: '+=0' }, time, callback);
    }

The “plus equal zero” tip supplies an animation target that does nothing without having to create the step delay function. 

As a function, it’s chainable, so you can get some cool effects with little effort.
    
    $("#status).fadeIn("fast").delay(3000).fadeOut("slow");

How did we ever program without the Internet?
