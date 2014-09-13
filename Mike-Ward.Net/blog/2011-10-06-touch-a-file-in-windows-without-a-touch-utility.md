Touch a File in Windows without a Touch Utility
2011-10-06T17:42:46
One of those annoying omissions in Windows is the lack of a Touch utility to update the timestamp of a file. There are dozens of freeware programs available to do this but what if you’re updating something on a corporate system where you don’t have such a utility?

Your can do this from a plain old DOS command as follows:
    
    copy /b Source+,,

  


where Source is the name of a file. 

This updates the current time and date of the file without modifying it. Believe it or not, this is documented behavior! ([Copy command](http://technet.microsoft.com/en-us/library/bb490886.aspx))
