using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
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

    public class Dummy<T> : Node<T>
    {
        public Dummy() : base(default) { }
    }

    public class OrderedList<T>
    {
        public Node<T> head { get { return _dummy.next; } set { _dummy.next = value; } }
        public Node<T> tail { get { return _dummy.prev; } set { _dummy.prev = value; } }

        private Dummy<T> _dummy;
        private int _count;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            _dummy = new Dummy<T>();
            _dummy.next = _dummy.prev = _dummy;
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
            if (Compare(head.value, value) != IsAscending() * -1)
            {
                InsertAfter(null, new Node<T>(value));
                _count++;
                return;
            }

            if (Compare(tail.value, value) != IsAscending() * 1)
            {
                InsertAfter(tail, new Node<T>(value));
                _count++;
                return;
            }

            Node<T> node = head.next;

            while (!(node is Dummy<T>))
            {
                if (Compare(node.value, value) != IsAscending() * -1)
                {
                    InsertAfter(node.prev, new Node<T>(value));
                    _count++;
                    return;
                }
                node = node.next;
            }
        }

        public Node<T> Find(T val)
        {
            var c1 = Compare(head.value, val);
            var c2 = Compare(tail.value, val);

            if (c1 == IsAscending() * 1 || c2 == IsAscending() * -1) return null;
            if (c1 == 0) return head;
            if (c2 == 0) return tail;

            Node<T> node = head.next;

            while (!(node is Dummy<T>))
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

            while (!(node is Dummy<T>))
            {
                if (Compare(node.value, val) == 0)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    node.next = node.prev = null;
                    _count--;
                    return;
                }
                node = node.next;
            }
        }

        public void Clear(bool asc)
        {
            head = tail = _dummy;
            _count = 0;
            _ascending = asc;
        }

        public int Count()
        {
            return _count;
        }

        List<Node<T>> GetAll()
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (!(node is Dummy<T>))
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
            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head.prev = _nodeToInsert;
                head = _nodeToInsert;
                head.prev = _dummy;
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