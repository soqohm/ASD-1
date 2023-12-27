using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures12
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            if (typeof(T) == typeof(string))
            {
                var s1 = Convert.ToString(v1).Trim();
                var s2 = Convert.ToString(v2).Trim();
                return s1.CompareTo(s2);
            }
            else
            {
                var d1 = Convert.ToDouble(v1);
                var d2 = Convert.ToDouble(v2);
                if (d1 < d2) return -1;
                if (d1 > d2) return 1;
                return 0;
            }
        }

        public void Add(T value)
        {
            if (head == null)
            {
                InsertAfter(null, new Node<T>(value));
                return;
            }

            Node<T> node = head;

            while (node != null)
            {
                if (Compare(node.value, value) != IsAscending() * -1)
                {
                    InsertAfter(node.prev, new Node<T>(value));
                    return;
                }
                node = node.next;
            }

            InsertAfter(tail, new Node<T>(value));
        }

        public Node<T> Find(T val)
        {
            if (head == null || Compare(head.value, val) == IsAscending() * 1 || Compare(tail.value, val) == IsAscending() * -1)
                return null;

            Node<T> node = head;

            while (node != null)
            {
                if (Compare(node.value, val) == 0)
                    return node;
                node = node.next;
            }
            return null;
        }

        public void Delete(T val)
        {
            Node<T> node = head;

            while (node != null)
            {
                if (Compare(node.value, val) == 0)
                {
                    if (node.prev == null && node.next == null)
                    {
                        head = tail = null;
                    }
                    else if (node.prev == null)
                    {
                        head = node.next;
                        node.next = head.prev = null;
                    }
                    else if (node.next == null)
                    {
                        tail = node.prev;
                        tail.next = node.prev = null;
                    }
                    else
                    {
                        node.prev.next = node.next;
                        node.next.prev = node.prev;
                        node.next = node.prev = null;
                    }
                    return;
                }
                node = node.next;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node<T> node = head;

            while (node != null)
            {
                node = node.next;
                count++;
            }
            return count;
        }

        List<Node<T>> GetAll()
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }

        int IsAscending()
        {
            if (_ascending) return 1;
            return -1;
        }

        void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
        {
            if (_nodeAfter == null && head == null)
            {
                head = tail = _nodeToInsert;
                head.next = head.prev = null;
            }
            else if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head.prev = _nodeToInsert;
                head = _nodeToInsert;
                head.prev = null;
            }
            else if (_nodeAfter.next == null)
            {
                tail.next = _nodeToInsert;
                _nodeToInsert.prev = tail;
                tail = _nodeToInsert;
                tail.next = null;
            }
            else
            {
                _nodeAfter.next.prev = _nodeToInsert;
                _nodeToInsert.prev = _nodeAfter;
                _nodeToInsert.next = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
            }
        }
    }

}