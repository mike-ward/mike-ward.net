Handling Double Clicks in Silverlight
2008-12-18T22:13:53
Silverlight has no event for handling double-clicks. Here’s an [excellent article](http://weblogs.asp.net/aboschin/archive/2008/03/17/silverlight-2-0-a-double-click-manager.aspx) detailing a way to add double click detection and handling by Andrea Boschin. While the code is acceptable, I couldn’t resist refactoring the code a bit to make a few improvements and add testability.

[![kick it on DotNetKicks.com](http://www.dotnetkicks.com/Services/Images/KickItImageGenerator.ashx?url=http%3a%2f%2fblueonionsoftware.com%2fblog.aspx%3fp%3da9f50eb2-4c32-4be5-a71d-3fc75a785787)](http://www.dotnetkicks.com/kick/?url=http%3a%2f%2fblueonionsoftware.com%2fblog.aspx%3fp%3da9f50eb2-4c32-4be5-a71d-3fc75a785787)

Here’s the original code.
    
    public class MouseClickManager
    {
        public event MouseButtonEventHandler Click;
        public event MouseButtonEventHandler DoubleClick;
    
        private bool Clicked { get; set; }
        public Control Control { get; set; }
        public int Timeout { get; set; }
    
        public MouseClickManager(Control control, int timeout)
        {
            this.Clicked = false;
            this.Control = control;
            this.Timeout = timeout;
        }
    
        public void HandleClick(object sender, MouseButtonEventArgs e)
        {
            lock(this)
            {
                if (this.Clicked)
                {
                    this.Clicked = false;
                    OnDoubleClick(sender, e);
                }
                else
                {
                    this.Clicked = true;
                    ParameterizedThreadStart threadStart = new ParameterizedThreadStart(ResetThread);
                    Thread thread = new Thread(threadStart);
                    thread.Start(e);
                }
            }
        }
    
        private void ResetThread(object state)
        {
            Thread.Sleep(this.Timeout);
    
            lock (this)
            {
                if (this.Clicked)
                {
                    this.Clicked = false;
                    OnClick(this, (MouseButtonEventArgs)state);
                }
            }
        }
    
        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEventHandler handler = Click;
    
            if (handler != null)
                this.Control.Dispatcher.BeginInvoke(handler, sender, e);
        }
    
        private void OnDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEventHandler handler = DoubleClick;
    
            if (handler != null)
                handler(sender, e);
        }
    }

The idea here is to capture the first click and spawn a thread that waits for the given timeout. If another click is detected during the wait, the double click handler is called. If the timer expires, the click event is called. This works well but it has some issues I don’t care for.

  * lock(this) – Essentially an antipattern. Locking _this_ is considered harmful and can lead to dead locks. 
  * Handlers are locked – Locking handler code just seems dangerous 
  * Every time the Click property is accessed it’s set to !Click – Seems like something that could go in a function 
  * It’s not testable 

Here’s my refactoring.
    
    public class MouseClickAdapter
    {
        bool _clicked;
        Control _control;
        int _timeout;
        object _syncObject = new object();
    
        public event MouseButtonEventHandler Click;
        public event MouseButtonEventHandler DoubleClick;
    
        public MouseClickAdapter(Control control, int timeout)
        {
            _control = control;
            _timeout = timeout;
        }
    
        public void ClickHandler(object sender, MouseButtonEventArgs e)
        {
            if (Clicked())
                OnDoubleClick(sender, e);
    
            else
                ThreadPool.QueueUserWorkItem(ClickWaitThread, e);
        }
    
        bool Clicked()
        {
            lock (_syncObject)
            {
                _clicked = !_clicked;
                return !_clicked;
            }
        }
    
        void ClickWaitThread(object state)
        {
            Thread.Sleep(_timeout);
    
            if (Clicked())
                OnClick(this, (MouseButtonEventArgs)state);
        }
    
        void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (Click != null)
            {
                if (_control != null)
                    _control.Dispatcher.BeginInvoke(Click, sender, e);
    
                else
                    Click(sender, e);
            }
        }
    
        void OnDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DoubleClick != null)
                DoubleClick(sender, e);
        }
    }

The _Clicked()_ method encapsulates the toggling of the click state when it is accessed and returns the previous state for testing. Also, an object is added to handle locking. This is considered a safer practice than locking the instance. Also, the handlers are no longer locked. So what about testability?

The issue is that a **Control** object is needed to handle the _BeginInvoke_ dispatch. This is necessary because the _OnClick_ handlers must be called from a UI thread. Unit testing does not employ UI threads so you’re seemingly stuck.

When you commit to writing tests for your code as I have done, you often run into these situations. However, with a little creative thinking, you can work around many of these issues. Sometimes, the best course of action is to modify the code slightly to handle conditions unique to testing.

In this case, the _OnClick_ handler checks if __control_ is null and calls the click handlers directly if that’s the case. It’s a bit hacky but it gets the job done. Now I can easily write my tests.
    
    [TestFixture]
    public class MouseClickAdapterTests
    {
        [Test]
        public void ClickTest()
        {
            bool called = false;
            var mouseClickAdapter = new MouseClickAdapter(null, 150);
            mouseClickAdapter.Click += (sender, eventArgs) => called = true;
            mouseClickAdapter.ClickHandler(null, null);
            Thread.Sleep(500);
            Assert.IsTrue(called);
        }
    
        [Test]
        public void DoubleClickTest()
        {
            bool called = false;
            var mouseClickAdapter = new MouseClickAdapter(null, 500);
            mouseClickAdapter.DoubleClick += (sender, eventArgs) => called = true;
            mouseClickAdapter.ClickHandler(null, null);
            mouseClickAdapter.ClickHandler(null, null);
            Assert.IsTrue(called);
        }
    
        [Test]
        public void TwoClicksSeperatedByLongPeriod()
        {
            bool called = false;
            var mouseClickAdapter = new MouseClickAdapter(null, 150);
            mouseClickAdapter.Click += (sender, eventArgs) => called = true;
            mouseClickAdapter.DoubleClick += (sender, eventArgs) => Assert.Fail();
            mouseClickAdapter.ClickHandler(null, null);
            Thread.Sleep(900);
            mouseClickAdapter.ClickHandler(null, null);
            Assert.IsTrue(called);
        }
    }

I find I almost always refactor code I find on the Internet. Most of the time I do this to make code testable but sometimes I find it’s the best way to understand code.
