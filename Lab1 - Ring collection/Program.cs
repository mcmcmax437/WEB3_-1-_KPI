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

        Console.WriteLine("-------------------------------------------");

        CircularLinkedList<string> circularList2 = new CircularLinkedList<string>();

        circularList2.Add("2");
        circularList2.Add("3");
        circularList2.Add("32");
        circularList2.Add("adw");
        circularList2.Add("apple");
        circularList2.Add("hundred");
        circularList2.Add("trousers");

        circularList2.Print();
        bool isCircularList2 = circularList2.IsCircularList();
        Console.WriteLine("Is it circular Linked List? " + isCircularList2);

        circularList2.Delete("adw");
        circularList2.Print();
        isCircularList = circularList2.IsCircularList();
        Console.WriteLine("Is it circular Linked List? " + isCircularList2);

        circularList2.Add("###");
        circularList2.Add("0asd2");
        circularList2.Print();
        isCircularList = circularList2.IsCircularList();
        Console.WriteLine("Is it circular Linked List? " + isCircularList2);


    }
}

