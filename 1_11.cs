using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        private int[] _bits;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            _bits = new int[filter_len];
            for (int i = 0; i < filter_len; i++) _bits[i] = 0;
        }

        public int Hash1(string str1)
        {
            var result = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = ((result * 17) + code) % filter_len;
            }
            return result;
        }

        public int Hash2(string str1)
        {
            var result = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = ((result * 223) + code) % filter_len;
            }
            return result;
        }

        public void Add(string str1)
        {
            _bits[Hash1(str1)] = 1;
            _bits[Hash2(str1)] = 1;
        }

        public bool IsValue(string str1)
        {
            return _bits[Hash1(str1)] == 1 && _bits[Hash2(str1)] == 1;
        }
    }
}