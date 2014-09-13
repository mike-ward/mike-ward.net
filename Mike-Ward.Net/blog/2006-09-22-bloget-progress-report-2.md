Bloget Progress Report #2
2006-09-22T17:45:47
Work continues to go well on Bloget. I'm feature complete now for the first release which will be an alpha release of some sort. I'm still pretty happy with my little project as it continues to grow and take on new attributes. There are numerous little deployment issues I need to deal with now and one minor architectural issue.

The architectural issue involves how I persist tags or categories for entries. I'm seeing from my own use that this is a fairly important component of blogging so I want to optimize the storage solution so it can handle all the things I think it should do.

Perhaps the biggest time sink as of late was coming up with an integrated backup solution. Again, looking at how I use Bloget for this blog, I noticed that backing up was just enough of a chore that I wasn't doing it as often as I should. Granted it's just a directory of files but I had to fire up an FTP program, download the files, zip them and label the file. Just more effort than I'm willing to do regularly and I'm fairly anal about backups. Adding a feature to zip up the files and download them on demand turned out to be more work than I expected however.

I remembered that .Net 2.0 had compression routines but after a few minutes of working with them I realized that there was no archive support (like PKZip). Going to the Internet yielded the Sharp libraries but it looked like more of job to integrate than I wanted to deal with and there were some rumblings about it being buggy. So then I investigated the PKZip archive format. It's really quite simple so I wrote up an implementation only to discover that the DeflateStream algorithm is not compatible with the PKZip deflate algorithm. Nuts. Then I discovered that J# has a zip compatible archive. Coded that up. Worked great but when I uploaded to my Web hosting service (GoDaddy) I discovered the J# redistributables were not part of their 2.0 service. Nuts again. Finally, I returned to the Sharp libraries. It took all of 10 minutes to retro-fit the code into my code base. Works like a charm. Now I can log into the Administration panel in Bloget, click a button, and one zip file is formatted and presented downloaded. The only downside is that it is 68K when compiled which literally doubled the size of my binary. Bummer.

Added some more features to comments. Comments can now be disabled globally or by posting. Also the maximum number of comments per post can be set. I'll add comment aging in the next release.

Documentation is going to be a bear as well. I've been putting it off. I actually try to write useful documentation for my products. It's work but users seem to appreciate it.

If you're still reading this it's a good bet you might be interested in Bloget. I need a few brave souls to test bloget. If you're interested, send me an email and tell me how you intend to use it and where you'll host it. - Mike
