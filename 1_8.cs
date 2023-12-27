using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            var hash = 0;

            foreach (var e in value)
                hash += (byte)e;

            return hash % size;
        }

        public int SeekSlot(string value)
        {
            var index = HashFun(value);

            var i = index;
            for (; i < size; i += step)
                if (slots[i] == null)
                    return i;

            i -= size;
            for (; i < index; i += step)
                if (slots[i] == null)
                    return i;

            return -1;
        }

        public int Put(string value)
        {
            var index = SeekSlot(value);

            if (index == -1)
                return -1;

            slots[index] = value;
            return index;
        }

        public int Find(string value)
        {
            return Array.IndexOf(slots, value);
        }
    }

}