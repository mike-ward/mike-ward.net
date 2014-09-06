tweetz Beta – OAuth
2010-01-10T23:14:54
twitter.com has made it known that they plan to phase out the user name/password authentication API in favor of OAuth in the near future. [OAuth](http://oauth.net) allows applications, like tweetz, to access your twitter account without having to give the application your user name and password.

This change if fairly disruptive, especially in the area of logging in. I’ve followed the guidelines and have made the process work in a manner similar to other twitter clients like Seesmic. Since this a big change, I’m releasing this as a beta to solicit feedback and shake out bugs.

In previous versions, you logged in using the “Settings” dialog where you entered your user name and password. In this beta version, the program starts with a screen that instructs you to get a PIN number.

![getpin](/content/images/blog/tweetzBetaOAuth_F6EF/getpin.png)

Click the “Get Pin” button. Tweetz will open your browser and navigate to twitter’s “Application Approval” page. The instructions are simple. You may have to login.

![approve](/content/images/blog/tweetzBetaOAuth_F6EF/approve.png)

Logging in and clicking “Allow” navigates to a second page with the PIN number.

![allow](/content/images/blog/tweetzBetaOAuth_F6EF/allow.png)

Copy and paste this number into tweetz.

![gotpin](/content/images/blog/tweetzBetaOAuth_F6EF/gotpin.png)

and click “Login”.

If all has gone well, you should see your tweets! Another advantage of using OAuth is the “by line” in twitter displays as “from tweetz” instead of “from Api”.

Available on the [downloads page](/downloads).
