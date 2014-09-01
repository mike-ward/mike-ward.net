IEnumerable Performance Tip: Any() vs. Count()
2009-11-25T00:55:23
I can’t count the number of times (unintentional pun) I’ve checked if an IEnumerable<T> sequence contains elements using Count().
    
    static void Method(IEnumerable<Status> statuses)  
    {  
        if (statuses != null && statuses.Count() > 0)  
            // do something...  
    }  
    

  


To get the count, the code has to traverse the entire sequence. On a long, lazy-executed sequences, this can take significant time. Since I only want to know if the sequence contains one or more elements, it’s computationally more efficient to use the Any() extension method.
    
    static void Method(IEnumerable<Status> statuses)  
    {  
        if (statuses != null && statuses.Any())  
            // do something...  
    }  
    

  


In this case, Any() will return after examining the first element in the sequence. It also reads a better (IMHO).
