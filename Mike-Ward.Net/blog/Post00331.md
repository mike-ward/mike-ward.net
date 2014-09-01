A Persuasive Argument for Garbage Collection
2008-07-30T20:23:11
Despite what I perceive as greater program reliability and speed, I find many of the programmers I work with deriding the garbage collector in .Net and wishing for the good old days of explicit memory management. I personally have never looked back. I've never done a very good job of defending this position, in part because it's hard to quantify.

Recently, I was checking out the "D" programming language. In a section on [garbage collection](http://www.digitalmars.com/d/2.0/garbage.html), I found a compelling argument for the use of garbage collectors.

> C and C++ programmers accustomed to explicitly managing memory allocation and deallocation will likely be skeptical of the benefits and efficacy of garbage collection. Experience both with new projects written with garbage collection in mind, and converting existing projects to garbage collection shows that: 
> 
>   * Garbage collected programs are faster. This is counterintuitive, but the reasons are: 
>     * Reference counting is a common solution to solve explicit memory allocation problems. The code to implement the increment and decrement operations whenever assignments are made is one source of slowdown. Hiding it behind smart pointer classes doesn't help the speed. (Reference counting methods are not a general solution anyway, as circular references never get deleted.) 
>     * Destructors are used to deallocate resources acquired by an object. For most classes, this resource is allocated memory. With garbage collection, most destructors then become empty and can be discarded entirely. 
>     * All those destructors freeing memory can become significant when objects are allocated on the stack. For each one, some mechanism must be established so that if an exception happens, the destructors all get called in each frame to release any memory they hold. If the destructors become irrelevant, then there's no need to set up special stack frames to handle exceptions, and the code runs faster. 
>     * All the code necessary to manage memory can add up to quite a bit. The larger a program is, the less in the cache it is, the more paging it does, and the slower it runs. 
>     * Garbage collection kicks in only when memory gets tight. When memory is not tight, the program runs at full speed and does not spend any time freeing memory. 
>     * Modern garbage collectors are far more advanced now than the older, slower ones. Generational, copying collectors eliminate much of the inefficiency of early mark and sweep algorithms. 
>     * Modern garbage collectors do heap compaction. Heap compaction tends to reduce the number of pages actively referenced by a program, which means that memory accesses are more likely to be cache hits and less swapping. 
>     * Garbage collected programs do not suffer from gradual deterioration due to an accumulation of memory leaks. 
>   * Garbage collectors reclaim unused memory, therefore they do not suffer from "memory leaks" which can cause long running applications to gradually consume more and more memory until they bring down the system. GC programs have longer term stability. 
>   * Garbage collected programs have fewer hard-to-find pointer bugs. This is because there are no dangling references to freed memory. There is no code to explicitly manage memory, hence no bugs in such code. 
>   * Garbage collected programs are faster to develop and debug, because there's no need for developing, debugging, testing, or maintaining the explicit deallocation code. 
>   * Garbage collected programs can be significantly smaller, because there is no code to manage deallocation, and there is no need for exception handlers to deallocate memory. 
> 
> Garbage collection is not a panacea. There are some downsides: 
> 
>   * It is not predictable when a collection gets run, so the program can arbitrarily pause. 
>   * The time it takes for a collection to run is not bounded. While in practice it is very quick, this cannot be guaranteed. 
>   * All threads other than the collector thread must be halted while the collection is in progress. 
>   * Garbage collectors can keep around some memory that an explicit deallocator would not. In practice, this is not much of an issue since explicit deallocators usually have memory leaks causing them to eventually use far more memory, and because explicit deallocators do not normally return deallocated memory to the operating system anyway, instead just returning it to its own internal pool. 
>   * Garbage collection should be implemented as a basic operating system kernel service. But since they are not, garbage collecting programs must carry around with them the garbage collection implementation. While this can be a shared DLL, it is still there. 

I don't agree with everything here. For instance, you can leak resources in garbage collected programs which can lead to gradual deterioration. It just happens less frequently in my experience.

I've always liked Walter Bright's work (the author of the D Language). I was particularly fond of his [Datalight C compiler](http://www.itee.uq.edu.au/~csmweb/decompilation/hist-c-pc.html). Ah, the good old days...
