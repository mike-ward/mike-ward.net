tweetz Update #8
2009-10-11T23:56:20
This update has a bunch of little usability updates.

Added small and large backgrounds. The corners of the backgrounds distort if they’re stretched too much. To compensate, I’ve added larger backgrounds. The larger backgrounds are used when the docked size exceeds 599 pixels or the expanded size exceeds 749 pixels.

Tabs are highlighted when new tweets arrive. The tab gets a subtle blue highlight color.

Turned off chirps for the initial updates and refreshes.

More responsive scrolling. I really like that scrolling with the mouse wheel in tweetz scrolls to the next tweet and not some fixed length that cuts off the tops of updates. The calculation to do this is rather costly however and results in a few tenths of a second pause when scrolling. It’s very noticeable at times and gets worse as the number of tweets increases. It’s surprising how slow this calculation is which really illustrates how slow JavaScript and DOM manipulations can be at times. The code now computes the scroll increments on status updates and tab switching instead of waiting for a scroll wheel event.

So what’s left to do? Currently, I have “trends” on search page on my to-do list. The rest depends on what I see in the way of feature requests.
