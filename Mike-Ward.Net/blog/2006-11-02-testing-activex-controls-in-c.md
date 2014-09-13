Testing ActiveX Controls in C#
2006-11-02T00:07:06
Using COM in managed code can seem like uneasy truce at times. Take the AxHost wrapper class for instance. When using ActiveX controls in C#, Visual Studio will generate an AxHost wrapper class that builds a facade around the unmanaged code. Problem is, the constructor for this AxHost wrapper class doesn't actually check if it can create the control. Instead, the wrapper waits until a method is called that requires the actual ActiveX control and only then does it try to create it.

This "lazy" construction technique can cause problems. For instance, if the ActiveX control is not installed, the wrapper will raise an exception. As often as not, this exception occurs in the InitializeComponent() method of a Windows.Form control in an EndInit() call. There's not much you can do at that point but to kill the form and display an error message.

Such was the case for me recently. In this particular case the Form and the program could still meaningfully function despite the absence of the ActiveX control. The AxHost wrapper doesn't offer a good way to test if the control can be created. Calling AxHost.CreateControl() directly for instance raises an exception.

About the only sure-fire way I could test if the control was create-able was to create it. The code below does just that. It uses **System.Activator**, one of those little nuggets buried in the .NET framework.

bool CanCreateComControl(Guid CLSID_Item)  
{  
try  
{  
Type itemType = Type.GetTypeFromCLSID(CLSID_Item, true);  
object item = System.Activator.CreateInstance(itemType);  
System.Runtime.InteropServices.Marshal.ReleaseComObject(item);  
}

catch  
{  
return false;  
}

return true;  
}

Knowing ahead of time that the wrapper class would fail to create the control allowed me to gracefully degrade the functionality of the application and avoid aborting the creation of the form.
