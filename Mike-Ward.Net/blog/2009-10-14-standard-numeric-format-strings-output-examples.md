Standard Numeric Format Strings Output Examples
2009-10-14T13:36:11
I can never seem to remember the format strings for numbers in .NET. There are several cheat sheets available but the one that works best for me is the examples page in the Microsoft documentation.

Format Culture Data type Value Output

C
en-US
**Double**
12345.6789
$12,345.68

C
de-DE
**Double**
12345.678
12.345,68 DM

D
en-US
**Int32**
12345
12345

D8
en-US
**Int32**
12345
00012345

E
en-US
**Double**
12345.6789
1.234568E+004

E10
en-US
**Double**
12345.6789
1.2345678900E+004

E
fr-FR
**Double**
12345.6789
1,234568E+004

e4
en-US
**Double**
12345.6789
1.2346e+004

F
en-US
**Double**
12345.6789
12345.68

F
es-ES
**Double**
12345.6789
12345,68

F0
en-US
**Double**
12345.6789
123456

F6
en-US
**Double**
12345.6789
12345.678900

G
en-US
**Double**
12345.6789
12345.6789

G7
en-US
**Double**
12345.6789
12345.68

G
en-US
**Double**
0.0000023
2.3E-6

G
en-US
**Double**
0.0023
0.0023

G2
en-US
**Double**
1234
1.2E3

G
en-US
**Double**
Math.PI
3.14159265358979

N
en-US
**Double**
12345.6789
12,345.68

N
sv-SE
**Double**
12345.6789
12 345,68

N4
en-US
**Double**
123456789
123,456,789.0000

P
en-US
**Double**
.126
12.60 %

r
en-US
**Double**
Math.PI
3.141592653589793

x
en-US
**Int32**
0x2c45e
2c45e

X
en-US
**Int32**
0x2c45e
2C45E

X8
en-US
**Int32**
0x2c45e
0002C45E

x
en-US
**Int32**
123456789
75bcd15

This gets me about 90% of my numeric formatting needs and there are links to custom format strings for when the standard ones won’t suffice. Bookmark the MSDN page [here](http://msdn.microsoft.com/en-us/library/241ad66z%28VS.71%29.aspx).
