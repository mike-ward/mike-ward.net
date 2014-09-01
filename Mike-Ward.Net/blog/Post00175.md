Getting the current date and time in batch files
2007-06-07T01:49:47
_I completely stole this article from _[_here_](http://simultaneouspancakes.com/Lessons/archives/2006/04/getting_the_cur.shtml)_. It's such a useful bit of information I'm blogging it so I can "Google" myself later._

I still do the occasional batch file solution for tasks, and sometimes I need to get the current date and time on the system for processing. Since I just had to research this again for another little project, I decided it was high time to blog it.

Batch files can use the system variables %DATE% and %TIME% to get the current date and time of the system. These variables return data in the following format:

%DATE% gives DOW MM/DD/YYYY (may vary depending on you location - you can run echo %DATE% at a command prompt to see what values you get). So for today, as I'm writing this post, the output is: 

Sun 04/02/2006

%TIME% gives HH:MM:SS.hh where HH is hour (in 24-hour format), MM is minute, SS is seconds, and hh is hundredths of seconds. Who needs hundredths of seconds? Don't know for sure, but it's there if you want.

This is all well and good, but what if you only need to know the current minute? Easy! Batch files give you away to pull substrings out of variables right in the batch file. If I only want to know what the current minute is, I can reference that as %TIME:~3,2%.

> Side note: a quick explanation of this parsing. The ":~" characters tell the batch file to return a subset of data from the variable. The number that immediately follows :~ is the character position to start with, and the first character in the string is always 0. So %TIME:~0% is functionally equivalent to %TIME%. Optionaly after the number can be a comma followed by another number, indicating how many characters to include. So the reference %TIME:~3,2% tells the batch file to return two characters starting at position 3 from the current time. In other words, the two characters that represent the current minute.
> 
> In addition, if you want the last two digits of the year (for those who still use a 2-digit year value) you can reference %DATE:~-2%. The "-2" indicates the last two characters in the string, so you don't have to count the entire string length. If you want the four-digit year, use %DATE:~-4%.

Rather than figure all this out every time, here's a quick menu of values that I use regularly.

ItemVariable

Current hour:
%TIME:~0,2%

Current minute:
%TIME:~3,2%

Current second:
%TIME:~6,2%

Current day of week:
%DATE:~0,3%

Current month:
%DATE:~4,2%

Current day date:
%DATE:~7,2%

Current year (2 digit):
%DATE:~-2%

Current year (4 digit):
%DATE:~-4%
