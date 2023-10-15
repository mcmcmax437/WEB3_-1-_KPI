using Lab1___Ring_collection;
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        RingCollection<int> ring = new RingCollection<int>(5);

        ring.Add(1);
        ring.Add(2);
        ring.Add(3);
        ring.Add(5);
        ring.Add(-2);
        ring.Add(100);
        ring.Add(0);

        bool isRing = ring.IsRingCollection();
        Console.WriteLine("Is it a ring collection? " + isRing);

        /*
        ring.Delete();
        isRing = ring.IsRingCollection();
        Console.WriteLine("Is it a ring collection after dequeue? " + isRing); 
        ring.Add(4);
        ring.Add(5);
        isRing = ring.IsRingCollection();
        Console.WriteLine("Is it a ring collection after filling the buffer? " + isRing); 
        ring.Add(6);
        isRing = ring.IsRingCollection();
        Console.WriteLine("Is it a ring collection after overwriting? " + isRing); 
       */
    }
}
