Using Attributes to Exclude Code from Coverage in TestDriven.Net
2008-05-02T00:58:35
There are times when you don't want your coverage level penalized for code not covered. Often this occurs with code that is produced from a code generator. Since [TestDriven.Net](http://www.testdriven.net) invokes [NCover](http://www.ncover.com) with the `//ea CoverageExcludeAttribute` switch, it's relatively easy remove code from the coverage statistics.

First, define the CoverageExclude attribute. Make sure to declare it outside of any namespace scope (I made this mistake and struggled for 10 minutes to figure out why it didn't work). It's best to define the attribute in your non-test code to reduce couplings between assemblies. The attribute requires no methods beyond the default constructor.
    
    public class CoverageExcludeAttribute : System.Attribute { }

Then decorate the modules, classes, methods and propertes you want to exclude.
    
    [CoverageExclude]
    public class SomeClass { }

The next time you run TestDriven.Net and select coverage, the decorated code will be excluded from coverage.

You can capture more information about who excluded the code and why by doing the following:
    
    public class CoverageExcludeAttribute : System.Attribute
    {
        public string Author { get; private set; }
        public string Reason { get; private set; }
    
        public CoverageExcludeAttribute(string author, string reason)
        {
            Author = author;
            Reason = reason;
        }
    }

(Don't you just love auto implemented properties?)

Use it as follows:
    
    [CoverageExclude("Mike", "I not sure yet")]
    public class SomeClass { }

If you want reports produced by NCoverExplorer to report these exclusions, you can use the techniques documented [here](http://basildoncoder.com/blog/2008/02/20/reporting-on-ncover-exclusions/).
