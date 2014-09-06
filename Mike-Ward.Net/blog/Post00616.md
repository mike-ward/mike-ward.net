Tweetz 3.0 – Release Candidate
2010-08-23T23:54:22
Hey, it’s almost done. All that’s left to do is to write a new Web page and documentation. That will take an evening or two. In the mean time, here are the release bits barring some major bug. I’m anxious to get started on 3.1 so it’s time to stick a fork in it.

What’s new:

  * Direct messages sent were displaying the author instead of the recipient
  * Hover indicator on tabs
  * Parse hashtags, @names and urls more like twitter
  * Purge old tweets

Parsing hashtags, @names and urls like twitter was way more work than I expected. It’s not at all obvious what the rules are for parsing these items. Fortunately, twitter recently published their text parsing code. It’s in Ruby which I only have a passing knowledge of. Translating to JavaScript was a chore I’m glad to have behind me. There’s also a test description in YAML. One of these days I’ll have to code up some tests to verify the code.

I’ve capped each timeline at 250 tweets (the unified timeline is the sum of all timelines). [Tweetz](/tweetz) 2.3.5 did something similar.

Available on the [downloads page](/downloads). 
