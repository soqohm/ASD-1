using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        public int HashFun(string key)
        {
            var hash = 0;
            foreach (var e in key)
                hash += (byte)e;
            return hash % size;
        }

        public bool IsKey(string key)
        {
            return Find(key) != -1;
        }

        public void Put(string key, T value)
        {
            var index = Find(key);

            if (index == -1)
                index = SeekSlot(key);

            if (index == -1)
                index = GetRewriteIndex(key);

            slots[index] = key;
            values[index] = value;
            hits[index] = 0;
        }

        public T Get(string key)
        {
            var index = Find(key);
            if (index == -1) return default;
            hits[index]++;
            return values[index];
        }

        public int SeekSlot(string value)
        {
            var index = HashFun(value);

            var i = index;
            for (; i < size; i += 1)
                if (slots[i] == null)
                    return i;

            i -= size;
            for (; i < index; i += 1)
                if (slots[i] == null)
                    return i;

            return -1;
        }

        public int Find(string value)
        {
            return Array.IndexOf(slots, value);
        }

        public int GetRewriteIndex(string key)
        {
            var index = hits[HashFun(key)];

            for (int i = 0; i < hits.Length; i++)
                if (hits[i] < index)
                    index = hits[i];
            return index;
        }
    }
}