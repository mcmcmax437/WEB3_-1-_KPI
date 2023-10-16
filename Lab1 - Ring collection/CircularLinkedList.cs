using System;
using System.Collections.Generic;

namespace Lab1___Ring_collection
{
    public class CircularLinkedList<T>
    {
        private class Node
        {
            public T Value;
            public Node Next;
        }

        private Node head;
        private Node tail;
        private int count;

        public int Count => count;

        public bool IsCircularList()
        {
            if (count == 0)
                return false;

            Node current = head;
            for (int i = 0; i < count; i++)
            {
                if (current == null || current.Next == null)
                    return false;
                current = current.Next;
            }

            return current == head; 
        }

        public void Add(T item)
        {
            Node newNode = new Node
            {
                Value = item,
                Next = null
            };

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                newNode.Next = head;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
                tail.Next = head;
            }

            count++;
        }

        public bool Delete(T item)
        {
            if (count == 0)
                throw new InvalidOperationException("Empty!");

            if (count == 1 && head.Value.Equals(item))
            {
                head = null;
                tail = null;
                count--;
                return true;
            }

            Node current = head;
            Node previous = null;
            bool found = false;

            do
            {
                if (current.Value.Equals(item))
                {
                    found = true;
                    break;
                }
                previous = current;
                current = current.Next;
            } while (current != head);

            if (found)
            {
                if (current == head)
                {
                    head = current.Next;
                    tail.Next = head;
                }
                else if (current == tail)
                {
                    tail = previous;
                    tail.Next = head;
                }
                else
                {
                    previous.Next = current.Next;
                }

                count--;
            }

            return found;
        }

        public void Print()
        {
            if (count == 0)
            {
                Console.WriteLine("Empty!");
                return;
            }
            Node curr = head;
            
            for (int i=0; i < count; i++)
            {
                if (i == 0 || i == count-1)
                {
                    Console.Write(curr.Value+"("+ head.Value +"/"+ tail.Value + ")" + " -> ");
                    curr = curr.Next;
                }
                else
                {
                    Console.Write(curr.Value + " -> ");
                    curr = curr.Next;
                }
                
            }
            Console.WriteLine(".....");
        }
    }

}

