Visual Studio Code Cleanup Macro
2008-10-06T17:45:30
Visual Studio has an automation model that enables extensive customization. Mostly, I rely on the built in services since they meet most of my needs. However, there are a few routine things I do when I open a file. They are:

  * Add a copyright notice if it’s not there 
  * Format the code 
  * Remove and sort using directives 

This sequence is an obvious candidate for a macro and here it is:
    
    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports System.Diagnostics
    
    Public Module Module1
    
        Sub OrganizeDocument()
            Dim textSelection As EnvDTE.TextSelection
            textSelection = CType(DTE.ActiveDocument.Selection(), EnvDTE.TextSelection)
    
            If (DTE.ActiveDocument.Name.EndsWith(".cs")) Then
                textSelection.GotoLine(1)
                textSelection.SelectLine()
                Dim copyright = textSelection.Text.StartsWith("// Copyright (c)")
                textSelection.GotoLine(1)
    
                If (copyright = False) Then
                    textSelection.Insert("// Copyright (c) " & Date.Now.Year & _
                    " Blue Onion Software - All rights reserved" & _
                    Microsoft.VisualBasic.Constants.vbCrLf & Microsoft.VisualBasic.Constants.vbCrLf)
                End If
    
                DTE.ActiveDocument.DTE.ExecuteCommand("Edit.RemoveAndSort")
                DTE.ActiveDocument.DTE.ExecuteCommand("Edit.FormatDocument")
    
            ElseIf (DTE.ActiveDocument.Name.EndsWith(".xml") Or DTE.ActiveDocument.Name.EndsWith(".config") Or _
                    DTE.ActiveDocument.Name.EndsWith(".html") Or DTE.ActiveDocument.Name.EndsWith(".aspx")) Then
                textSelection.GotoLine(2)
                textSelection.SelectLine()
                Dim copyright = textSelection.Text.StartsWith("<!-- Copyright (c)")
                textSelection.GotoLine(2)
    
                If (copyright = False) Then
                    textSelection.Insert("<!-- Copyright (c) " & Date.Now.Year & _
                    " Blue Onion Software - All rights reserved -->" & _
                    Microsoft.VisualBasic.Constants.vbCrLf & Microsoft.VisualBasic.Constants.vbCrLf)
                End If
    
                DTE.ActiveDocument.DTE.ExecuteCommand("Edit.FormatDocument")
            End If
        End Sub
    
    End Module

The copyright line is placed on the second line of .xml and .html files because xml parsers and some html validators require the first line to be a directive. I assign this macro to Ctrl+Q where it is immediately accessible. Enjoy.
