AsyncCommand Implementation in WPF
2013-08-09T15:44:37
I found this nifty implementation of a asynchronous command using the new [async/await](http://msdn.microsoft.com/en-us/library/vstudio/hh191443.aspx) syntax in C# 4.5 in some code I was reviewing. Nice abstraction.
    
    using System;  
    using System.Threading.Tasks;  
    using System.Windows.Input;  
      
    namespace OpenWeather.Command  
    {  
        internal class AsyncCommand : ICommand  
        {  
            private readonly Func<Task> _execute;  
            private readonly Func<bool> _canExecute;  
            private bool _isExecuting;  
      
            public AsyncCommand(Func<Task> execute) : this(execute, () => true)  
            {  
            }  
      
            public AsyncCommand(Func<Task> execute, Func<bool> canExecute)  
            {  
                _execute = execute;  
                _canExecute = canExecute;  
            }  
      
            public bool CanExecute(object parameter)  
            {  
                return !(_isExecuting && _canExecute());  
            }  
      
            public event EventHandler CanExecuteChanged;  
      
            public async void Execute(object parameter)  
            {  
                _isExecuting = true;  
                OnCanExecuteChanged();  
                try  
                {  
                    await _execute();  
                }  
                finally  
                {  
                    _isExecuting = false;  
                    OnCanExecuteChanged();  
                }  
            }  
      
            protected virtual void OnCanExecuteChanged()  
            {  
                if (CanExecuteChanged != null) CanExecuteChanged(this, new EventArgs());  
            }  
        }  
    }

  


Original article and license: [http://www.codeproject.com/Articles/630248/WPF-OpenWeather](http://www.codeproject.com/Articles/630248/WPF-OpenWeather)
