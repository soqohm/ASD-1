using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
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

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;

            while (node != null)
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

            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
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
                    return true;
                }

                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node.prev == null && node.next == null)
                    {
                        node = head = tail = null;
                    }
                    else if (node.prev == null)
                    {
                        head = node.next;
                        node.next = head.prev = null;
                        node = head;
                    }
                    else if (node.next == null)
                    {
                        tail = node.prev;
                        node = tail.next = null;
                    }
                    else
                    {
                        node.next.prev = node.prev;
                        node.prev = null;
                        node = node.next;
                        node.prev.next.next = null;
                        node.prev.next = node;
                    }
                }
                else node = node.next;
            }
        }

        public void Clear()
        {
            head = tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;

            while (node != null)
            {
                node = node.next;
                count++;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
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