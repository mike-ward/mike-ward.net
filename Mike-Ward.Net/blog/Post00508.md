Nested Switch Statements to Table Lookup using LINQ
2009-09-20T12:31:16
_Note: My colleague _[_Brian Genisio_](http://geekswithblogs.net/HouseOfBilz/Default.aspx)_ deserves much of the credit for this work. He urged me to consider a functional approach during a code review and then later contributed significantly to the code and this article. Check out his blog. Trust me, you’ll be a better programmer for it. _

_Note 2: This isn’t so much a “How to" as it is a “What I did” article. I would be really interested in any comments on this approach or other approaches. Even how it might be done in other languages like Ruby._

I was refactoring some code I wrote a few months ago and ran across this (illustrative example from original code):
    
    static Expression<Func<Part, bool>> PartsFilter(FieldId field, Condition condition, string value)  
    {  
        switch (field)  
        {  
            case FieldId.Id:  
                switch (condition)  
                {  
                    case Condition.Is: return part => part.Id == Convert.ToInt32(value);  
                    case Condition.LessThan: return part => part.Id < Convert.ToInt32(value);  
                    case Condition.GreaterThan: return part => part.Id > Convert.ToInt32(value);  
                }  
                break;  
      
            case FieldId.Name:  
                switch (condition)  
                {  
                    case Condition.Is: return part => part.Name.CompareTo(value) == 0;  
                    case Condition.Contains: return part => part.Name.Contains(value);  
                    case Condition.StartsWith: return part => part.Name.StartsWith(value);  
                    case Condition.LessThan: return part => part.Name.CompareTo(value) < 0;  
                    case Condition.GreaterThan: return part => part.Name.CompareTo(value) > 0;  
                }  
                break;  
      
            case FieldId.Description:  
                switch (condition)  
                {  
                    case Condition.Is: return part => part.Description.CompareTo(value) == 0;  
                    case Condition.Contains: return part => part.Description.Contains(value);  
                    case Condition.StartsWith: return part => part.Description.StartsWith(value);  
                    case Condition.LessThan: return part => part.Description.CompareTo(value) < 0;  
                    case Condition.GreaterThan: return part => part.Description.CompareTo(value) > 0;  
                }  
                break;  
        }  
      
        throw new InvalidOperationException();  
    }

  


It gets the job done . Also, there were about 20 top-level case statements in the original code so it spanned multiple pages which made it hard to visualize.

Given the repetitive nature of the the code, it really warrants some kind of lookup table. At the time, I was just coming up to speed on LINQ to SQL and Dynamic Predicate Building so “Getting it to just work” was my primary concern.

You’ll notice that the switch statement is just a double lookup: Find a given Part, filtered by a Part descriptor and an additional search criteria. Since I’m building my query expression dynamically, what I want to return here is a Predicate describing the filter. (Reminder, a predicate here is just a function that takes an argument and returns a bool). That’s what the switch statement is doing.

Here’s the same solution using a lookup table.
    
    class FieldCondition : Dictionary<FieldId, ConditionFilter> { }  
    class ConditionFilter : Dictionary<Condition, Func<string, Expression<Func<Part, bool>>>> { }  
      
    static readonly FieldCondition _filters = new FieldCondition  
    {  
        { FieldId.Id, new ConditionFilter {   
            { Condition.Is, val => part => part.Id == Convert.ToInt32(val) },  
            { Condition.LessThan, val => part => part.Id < Convert.ToInt32(val) },  
            { Condition.GreaterThan, val => part => part.Id > Convert.ToInt32(val) }}  
        },   
        { FieldId.Name, new ConditionFilter {   
            { Condition.Is, val => part => part.Name.CompareTo(val) == 0 },  
            { Condition.Contains, val => part => part.Name.Contains(val) },  
            { Condition.StartsWith, val => part => part.Name.StartsWith(val)},  
            { Condition.LessThan, val => part => part.Name.CompareTo(val) < 0 },  
            { Condition.GreaterThan, val => part => part.Name.CompareTo(val) > 0 }}  
        },   
        { FieldId.Description, new ConditionFilter {   
            { Condition.Is, val => part => part.Description.CompareTo(val) == 0 },  
            { Condition.Contains, val => part => part.Description.Contains(val) },  
            { Condition.StartsWith, val => part => part.Description.StartsWith(val)},  
            { Condition.LessThan, val => part => part.Description.CompareTo(val) < 0 },  
            { Condition.GreaterThan, val => part => part.Description.CompareTo(val) > 0 }}  
        }   
    };
    
    // The PartsFilter method reduces down to a single line:  
    static Expression<Func<Part, bool>> PartsFilter(FieldId field, Condition condition, string value)  
    {  
        return _partsFilter[FieldId.Name][Condition.StartsWith]("spring");  
    }

  
The interesting bit here is double dictionary declaration:
    
    class FieldCondition : Dictionary<FieldId, ConditionFilter> { }  
    class ConditionFilter : Dictionary<Condition, Func<string, Expression<Func<Part, bool>>>> { }

  


It looks a little daunting until you take it apart. It actually reads naturally left to right. It’s a dictionary of FieldId returning a dictionary of Condition returning a function that takes a string that returns an expression. The dictionary part is easy enough to understand but the “Function taking a string returning an expression” might be less familiar.
    
    Func<string, Expression<Func<Part, bool>>>

  


If you work in LINQ to SQL for any length of time the Expression<Func<Part, bool>> part should be familiar. Because I need to pass a string to the filter for the comparison, I’ve wrapped the expression in a function that takes the string value.

The final part is constructing the lambda expression to express the filter. A lambda expression is a good choice here because it’s a concise and compact way of communicating intent. In this case, we have a lambda “going into” a lambda. A bit unusual but totally legal (and kind of cool looking).
    
    val => part => part.Name.StartsWith(val)

  


In the end, the code is not much smaller so what have we gained here? The first version is imperative where the second version is functional. The first version has control flow, which has more opportunities for subtle bugs. The second version, however, is really just a lookup table of functions to be executed so it is more maintainable. Not only is it easy to retrieve the expression from the lookup table to generate new expressions, it is now possible to work with the lookup table like data.

For instance, if you need to get a list of all expressions that respond to a particular condition, you can extract it from the table:
    
    public IEnumerable<Expression<Func<Part, bool>>> PartsFiltersOfCondition(Condition condition, string value)   
    {  
        return from conditionFilter in _filters.Values   
                   let partsFilter = conditionFilter[condition]   
                   select partsFilter(value);   
    }  
    

  


Calling PartsFiltersOfCondition(Condition.Is, “spring”) will return all filters that contain Condition.Is and generate the expression for you.

Try doing THAT with a switch statement :) 
