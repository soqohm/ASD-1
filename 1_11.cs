using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public int[] bits;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;

            var size = filter_len / 32;
            if (filter_len % 32 != 0) size++;

            bits = new int[size];
        }

        public int Hash1(string str1)
        {
            return Hash(str1, 17);
        }

        public int Hash2(string str1)
        {
            return Hash(str1, 223);
        }

        public void Add(string str1)
        {
            Add_bit(Hash1(str1));
            Add_bit(Hash2(str1));
        }

        public bool IsValue(string str1)
        {
            return IsValue_bit(Hash1(str1)) && IsValue_bit(Hash2(str1));
        }

        public int Hash(string str, int number)
        {
            var result = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int code = str[i];
                result = ((result * number) + code) % filter_len;
            }
            return result;
        }

        public void Add_bit(int index)
        {
            bits[index / 32] |= 1 << (index % 32);
        }

        public bool IsValue_bit(int index)
        {
            return ((bits[index / 32] >> index % 32) & 1) == 1;
        }
    }
}