using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures15
{

    public class PowerSet<T>
    {
        public Dictionary<string, T> Pairs;

        public PowerSet()
        {
            Pairs = new Dictionary<string, T>();
        }

        public int Size()
        {
            return Pairs.Count;
        }

        public void Put(T value)
        {
            var key = $"{value}";

            if (!Pairs.ContainsKey(key))
                Pairs.Add(key, value);
        }

        public bool Get(T value)
        {
            return Pairs.ContainsKey($"{value}");
        }

        public bool Remove(T value)
        {
            var key = $"{value}";

            if (Pairs.ContainsKey(key))
            {
                Pairs.Remove(key);
                return true;
            }
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();

            foreach (var e in Pairs.Values)
                if (set2.Get(e))
                    result.Put(e);

            return result;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();

            foreach (var e in Pairs.Values)
                result.Put(e);

            foreach (var e in set2.Pairs.Values)
                result.Put(e);

            return result;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var result = new PowerSet<T>();

            foreach (var e in Pairs.Values)
                if (!set2.Get(e))
                    result.Put(e);

            return result;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            foreach (var e in set2.Pairs.Values)
                if (!Get(e))
                    return false;

            return true;
        }
    }
}