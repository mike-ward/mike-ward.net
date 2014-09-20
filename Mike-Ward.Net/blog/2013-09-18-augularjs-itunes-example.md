AugularJS iTunes Example
2013-09-18T19:32:45
I recently gave a presentation on AnguluarJS to a local user group. It was introductory in nature. Towards the end I presented a single file example that demonstrated a number of concepts I had touched on in the presentation including data-binding and AJAX requests.

You can save this to a local file and open it directly in the browser. _iTunes.html_ is a fun example in that it looks good and has a lot of behavior in a smattering of code.

[![image](/cdn/images/blog/WindowsLiveWriter/AugularJSiTunesExample_B84D/image_thumb.png)](/cdn/images/blog/WindowsLiveWriter/AugularJSiTunesExample_B84D/image_2.png)

It also does an Angular No-No in that it manipulates the DOM directly in the controller (line #117). As a rule, if you're using DOM manipulations in your controller there's likely an better way to express the behavior in an Angular [Directive](http://docs.angularjs.org/guide/directive). This was a compromise I made due to time limitations.

Here's the same example with the video player expressed as an Angular Directive.

[http://bl.ocks.org/mike-ward/6389991](http://bl.ocks.org/mike-ward/6389991)

On line #124 you'll see the definition for the "videoplayer" directive. It's used on line #83.

`<videoplayer src="{{url}}" width="320" height="240" autoplay controls>`

Angular's Directives allow you to define new HTML tags. It's a neat trick and allows for a declarative approach to DOM manipulations. 

Directives can be quite complex. Fortunately, the "videoplayer" directive is not complex, which makes for a good introduction.

From the code you can see that adding a Directive requires calling `app.directive()`. The first parameter is the name of the Directive and the second takes a function that returns an object.

The object has several fields.

> `restrict: 'E'` – This restricts the directive to being used only as an element. Directives can also be expressed as attributes (like <html ng-app="app">) , classes and comments (comments are document nodes to). 
> 
> `replace: true` – Instructs the directive to replace the current DOM element with the template rather than appending to it.
> 
> `template:` – The HTML that will be substituted for the current DOM. Templates can have data-binding expressions and even use other directives. For this example, a static template suffices.
> 
> `link:` – The link function is where behaviors and DOM manipulations usually occur.

Directives have scope as indicated by the link function's parameter "scope". Directives can inherit the parent scope (the default), introduce a new scope or even contain an isolated scope. Scope is not used in this example.

The "attrs" parameter contains the attributes declared on the element. In Directives, you can, "observe" changes to attributes. `attrs.$observe()` watches for (observes) changes to the "src" attribute in order to start and stop the video player. Remember that the "src" attribute is bound to "{{url}}" (line #83), so that changes to $scope.url (line #114) change the video player's "src" attribute.

**Strict Contextual Escaping**

After hooking all this up I found the video player no longer worked. Fortunately, Angular had a descriptive error message in the browser's JavaScript console indicating the problem.

Error: [$sce:insecurl] Blocked loading resource from url not allowed by $sceDelegate policy.

What???

For security reasons, Angular doesn't just let you jam a URL into a data-binding. The [Strict Contextual Escaping](http://docs.angularjs.org/api/ng.$sce#getTrustedResourceUrl) ($sce) service requires bindings in certain contexts to result in a value that is marked as safe in that particular context (told you Directives are meaty).

For this example the work-around is straightforward (line #114).

> `$scope.url = $sce.trustAsResourceUrl(item.previewUrl);`

Wrapping the `item.previewUrl` from iTunes in a `$sce.trustAsResourceUrl()` call tells Angular that `item.previewUrl` is a trusted value.

The Directive version of this example is more complex than the previous example but lends itself to easier reuse and testing. And even if you didn't understand Angular, I don't think it would be too hard to imagine what the `<videoplayer>` tag does. The self-describing nature of the markup lends itself to easier interpretation.
