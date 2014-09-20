Tweetz Desktop Update &ndash; Localization
2013-11-26T20:01:32
[![3892](http://az667460.vo.msecnd.net/cdn/images/blog/Windows-Live-Writer/Tweetz-Desktop-Update--Localization_CDF9/3892_thumb.jpg)](http://az667460.vo.msecnd.net/cdn/images/blog/Windows-Live-Writer/Tweetz-Desktop-Update--Localization_CDF9/3892_2.jpg)Version 0.7.0 introduces one new feature – Localization.

So how many languages does Tweetz Desktop support? Well at the moment, exactly one. This is where you come in.

You can translate Tweetz Desktop to your language by editing a single file. Here's what to do:

Look in the folder where Tweetz Desktop is installed and locate the **tweetz5.exe.locale** file.

Open **tweetz5.exe.locale** in Notepad or other _text editor_. Don't use a word processor like Microsoft Word. It will insert hidden characters into the file and make it unusable.

Copy the section with the Name of "en" and paste it after last curly brace ( **}** ).

Look up the [ISO two letter code](http://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) for your language.

In the new section, replace the "en" name with the new code.

Translate the new section strings. Don't touch the items with underscores "_" in them. They're the identifiers used internally and cannot change.

Once you're happy with your new translation, send it me for inclusion in a later version.

Current version is 0.7.0

Available on the [downloads page](/downloads).
