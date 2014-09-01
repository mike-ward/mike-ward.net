Recommendations to Improve Software Builds
2008-01-30T02:35:28
I recently took over management of our build process for our development team mostly because no one else wanted to touch it. Once I started looking at the build scripts and the issues surrounding them I understood why no one volunteered. It was simply a mess. Sadly, this is not an uncommon occurrence if my experience of the last 20 years is any indication.

To be clear, I’m a developer and so my concerns and suggestions here are slanted towards making it easier for developers to write and build software. I’m not concerned with the formality of the build process or that it follows some industry guideline. As a developer I want it fast, I want it repeatable and I want it to tell me what I did wrong.

Over the course of 3 months I converted our clunky build system into something that both developers and management admire. We easily hit our build delivery targets, the software works better and morale is improved. Here’s what I did.

**1. Make it fast**

More than anything else, you have to make your build fast. Nothing else matters if you do not accomplish this step. It affects every aspect of a developer’s time and as such as the greatest impact. Minutes matter.

When I first started our builds were taking approximately 20 minutes for a single configuration. Some of you probably think that’s pretty good. Of course much of this depends on the size of the project you’re working on. In this case, we’re talking about 200,000 lines of code. Not particularly big but not small either.

While 20 minutes seems reasonable its 20 minutes that your developer is essentially idle. Multiple that by 5 or 10 times a day and you start see some significant gaps in productivity.

How much more work can your developers get done if their build only took 3 minutes? I would wager quite a bit more. And that’s just what we did. With a lot of work and some careful analysis, the build times were reduced to 3 minutes for a single configuration. There’s a term I have for this kind of change. I call it “Lowering the friction”.

A friction free build is a fast build that makes little demands on the developer and gives consistent results. Every situation is unique but I think some of the changes I made will apply to many situations.

Use a domain specific tool. In our case we were using a perl script to conduct our builds. I suspect this is quite common. While perl is a great general purpose tool, it simply sucks for doing builds. There are better tools like ANT and Visual Build which are designed specifically to do builds. Use them. In our case, I chose MSBUILD since we’re building .NET applications.

Fix and maintain build dependencies. Said another way, never build anything twice. Seems obvious but it’s surprising how often steps are repeated in a complicated build. Admittedly, this is a tedious process. You have to go through your build logs and look for duplicates. Grep can be of great help here but manually plowing through the logs often leads to better results.

Eliminate dead code. Again, seems obvious but it is simply amazing how much unused code creeps into a build over time. Developers are horrible at cleaning up after themselves so you are going to have to do it for them.

Reduce the number of projects. This is perhaps a bit more Microsoft specific but fewer projects make for faster builds. Encourage your developers to use project folders rather than projects to separate their code.

Build only what is necessary. Builds often create extra modules like documentation and installers. Separating these items into different build targets allows developers to focus on the specific region area of concern.

Version all your tools. Keep all your build tools versioned and use those tools in your builds. When I first started on this project, there was a 5 page instruction guide on how to setup a developer box to do builds. Nonsense I say! Now when a new developer comes on board, I give them two commands. One to extract the view from version control and one to do the build. Technically speaking, you do have to install the version control system on your box (ClearCase in this case) to get a “View” so it’s three steps. Still, it’s a huge improvement over the old way.

Document everything. Being transparent and making it obvious is more important than you might think. Builds should not be the special domain of one person. Treat it has community property. I have one master build script that allows me to complete any and all build tasks. The file contains documentation for all targets and any side-affects they may contain. When someone asks me how to build such and such, I point them to the build script. If they still don’t get it, I modify the documentation to clear up any ambiguities. If they still don’t get it after that, I fire them (just kidding).

Measure your performance and monitor it regularly. Once you have a fast build keep it fast by monitoring it regularly. Don’t let it slip. You worked hard to get it fast and you’ll have to work to maintain it.

**2. Feedback is paramount**

Nothing is more irritating (to me) than to start my day with a bunch of messages from the build manager telling me that such and such is broken. Not only does everyone have to stop and figure out if they were the cause, but no one can update their build views until the problem is resolved.

Now that you have a fast build, it’s time to exercise it. “Continuous Integration” refers to a process where software under development is built as often as possible. In our development environment, the moment developer checks his code into version control, a build is started and the results of that build are made known to that developer in under 10 minutes.

Previously, a developer would check in code and have to wait up to 24 hours know if his changes successfully built. I can’t count the number of times a build broke because someone checked their source and forgot about the header file. Worse still, the developer has left for vacation and won’t be available for 2 weeks. Ouch!

There are now tools available that can monitor for changes and conduct builds automatically. The results are then emailed or made available via a local web site. These tools are commonly referred to as “Continuous Integration Servers”. There are a number of CI Servers on the market for various platforms. We went with CruiseControl.NET which is an open source project developed by ThoughtWorks. Other products may be better suited for your needs.

Setting up a CI Server is not complicated in most cases provided you have a fast build (remember step 1?). In the case of CruiseControl.NET, you run an installation program, configure a few XML files and send out an email letting your developers know where CI Dashboard can be found.

The CI Dashboard is a summary view of all the projects being managed by the CI Server. It’s a snapshot of the health of all your builds with links detailed status reports of those builds. Here's a [live example](http://ccnetlive.thoughtworks.com/ccnet/ViewFarmReport.aspx).

Furthermore, should the build break, a list of files updated or added and who added them for the build is available. We jokingly call this the “Blame List” where I work but you can see how valuable this kind of feedback might be.

CI Servers can send emails to those who individuals who modified code for the particular broken. However, if you’re like most developers l know, you’ll ignore these automated messages. Instead, we chose to use a desktop notification program that came with CruiseControl.Net called CCTray. It sits in the tray and is colored green when all builds are good and red when one or more fails.

The tray icon has been a great tool and the developers seem to enjoy it. Whenever the icon goes red there is friendly banter back and forth about who broke what and when it might get fixed. Morale has improved considerably.

Even more interesting is that the term “broken build” is largely absent from our vocabulary now. Sure the builds get broken, but they also get fixed, often within minutes. Management no longer has to worry if the nightly builds will work and don’t have to berate developers about "bad" check-ins.

After a time however, the game became less interesting because keeping the build green was easy. And here in is where feedback becomes a motivator for better code. I simply raised the “bar” on what constituted a “green” build. At first it was just successful compiles. Then I added “smoke” tests that did some rudimentary testing of the software. As the team got better at these tasks, I added unit tests. Then GUI tests. Then integration tests and so on.

Many more tests have to be passed now to constitute a “green” status and yet the team handles it quite well. You can see and feel the difference in both the product and the people.

Just to make the game a bit more interesting I placed an LED sign above my cube that indicates the build status by polling the CI servers every 10 seconds. Thanks to Jeff Attwood’s excellent and library for BetaBrite signs and the open source from CruiseControl.NET I was able to hack together a program to reflect the build status and display it on the sign for all to see. Now development, management and testing see the build status at a glance. It’s a point of pride that we don’t let the sign go red.

But wait there’s more. When the build is green, the next logical step is to display – BUGS! Our bugs are kept in a database so it was a simple matter to query the bug database and display the number and severity of bugs currently logged against the product. Now the goal is green and zero!

In addition to the CI feedback I started adding reports, readily accessible from the CI Dashboard. These reports show code coverage for unit tests, coverage by feature and results from static code analysis. I spent a fair amount of time making these reports easy to understand and interpret. Columns of numbers simply don’t cut it. Colors and good presentation really count for something. Some of these enhancements had more entertainment value then real use but if it got people to read the reports and internalize the data then so be it. At some point I’ll likely raise the bar again and require some minimum percentage of coverage to get to green.

The point of all this is simple. Continuous, easy to understand feedback can greatly improve the build state of your code. I think the system works because it’s anonymous, automatic and frequent. Also, by gradually working it into the workflow, it was not perceived as a determent to productivity by the development staff.

**3. Talk to your developers**

Again, this is not rocket science but then again no one was doing it. Shortly after I started managing the builds I went around and surveyed the development staff. I asked them what would make the jobs easier (as related to builds of course). If you have ever worked with a talented development group you’ll understand when I say I got an ear full.

Having my "Todo" list in hand I proceeded to make changes. Since I was also involved with the development of this project earlier, I was familiar with most of the issues. Of course, the biggest complaint was that the build was slow and buggy. Early on, it was not difficult to improve things given the dismal state of affairs.

After round one, I went back and asked the same question again. This wasn’t a formal thing. I simply walked around and asked how it was going and what I could do to make things better. Constantly seeking feedback and suggestions is a good "measurement" of how you're doing.

**4. Take the hit**

Early on I realized that the build management I was doing was really more of a service than an individual task. Seeing my role in this light allowed me to ask a simple question. How can I improve my service. And the question is not just limited to development. I asked management, testing what that would like to see in my “deliverable”. Often times it involved clerical type tasks like tallying bugs or collecting release notes.

It’s tempting to delegate these tasks but I chose not to. Instead, "I took the hit." If it made development’s task easier at my expense I shouldered the burden. Often I could write code to automate the task but not always. Mostly I wanted my developers to keep on task and not worry about the little things.

This actually earned me quite a bit of "political capital" with these groups. My suggestions were given better hearings and when I had to ask for additional effort in some areas there was willingness to help I had not seen before.

**Conclusion**

I had more fun doing build management than I ever expected. And the reason was because I could positively impact so many people in my company. You could easily see how much happier development and management were. It was a great feeling.

Recently, I had to pass the build management torch to another developer on the team. Surprisingly, when I asked for volunteers I immediately had two developers sign up. Builds went from pariah to a valuable part of the software development process. You can feel the pride in the group when they turn over a well built, well tested product to our testers.

As the guy (or gal) responsible for the build, I encourage you to get close to your team, listen well, and work hard to make it better. Builds (and deployments but I’ll save that for another day) are a vital part of the software development process and deserve all the attention you can afford them.
