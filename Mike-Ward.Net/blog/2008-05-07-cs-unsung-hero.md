C#'s Unsung Hero
2008-05-07T13:56:04
I was updating some legacy Windows C++ code last night and the pain of using it hit me like a ton of bricks. In particular, the string handling was a nightmare. Here are all the ways I found strings used in this program:

  * CString
  * Bse_String (private class)
  * OLESTR
  * LPCTSTR
  * LPSTR
  * wchar_t (include const and pointer variants)
  * TCHAR (include const and pointer variants)
  * char (include const and pointer variants)
  * STL string
  * BSTR
  * _bstr_t
  * CSimpleStringT

What a mess. And worse still, this only address the width of the characters, not the encoding. Now admittedly, some of macro types overlap but still if you haven't used this stuff in a while, it is hard to remember what maps to what.

And then there are all the _t variants for the library methods. For instance, _tstrcpy replaces strcpy. Finally, there are macros to help with conversions like W2A, T2W, CA2T, etc.

C# String handling is light and breezy by comparison. There's one class and it pretty much deals with everything concerning string handling. Encodings are equally easy and the support for common encodings like UTF-8 are supported. Ever try to do UTF-8 in C++?

And what about localizations? I never did get the hang of the C++ locale and facet classes. In C# (well .Net really) it's built-in.

So here's to C#'s unsung hero, the humble and unifying String class.
