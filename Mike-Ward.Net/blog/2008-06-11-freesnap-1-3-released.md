FreeSnap 1.3 Released
2008-06-11T14:06:36
This release of FreeSnap can be summarized in two words - Multi-monitor Support! (do hyphennated words count as one?)

It's been almost 4 years since I've modified FreeSnap. That's like an eternity in Internet time. FreeSnap has held up well over the years and has required very little support. For instance, I had to make no modifications for it to work on Vista. But as well as it works, there has always been an issue with multiple monitor systems. At the time I originally wrote FreeSnap way back in 2001, I didn't know Windows had API's for multiple monitor support nor did I have multiple monitors. With the addition of a second monitor at home, I've modified FreeSnap to correctly work (I hope) with 2, 3 and even 4 screen systems.

FreeSnap uses the MonitorFromWindow() Windows API to determine which monitor edge to snap to. This API calculates which monitor has the largest cross section of the given window. That monitor's edges are then used for positioning purposes. There is an alternative approach to positioning that could be applied if enough people find it useful. Instead of MonitorFromWindow(), I could use MonitorFromPoint(). With other minor changes, Windows could then be snapped across monitors as well as within monitors. My feeling is that the current implementation is more useful but I could be convinced otherwise.

To further take advantage of this new capability, I've modified the "Center Window" action (Win+Keypad5) to move the active window to the next screen when multiple monitors are detected. The centering functionality remains the same in single monitor configurations.

I'm also releasing the source code under GPL. It's interesting to look back on how I wrote code back then. For instance, I was fond of using underscores in variable names back then. Now-a-days I use camel and Pascal casing which is more in line with current industry practices.

C++ also turned out to be a good choice for this program. FreeSnap relatively simple and doesn't require any of the advanced features implemented in .NET programs. As a result, it uses very little memory. Here's a screen shot from my Windows XP box.

[![freesnap](/cdn/images/blog/FreeSnap1.3Released_995D/freesnap_thumb.png)](/cdn/images/blog/FreeSnap1.3Released_995D/freesnap.png)

I don't have a system with 3 or 4 screens so I can't test if my algorithm for finding the next screen actually works on 3 and 4 screen systems. If you're fortunate to own such a system, I would appreciate confirmation that it works in such an environment. Also, my screens are the same size. I've tried to account for this in the code but without that particular environment, I can't test it. FreeSnap is available on the downloads page.
