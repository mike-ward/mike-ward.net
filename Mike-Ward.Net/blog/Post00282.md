Software Architecture - why does it sometimes fall short?
2008-04-28T15:17:32
I'm asking the question because more and more my responsibilities are shifting into the area of architecture. As a developer, I've always eyed architects with a bit of suspicion. After all, they don't program so how much do they really know? And do they really have to live the consequences of their designs the way developers do? I sometimes wonder. Still, there is a need for an over-arching view of the subsystems and how they work. I guess what bugs me about architecture is that it's often done up front and then left to rot as the project develops.

And why is this? I think it comes down to enforcement. Unlike code where you can apply static analysis, write unit tests and do code reviews to verify results, architecture tends be a bit more slippery. How often do you hear in a code review that such and such an implementation violates the architecture? In my experience, not often.

A colleague of mine wrote an interesting paper about this and brilliantly summed up the problem (at least for me) in two sentences.

> What this means in practical terms is that architecture specifications must be enforced by peer reviews or other means external to the programming language and development environment itself. Being non-local means they can be easily broken, and if they are indeed valued by the organization as a whole, adherence to an architecture document needs to be enforced externally.

He's spot on when he says being "non-local means they can be easily broken." Developers can easily do end-runs around architectures both intentionally and non-intentionally. It's an important matter for the architecture team to remain ever vigilant in monitoring the development of the software.

And the best way to do that in my opinion is that architects need to do implementation. That's right, hands on coding. It doesn't have to be a big part of the project but it's important that they "put hands" on the system and live with their decisions. Day to day interaction with the code and the team is important from so many perspectives. Beware the non-coding architect!
