Use LINQ Aggregate to Create Comma Separated Lists
2009-09-06T12:34:08
It’s a common problem. You’re handed a collection of strings or numbers and you need emit a comma separated list. The usual approach I’ve seen (and done) is to resort to a loop and some check to if it’s the first or last element to control when the comma is added.
    
    var items = new string[] { "Wine", "Cheese", "Bread" };  
    bool first = true;  
    string picnicItems = string.Empty;  
      
    foreach (var item in items)  
    {  
        if (!first)  
            picnicItems += ", ";  
      
        first = false;  
        picnicItems += item;  
    }  
    

  


I’ve always felt dissatisfied with doing this but could never find the energy to do something about it.

Enter the LINQ Aggregate extension method. As the name implies, it will “Aggregate” an IEnumerable using a given function.
    
    var items = string[] { "Wine", "Cheese", "Bread" };  
    var picnicItems = items.Aggregate((s1,s2) => s1 + ", " + s2);  
    

  


Much nicer IMHO. Also, if there is only one item in the list, it correctly creates the string without the comma. Sweet!
