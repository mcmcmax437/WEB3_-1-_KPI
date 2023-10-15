using System;
using System.Collections.Generic;

namespace Lab1___Ring_collection
{
    public class RingCollection<T>
    {
        private T[] buffer;
        private int capacity;
        private int count;
        private int head;
        private int tail;

        public RingCollection(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            this.capacity = capacity;
            this.buffer = new T[capacity];
            this.count = 0;
            this.head = 0;
            this.tail = 0;
        }

        public int Count => count;

        public bool IsRingCollection()
        {
            return count <= capacity && head >= 0 && head < capacity && tail >= 0 && tail < capacity;
        }

        public void Add(T item)
        {
            if (count == capacity)
            {
                // Buffer повний, перезаписує ластовий елемент
                head = (head + 1) % capacity;
            }
            buffer[tail] = item;
            tail = (tail + 1) % capacity;
            count++;
        }

        public T Delete()
        {
            if (count == 0)
                throw new InvalidOperationException("The ring collection is empty.");

            T item = buffer[head];
            head = (head + 1) % capacity;
            count--;
            return item;
        }
    }
}

