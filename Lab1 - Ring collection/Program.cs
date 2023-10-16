using Lab1___Ring_collection;
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        CircularLinkedList<int> circularList = new CircularLinkedList<int>();

        circularList.Add(1);
        circularList.Add(2);
        circularList.Add(3);
        circularList.Add(5);
        circularList.Add(-2);
        circularList.Add(100);
        circularList.Add(0);

        circularList.Print();
        bool isCircularList = circularList.IsCircularList();
        Console.WriteLine("Is it circular Linked List? " + isCircularList);
      
        circularList.Delete(0);
        circularList.Print();
        isCircularList = circularList.IsCircularList();
        Console.WriteLine("Is it circular Linked List? " + isCircularList);

        circularList.Add(666);
        circularList.Add(843);
        circularList.Print();
        isCircularList = circularList.IsCircularList();
        Console.WriteLine("Is it circular Linked List? " + isCircularList);


    }
}

