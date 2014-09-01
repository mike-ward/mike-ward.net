New Resource Refactoring Tool for Visual Studio Released!
2008-04-11T18:06:12
After replacing about 100 strings with resource references recently, I began to wonder why Microsoft did not include a refactoring tool extract strings in code to resources. To do it currently requires switching back and forth between resource view and your code and copying strings. Tedious to say the least.

Well, ponder no more. Microsoft has released a [resource refactoring tool on CodePlex](http://www.codeplex.com/ResourceRefactoring) that does just that. Right-click, select Refactor and at the bottom of the menu you'll see a new entry labeled "Extract to Resource".

![](http://www.codeplex.com/Project/Download/FileDownload.aspx?ProjectName=ResourceRefactoring&DownloadId=3748)

Features include:

  * Works with C#, VB.Net languages. Supports all project types that ships with Visual Studio 2005 including web sites and web application projects. 
  * A preview window to show changes. 
  * Finds other instances of the text being replaced in the project automatically. 
  * Lists existing resources by their similarity level to the text being replaced. 
  * Automatically replaces hard coded string with a reference to resource entry. 

The comments say it does not work on Visual Studio 2008 but I've found that it does. YMMV.
