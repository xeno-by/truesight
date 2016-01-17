While being essential for effective development, metaprogramming tasks in .NET are usually associated with lots of pain. In my humble opinion, the major reason for that is that stock APIs provided for these purposes (System.Reflection, System.Reflection.Emit) are very low-level and rather complicated. Not the least reason is also the age of APIs - they were designed somewhere around 10 years ago, so neither they incorporate essential notions in modern programming (fluency, functional flavor), nor they leverage new capabilities of modern languages (generics, closures, lambdas).

It's a shame that powerful capabilities provided by CLR are shadowed by the inconvenient tools we've got. So in attempt to provide **a better way to access dynamic capabilities of .NET platform** I decided to put up the Truesight project. This project's mission is to deliver a holistic, consistent, simple and fluent API to programmatically examine and create programs for .NET platform.

**Truesight is now in the early design phase**, and so far you can only check the [planned features](http://code.google.com/p/truesight/wiki/PlannedFeatures), take [a sneak peek](http://code.google.com/p/truesight/wiki/SneakPeek), and stay tuned for [updates](http://code.google.com/p/truesight/updates/list). If you crave for more details you can try downloading [my scratchpad](http://code.google.com/p/truesight/source/browse/#hg/Scratchpad/Truesight) - though it's written in Russian and is stored in an uncommon format.

(upd). The overall idea behind Truesight is too grande and too abstract to be implemented in my free time, so the project has been moving slowly since its inception. That thingie surely needed a practical driver project that would become a test bench for its API and functionality. And that project had emerged in the form of my [postgraduate research](http://bitbucket.org/conflux/conflux) in the field of GPGPU. For the needs of my project I've implemented **[CIL bytecode decompiler](http://code.google.com/p/truesight-lite/)** that got spun off into a separate repository.