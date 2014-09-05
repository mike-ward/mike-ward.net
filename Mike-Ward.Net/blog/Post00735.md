VSColorOutput Version 1.1
2012-01-15T15:50:14
You can read more about VSColorOutput [here](/blog/post/2011/12/28/vscoloroutput-visual-studio-output-coloring-extension). Version 1.1 is a maintenance release that fixes two bugs and captures more error conditions in the build output.

I had a few reports that the options dialog would sometimes come up blank or cause a fault. This bug was insanely frustrating in that A: it happened only on a few systems and, B: The rest of the extension actually worked even when the dialog didn't. Now how does that happen you ask? 

VSColorOutput has a bit of a split personality as extensions go. It uses the MEF ([Managed Extensibility Framework](https://mef.codeplex.com/)) extension points to do the color classification of the output lines, but has to fall back to the older COM interfaces to access the options UI. Since I started out the project as a MEF extension, I didn't have the secret sauce in the solution to register as an ActiveX control so the UI could find the assembly. The weird part is most of the time it worked anyways. Writing Visual Studio extensions is a bit like alchemy - you just keep mixing stuff together to see what happens and hope it will work.

I've also added some additional search patterns to classify stack traces as errors since stack traces usually only occur only in the context of an error.

A bug involving "null" search patterns was resolved.

**VSColorOutput also Colors Debug Output**

A colleague mentioned (dismissively) that he didn't use VSColorOutput because he never looks at build output. That may be true, but I don't know a developer that doesn't look at debug output and VSColorOutput works here as well. In fact, coloring debug output was the original reason I wrote VSColorOutput. I wanted to highlight trace output for an issue I was tracking. It's great for spotting WPF/Silverlight binding errors as well.

**Future Features**

  * Stop build on first error – On larger projects this can be a time saver. I understand it's a somewhat hard problem to solve so any suggestions on how to do this are appreciated.
  * Show total build time – When I build at the console, MSBuild shows the total build time at the end of run. When I build in Visual Studio, it doesn't. Annoying.
  * Show output window on debug – This is somewhat specialized to my needs. I run the debug window in a tabbed window instead of a tiled window. Visual Studio flips back to the last source window when starting a debug session. I want to see the debug window instead (and all those pretty colors).
  * Inline highlighting – Currently, VSColorOutput highlights the entire line. I've worked out a way to only highlight the matched portion of the pattern but honestly, I can't think of a use case for this. I'll leave it out unless someone can make a compelling use case.

Please vote on the features above or add your own suggestions. They should be build or debug related requests. I want to keep VSColorOutput small and true to its roots.

You can download VSColorOutput from the _Visual Studio Extension Manager_ dialog. VSColorOutput is open source and can be found at: [http://vscoloroutput.codeplex.com](http://vscoloroutput.codeplex.com).
