Pure CSS Framework as an Alternative to Bootstrap
2013-09-08T14:05:21
Given the popularity of [Bootstrap](http://getbootstrap.com/) you could be forgiven not knowing about other capable CSS frameworks.

[Pure](http://purecss.io/) is a CSS framework from Yahoo. It’s small at 4.3 KB (minified and gzipped). Being small doesn’t mean it’s not capable. You still get responsive styles, design and ease of use. It also meets my very important criteria of being, “More funner".

So why use Pure instead of Bootstrap?

  * It’s not Bootstrap. Bootstrap’s a bit of a victim of its own success here. It’s used so much that there are sites like [Bootswatch](http://bootswatch.com/) that provide themes in order to, “Save the Web from Default Bootstrap”. Kind of funny. Kind of true.
  * I find it easier to understand and use. In my experience, I tend to need less annotations in my HTML to achieve pleasing results (that’s the, “More funner” part).
  * It’s designed to be extended. The minimal styles encourage you to write your own application styles on top of it.

Pure builds on [normalize.css](http://necolas.github.io/normalize.css/). 

> Normalize.css makes browsers render all elements more consistently and in line with modern standards. It precisely targets only the styles that need normalizing. 

Pure then provides layout and styling for native HTML elements plus some common UI elements. It’s what you need, without the cruft (their words, not mine, but I tend to agree).

Like Bootstrap and other CSS frameworks, there’s a grid system. Unlike some frameworks there is no fixed number of columns. Instead, Pure uses a “fractional” system for layout. Want a column that is 1/5 (one fifth) of the page. Use : **<div class=”pure-u-1-5”>**. One third is expressed as **“.pure-1-3”**. You can use different column specifications on the same row.

Grid columns have no padding or margins. Padding and margins can be added by nesting elements or extending styles. Minimal? Indeed, but it also means you don’t have “reset” the framework’s padding/margins if they don’t suit you. There’s also a responsive grid that does column collapsing. It uses the same “fractional” system with a different wrapper.

Forms are simple, minimal and deliberate. You can layout forms horizontally or vertically. Check boxes, radio buttons and inputs have a modern style. It’s just enough for most cases.

Buttons. Nothing fancy here. Flat and factual is how I describe them. Want more? You can style them easily. Again, it’s enough for most things and easily extended as needed.

Tables. You get the usual bordered, unbordered and stripped layouts. 

Menus are also straightforward. Like the rest of the framework, menus are decidedly flat and rely on whitespace and typography to communicate their intent. There are horizontal and vertical menus, with or without headings. There’s also a dropdown menu, which is a bit surprising given the minimalism of the framework.

I could write a longer article on Pure but I’m already risking exceeding the length of the documentation (kidding). I find Pure refreshing. It’s easy, requires minimal markup annotations and gives you a modern looking layout with minimal effort.
