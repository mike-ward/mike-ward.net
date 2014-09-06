Themes for Tweetz 3.1–You can help
2010-11-03T00:08:50
I’ve received lots about half a dozen translations for [tweetz](/tweetz) to date. Thanks to everyone who helped. I’ve included the translations in this updated version. Localizations include German, Spanish, Portuguese (BR), Japanese, Swedish, and Turkish. I missed a couple of strings in the original locale.js file. If you see a non-localized string, send me a translation. And of course, other languages are certainly welcome. For non-Latin languages, UTF-8 encoding is required.

![2010-11-02 19h53_06](/content/images/blog/Tweetz-3.1_1116C/2010-11-02-19h53_06.png)Also note that I have not localized date and number formats yet.

I’m also introducing themes in this revision. I’ve reworked the style sheets to make it easier to modify colors. You can tweak the layout as well, but that’s much harder. I’ve included two themes, the original and a “White” theme that uses colors similar to Facebook.

You can switch between the themes by pressing Ctrl+Q (the gadget has to have the input focus of course). Themes are are located in the

\Users\{user}\AppData\Local\Microsoft\Windows Sidebar\Gadgets\tweetz3.gadget\css

There are three files there.

  * base.css
  * original.css
  * white.css

Base is of course the base styles. Don’t edit or change this. Original.css is the original dark theme and White.css is the new theme (pictured right). Note: you can’t just add more .css files to the folder. The code only looks for the original.css and white.css files.

I would suggest editing the White.css file to create your own theme. You’ll need an understanding of cascading style sheets. Also, edit the file with notepad, not WordPad or Word. WordPad and Word will insert junk into the file that will mess up the gadget layout.

You’ll also notice that the nav bar icons have changed. Yep, we’re back to the ever divisive issue of nav bar icons. Go ahead, send me your hate mail. Tell me how I “Just don’t get it”. Get it out of your system now, so the rest of us can move on.

With the introduction of themes, I have to go to something with a transparent background that’s a bit more generic and blends with a variety of colors. These are icons from the famfam “Silk” set. They look OK to me but I’m obviously a bad judge of these things according to others. I’m open to other suggestions for icons.

Here’s a tip to help with styling. Press Ctrl+D and the gadget will open a window with the current markup. This should help with figuring out layout and location of ids and styles.

Cool tip #2: You don’t need to restart the gadget to see your style changes. Save the file and just press Ctrl+Q twice. The gadget reloads the style sheet and will render your changes.

I’ve moved the new tweet indicator to the tweet itself. It’s the small bullet at the end the tweet. Move your mouse over the tweet to remove it. I think this works pretty well. Send me your comments.

Finally, I’ve fixed the memory leak in the new jQuery library (again). You should see better memory performance.

[tweetz 3.1.0.2](/download.aspx?filename=Downloads/tweetz31.gadget)
