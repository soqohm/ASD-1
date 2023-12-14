using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            var new_array = new T[new_capacity];

            for (int i = 0; i < count; i++)
                new_array[i] = array[i];

            array = new_array;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index > count - 1)
                throw new IndexOutOfRangeException();

            return array[index];
        }

        public void Append(T itm)
        {
            if (count == capacity)
                MakeArray(capacity * 2);

            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();

            if (count == capacity)
                MakeArray(capacity * 2);

            for (int i = count - 1; i > index - 1; i--)
                array[i + 1] = array[i];

            array[index] = itm;
            count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > count - 1)
                throw new IndexOutOfRangeException();

            for (int i = index; i < count - 1; i++)
                array[i] = array[i + 1];

            count--;

            if (count < (double)capacity / 2)
                DownsizeCapacity();
        }

        void DownsizeCapacity()
        {
            if (capacity == 16)
                return;

            var new_capacity = (int)(capacity / 1.5);

            if (new_capacity < 16)
                MakeArray(16);
            else
                MakeArray(new_capacity);
        }

    }
}