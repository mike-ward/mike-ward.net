Is "is" the forgotten C# keyword?
2008-04-05T12:14:21
When's the last time you've seen or used the "is" keyword in code? It can often be used instead of the "as" keyword. Here's an example from a Microsoft help file.
    
    // CanExecuteRoutedEventHandler that only returns true if
    // the source is a control.
    public void CanExecuteCustomCommand(object sender, CanExecuteRoutedEventArgs e)
    {
        Control target = e.Source as Control;
    
        if(target != null)
        {
            e.CanExecute = true;
        }
        else
        {
            e.CanExecute = false;
        }
    }

The intent is plain enough. Return true only if the source routing the command is a Control. However, 10 lines of code (including white space) seems a bit excessive for so simple a test. The following one-liner does the same thing and it's easier to understand.
    
    public void CanExecuteCustomCommand(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = (e.Source is Control);
    }

What do you think?
