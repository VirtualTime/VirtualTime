```
Install-Package VirtualTime

That allows you to, for example, make time that moves 5 times faster

var DateTime = DateTime.Now.ToVirtualTime(5);

To make time move slower , eg 5 times slower do

var DateTime = DateTime.Now.ToVirtualTime(0.5);

To make time stand still do

var DateTime = DateTime.Now.ToVirtualTime(0);
