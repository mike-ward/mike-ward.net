tweetz &ndash; Direct Messages Update
2011-07-05T22:04:29
Good news! I figured out how to get the Direct Messages working. Recall that due to a recent change in twitter’s API policy, direct messages stopped working a few days ago.

Better news. You don’t have to download anything new.

Not so good news (you knew there had to be a catch). You’ll have to reauthorize the gadget to get direct messages working. That simply means closing the gadget, opening a new instance and getting a new PIN.

What changed? Twitter issues API keys to client programs like [tweetz](/tweetz). Tweetz’s application key is associated with a set of permissions as to what the application key is allowed to access. I simply had to add the ability to retrieve direct messages to the application key’s configuration. 
