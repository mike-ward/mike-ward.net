Word Wrap in a Console App (C#)
2009-07-19T13:44:17
I needed a word wrapping function to format text to the console. Being the lazy coder that I am, I immediately ‘Google’ed for code. What I found worked but was a bit buggy and somewhat clumsy in its implementation. In fact, when I looked further, most of the [published code](http://geekswithblogs.net/cwilliams/archive/2005/01/21/20581.aspx) used the same approach.

  * Use a string split method to break the text up into a list of words 
  * Loop through the list of words and assemble a line until just before it overflows the margin 
  * Add the line to a list of lines and start a new line 
  * Continue assembling lines until the list of words is exhausted 

Simple enough and it mostly works. There are a few corner cases this doesn’t handle like breaking words that are longer than the wrap margin. The algorithm also removes any variable spacing in the text, which you may or may not want.

Text wrapping seems like a common enough need that is should be included in the standard string libraries. But after thinking about it, I realized that most text wrapping requirements are specific to the application they’re used in. Do you wrap on hyphens and syllables? How about preserving the original formatting like line breaks and word spacing? Alot depends on what you’re after.

Getting back to the problem at hand, I decided that breaking the text up into words and reassembling was not what I wanted. It’s not efficient in that it creates a lot of temporary objects and it doesn’t address the “Single word longer than a line” corner case. Here’s my solution:
    
    static List<string> Wrap(string text, int margin)
    {
        int start = 0, end;
        var lines = new List<string>();
        text = Regex.Replace(text, @"\s", " ").Trim();
    
        while ((end = start + margin) < text.Length)
        {
            while (text[end] != ' ' && end > start)
                end -= 1;
    
            if (end == start)
                end = start + margin;
    
            lines.Add(text.Substring(start, end - start));
            start = end + 1;
        }
    
        if (start < text.Length)
            lines.Add(text.Substring(start));
    
        return lines;
    }

In my particular situation, I wanted to take out line feeds, tabs, etc., which is what the “Regex” expression does. It also handles the “Single word longer than a line case” by breaking the word at the margin.

No word-wrapping algorithm is perfect and neither is this one, but I think you’ll find this one easy to modify to your needs.
