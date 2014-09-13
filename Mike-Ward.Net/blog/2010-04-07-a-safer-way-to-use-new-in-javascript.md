A safer way to use new in JavaScript
2010-04-07T23:47:48
In JavaScript, when you make a new object, you can select an object to use as a prototype for the new object. This is “Prototypal Inheritance”, and it’s one of the key features that makes JavaScript different than classical inheritance languages like Java and C#. It also has a serious deficiency that we’ll get to in a moment.

Typically, you define a constructor and augment its prototype. Borrowing an example from [Douglas Crockford’s](http://www.crockford.com/) book, “JavaScript, the Good Parts”, we create a Mammal object as follows:
    
    var Mammal = function (name) {  
      this.name = name;  
    };  
      
    Mammal.prototype.say_name = function () {  
      return "My name is " + this.name;  
    };  
      
    var mammal = new Mammal("Rhino");  
    mammal.say_name();

  


There are better and easier ways to create objects in JavaScript, but you’ll see this pattern often because it is the language designed way of creating objects. 

In general the use of “**new**” is not recommended by Crockford. The reason why is that if you forget to use “**new**” when creating _mammal_, you’ll end up modifying the global object (_this_ will point to the browser’s global _window_ object). This accidental (and often fatal) modification of the global object is the main reason Crockford does not recommend using “**new**”.

Fortunately, there’s an easy fix to keep from accidentally misusing the constructor.
    
    var Mammal = function (name) {  
      _if (this === window) { throw Error(); }_  
      this.name = name;  
    };  
      
    Mammal.prototype.say_name = function () {  
      return "My name is " + this.name;  
    };  
      
    var mammal = new Mammal("Rhino");  
    mammal.say_name();

The underlined code prevents calling the constructor in the context of the global object.
