# FastPrimes2
![image](https://user-images.githubusercontent.com/31595608/147173638-97da4a61-78a9-40f1-a840-a0c6b4a41dd8.png)
(This image was taken on a system that had a Ryzen 9 5900x 12 core 24 thread processor)

This is a cool program I used to learn a little bit about threading, the parallel foreach function in C#, and C# in general

I have written prime numbers calculators in the past but this time I wanted to take full advantage of a multithreaded processor when calculating an Nth prime and it works well

To use this program, you give it the commandline arguments for the Nth prime you want to calculate followed by the number of worker threads you want to use to calculate potential prime numbers in the parallel foreach

See if you can beat my time for the 5 millionth prime on as many worker threads as you can muster, I used 10 thousand worker threads. My fastest time was about 35 seconds :).
