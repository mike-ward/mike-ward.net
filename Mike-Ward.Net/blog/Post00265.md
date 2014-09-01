Events and Delegate Shortcuts in C#
2008-04-02T14:44:40
The syntax for events and delegates has always struck me as a bit bulky and hard to remember. For instance, to declare an Alarm event seen in many of the Microsoft code samples, you declare a handler type and an event of that handler type as follows:
    
    public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);
    public event AlarmEventHandler Alarm;

It's a bit wordy and there's a naming convention to remember as well. With .NET 2.0 however, the class library contains a generic delegate that makes declaring events a more intuitive.
    
    [SerializableAttribute]
    public delegate void EventHandler<TEventArgs>(
        Object sender,
        TEventArgs e
    ) where TEventArgs : EventArgs

Using the EventHandler generic delegate, the Alarm event can now be expressed in one line with a more natural syntax
    
    public event EventHandler<AlarmEventArgs> Alarm;

Another nice syntax shortcut introduced in .NET 2.0 is delegate inferencing. Assume we have a class instance _clock_ that has an Alarm event. Here's a .NET 1.1 example of adding an event handler:
    
    clock.Alarm += new AlarmEventHandler(someMethodThatHandlesEvent);

The handler _someMethodThatHandlesEvent_ is a method declared elsewhere. In 2.0 the compiler knows the type that _clock.Alarm_ can accept and will new up the correct handler for us. This yields a more natural and readable syntax:
    
    clock.Alarm += someMethodThatHandlesEvent;

Often, event handlers are simple and can consist of one line code. In .NET 1.x only named delegates were supported so you had to put your handler code in a separate method. For simple event handlers, inlining the event handler can make the code more understandable. With the introduction of anonymous methods in .NET 2.0, we can eliminate the named method and inject the code directly.
    
    clock.Alarm += delegate(object sender, AlarmEventArgs e) { Console.Write("Alarm"); };

And since we're not using the arguments in our event handler there's an additional shortcut where we eliminate the argument declarations.
    
    clock.Alarm += delegate { Console.Write("Alarm!"); };

This yields a statement that is much easier to understand (IMHO).

If you're using the C# 3.5 compiler, the expression can be made even more compact using a Lambda expression:
    
    clock.Alarm += (o, e) => Console.Write("Alarm!");

I'm often surprised to see even seasoned C# programmers who don't know these handy syntax shortcuts. Not only do they make the code more readable, it requires less typing.
