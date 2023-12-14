using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class Dummy : Node
    {
        public Dummy() : base(0) { }
    }

    public class LinkedList2
    {
        public Node head { get { return dummy.next; } set { dummy.next = value; } }
        public Node tail { get { return dummy.prev; } set { dummy.prev = value; } }

        private Dummy dummy;

        public LinkedList2()
        {
            dummy = new Dummy();
            dummy.next = dummy.prev = dummy;
        }

        public void AddInTail(Node _item)
        {
            tail.next = _item;
            _item.prev = tail;
            _item.next = dummy;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;

            while (!(node is Dummy))
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;

            while (!(node is Dummy))
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node node = head;

            while (!(node is Dummy))
            {
                if (node.value == _value)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    node.next = node.prev = null;
                    return true;
                }
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;

            while (!(node is Dummy))
            {
                if (node.value == _value)
                {
                    node.next.prev = node.prev;
                    node.prev = null;
                    node = node.next;
                    node.prev.next.next = null;
                    node.prev.next = node;
                }
                else node = node.next;
            }
        }

        public void Clear()
        {
            head = tail = dummy;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;

            while (!(node is Dummy))
            {
                node = node.next;
                count++;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head.prev = _nodeToInsert;
                head = _nodeToInsert;
                head.prev = dummy;
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