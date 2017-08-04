# FFXIVHealthBar

I used an arduino with a LED strip connected to my computer via usb to give me a physical health bar. The arduino is a mega 2560 (I was using an uno until I accidentally burned it up. The led strip is an old TM1803 that I got from Radio Shack years ago. Basically a the program runs and pulls your health from the game and sends it via Serial over usb to the Arduino which then controls the lights.

This was my first C# program and I did it to learn the language, so the code is full of bad practices, bandaids, hardcoded variables, and workarounds. But hey, it works.

The SerialPlayground contains the Arduino sketch and FFXIVHP is the C# files.