Slick Command Shell Enhancement
2008-09-11T17:10:37
In Scott Hanselman’s article [”A better PROMPT for CMD.EXE or Cool Prompt Environment Variables and a nice transparent multi-prompt”,](http://www.hanselman.com/blog/ABetterPROMPTForCMDEXEOrCoolPromptEnvironmentVariablesAndANiceTransparentMultiprompt.aspx) he points out several nifty features of the command prompt. In particular, I liked his idea of using “+” to indicate the level in the PUSHD/POPD stack. Recall that PUSHD saves the current directory to an internal stack before changing to the specified directory. Typing POPD takes you back to the previous directory. PUSHD and POPD are a bit long to type so I usually abbreviate them as “pd” and “dp” respectively. Problem is, after years of using “CD” to change directories I find that even these shortcuts don’t quite cut it.

What I really want is to have “CD” do the push and pops automatically. CD with parameters should call PUSHD, and CD with no parameters should call POPD. Couple this with the “+” indicator to indicate the stack depth and you have a slick little command shell enhancement.

To “reprogram” the “CD” command, I turned to an old friend, DosKey. DosKey is the program that allows you to edit command lines, recall previously typed commands and define macros. DosKey ships with Windows. You can define macros by placing them in a file and then passing the file to DosKey. Here’s my “doskey.config” macro file.
    
    e="c:\program files\emeditor\emeditor" $*
    ct=cleartool $*
    b="d:\data\Visual Studio 2008\Projects\BEdit\BEdit\bin\Release\BEdit.exe" $*
    cd=IF [$1]==[] (popd) ELSE (pushd $*)

As you can see, when I want to edit a file, I type “e filename”. That saves a few hundred keystrokes a day.

Of particular interest is the last line. The logic is straightforward. Call POPD if there are no parameters or PUSHD if there are parameters. To load these macros, modify your command prompt shortcut to call DosKey with the perquisite config file. I modified the “VS 2008 Command Prompt” shortcut as follows:
    
    %comspec% /k ""C:\Program Files\Microsoft Visual Studio 9.0\VC\vcvarsall.bat"" x86 & 
    doskey /MACROFILE=c:\bin\doskey.config

_Note: the command should all be on one line._

Next, modify the command prompt. You can see Scott’s article for details. Here’s mine:

![prompt](http://az667460.vo.msecnd.net/cdn/images/blog/SlickCommandShellEnhancement_A8C2/prompt.png)

$P$G is the standard prompt. The $+ is what adds the “+” indicating the stack depth. Here’s an example of how it works.

![cmdprompt](http://az667460.vo.msecnd.net/cdn/images/blog/SlickCommandShellEnhancement_A8C2/cmdprompt.png)
