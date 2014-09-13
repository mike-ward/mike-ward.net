The Day the Trackbacks Died
2006-12-22T14:39:01
Jeff Atwood over at Coding Horror thinks trackbacks are dead. From the [article](http://www.codinghorror.com/blog/archives/000751.html).

> They're a great idea. **Unfortunately, trackbacks are so horribly and fundamentally broken that they're effectively useless.**

I would tend to agree. There really is no way to keep spammers out with this mechanism and as such it has been horribly abused. Atom looks better in at least it can use basic HTTP authentication but it then requires giving the linker permission. MetaWeblog, which I've complained plenty about lately sends passwords in the clear. How long before people start abusing that? The comments on Jeff's blog have several suggestions that might slow down the flood a little and there's a decent followup [article](http://rabidpaladin.com/archive/2006/12/21/Trackbacks-Are-Dead.aspx) here as well. It's forcing me to think about adding better pingback moderation to [Bloget](/bloget). Bloget does an Ok job right now in that it verifies that the trackback contains a link to the referenced article. And it has to occur in the first 10K of the post because that's all Bloget will read before terminating the connection. Bloget don't waste bandwidth or CPU trying to scan 3 MB articles. And I thought writing this blog engine thing was going to be easy.
