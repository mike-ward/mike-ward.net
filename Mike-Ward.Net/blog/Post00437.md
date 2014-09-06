Vista Weather Gadget – More Updates
2009-02-26T02:25:52
In keeping with updating early and often, here’s the latest release of my weather gadget for Windows Vista. Some more layout fixes and a few bug fixes. Here’s another look.

[![image](/content/images/blog/VistaWeatherGadgetMoreUpdates_12CEE/image_thumb.png)](/content/images/blog/VistaWeatherGadgetMoreUpdates_12CEE/image.png)

Gadgets are essentially little HTML pages but you can’t rely too much on Web standards being adhered to. For instance, I thought by adding a style to the table cells to hide overflows, I would avoid cells wrapping. Nope, doesn’t work. I found the only way to prevent this was to use a fixed table layout and specify the cell widths and heights. Bummer but that’s how it is. Heck, you can’t even put a DOCTYPE header in the file without breaking the gadget. It’s this weird, not quite adhering to standards that makes gadget development peculiar.

There was also a few bug fixes. The format was not remembered after reboots/logoffs and the color settings sometimes got munged. I haven’t received much in the way of feedback. Not sure what to make of it. 
