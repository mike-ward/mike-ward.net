tweetz Update #10
2009-11-01T22:55:32
Every time I think I’m coming to the end of a software project, someone rains on my parade with some “weird” bug. Turns out many of you like to run multiple instances of tweetz to monitor multiple accounts. Being a casual twitter user, it seems odd to want to have multiple twitter accounts, but hey, it’s a free country.

The “bug” is that updates sometimes show up in the wrong panel or even the wrong instance of the gadget. At first I thought this was just crazy talk, but then it happened to me with updates appearing out of order. WTF? How can this be?

The problem is that I had some silly notion that if I make an Ajax call, the response I get back is actually for the call I’ve made. Oh, how wrong I was on that assumption. There is no guarantee as to the order of the replies or that they will match the requests. In other words, the second Ajax call can get the first Ajax calls’ response.

Now I would have thought that the browser stack would do this “house keeping” for me. After all, it has to for image links and other resources. Apparently not.

One solution is to queue up the Ajax requests and call them serially. This is what I’ve done in this release. Ajax requests are added to a central queue and then “drained” in the order they were added. The next Ajax request in the queue is executed only after the previous Ajax request has completed.

As to updates showing up in other gadgets, I’m not sure how to proceed. The “Gadget” framework runs all gadgets in a single process which is the reason why updates sometimes “hop” gadget instances. Queuing the requests should “reduce” the opportunity for cross-talk but there are not guarantees. Suggestions on how I might mitigate this issue are definitely welcome.

The User page now includes your rate limits. Twitter only allows 150 API requests per hour. Tweetz stays well below that threshold but if you’re running other gadgets or hitting the web site, it’s possible to exceed this limit.

I’ve also fixed the home page link so it doesn’t trash the app when the users’ profile does not include a home page link.
