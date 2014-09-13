Tweetz 3 - Release Candidate 3
2010-09-07T23:49:12
Some really good stuff in what I hope to be last release candidate.

  * **Improved autolinking**: Twitter’s engineering folks posted a set of descriptive tests on how they parse and autolink tweets. I’ve rewritten Tweetz’s code to pass all these tests plus some additional edge cases I’ve found. Of course, if you do find a tweet that doesn’t parse like the twitter page, send me the tweet id and I’ll add it to the suite of tests (and fix the code of course).
  * **New tweet indicators**: When new tweets arrive the tab of timeline that received the tweet is highlighted by adding an orange highlight to the lower-right corner. To mark the timeline as read, just move the mouse cursor over the tab. The “Unified” timeline does not highlight since it’s just a collection of the other timelines.
  * **Fixed high CPU usage**: The gadget spiked the CPU pretty hard when checking for new tweets. Wanna know what it was? The pulsing indicator in the top right corner. Turns out, JavaScript animations are very CPU intense. I’ve removed the pulsing indicator and replaced it with a steady yellow indicator. Not quite as cool but it should make for better battery life.
  * **New retweet/message icons**: I’m using the same icons that appear in the “actions panel”. They fit better with the overall theme and save a few more pixels for text.
  * **Purge old tweets**: I’ve moved the purge tweets to a timer that fires every 2 hours. Originally, I did on updates but figure every two hours should lower CPU usage even more.
  * **Fixed refreshing timelines**: Well, much to my chagrin, I discovered that while I implemented refresh for the “Unified” timeline, I didn’t do it for the Home, Mentions and Messages timelines. And even the “Unified” refresh had a bug! Anyways, clicking the active tab will the Unified, Home, Mentions and Messages will immediately check twitter for new updates (Unified, Home, Mentions and Messages only).

OK, you know the mission, find those bugs and keep the suggestions coming.

Available on the [downloads page](/downloads).
