Keep Firefox’s location bar on sight
2007-04-21T00:55:13
> Some pop-up windows may hide the location bar for a number of valid good reasons like providing a less cluttered interface or a smaller window, but it is also an easy cover for malicious web sites to hide the real location of fake sites in cross site scripting (XSS) attacks. 
> 
> Michal Zalewski, the hacker who uncovered a handful of security vulnerabilities in Firefox on last February, pointed it as one of Firefox’s weaknesses. Fortunately, as suggested in the bug discussion, this behavior can be changed to forbid the ability to hide the location bar to all web sites. 
> 
> To do this: 
> 
>   * Enter _about:config_ in the location bar 
>   * Look for **dom.disable_window_open_feature.location**
>   * Double click it to toggle it to _true_
> 
> You are done. Now popups will show the location bar always. It may look weird at first but it’s a small price to pay for additional protection. [Mozilla Links](http://mozillalinks.org/wp/2007/03/keep-firefoxs-location-bar-on-sight/)
