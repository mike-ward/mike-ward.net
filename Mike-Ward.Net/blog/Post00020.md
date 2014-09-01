Anonymous Methods, Method Group Conversions and EventHandler
2006-08-26T00:59:03
One of my favorite new features of C# 2.0 is Anynomous Methods. Anynomous Methods allow you to write event handlers inline instead of assigning a method. Often times this is handier, especially when you're doing something simple like incrementing a counter or displaying a message. 

In .Net 1.1 it would have looked like this: 

`public void button_OnClick(object sender, EventArgs ea)  
{   
MessageBox.Show("Ouch!");   
` `} `

`myButton.Click += new EventHandler(button_OnClick); `

In .Net 2.0 it's a one liner: 

`myButton.Click += delegate { MessageBox.Show("Ouch!"); };`

This is a nice improvement for simple event handlers. More complex event handlers should use the older form. Also, the older form allows your code to be used by multiple event handlers. 

**Method Group Conversions**

If you look a bit closer at the previous example you may notice that an implicit type conversion occurs to match the delegate to the event handler. This implicit conversion is possible because the parameter list and return type of the delegate type are compatible with the anonymous method 

An anonymous method can be implicitly converted to a compatible delegate type. C# 2.0 permits this same type of conversion for a method group, allowing explicit delegate instantiations to be omitted in almost all cases. Refering to the first example: 

`myButton.Click += new EventHandler(button_OnClick);`

can be written as: 

`myButton.Click += button_OnClick;`

When the shorter form is used, the compiler automatically infers which delegate type to instantiate, but the effects are otherwise the same as the longer form. 

**EventHandler<T>**

A final little goody is EventHander<T> class. This fellow saves you a few more keystrokes and consolidates an event and delegate declaration into one statement. For example:

`public delegate void MyEventHandler(object sender, MyEventArgs ea);  
public event MyEventHandler myEvent; `

can be written as: 

`public event EventHandler myEvent;`

An additional advantage of using EventHandler<T> is that you do not need to code your own custom delegate if your event generates event data. Furthermore, the .NET Framework needs only one implementation to support EventHandler regardless of the event data type you substitute for the generic type parameter. 

Some of this may look like syntatic surgar but it really is laying the ground work for C# 3.0 where anonymous methods and generics really start to shine
