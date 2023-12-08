using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
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
            Node _previous = null;
            Node _node = head;

            while (_node != null)
            {
                if (_node.value == _value)
                {
                    if (_previous == null && _node.next == null)
                    {
                        head = tail = null;
                    }
                    else if (_previous == null)
                    {
                        head = _node.next;
                        _node.next = null;
                    }
                    else if (_node.next == null)
                    {
                        tail = _previous;
                        _previous.next = null;
                    }
                    else
                    {
                        _previous.next = _node.next;
                        _node.next = null;
                    }
                    return true;
                }
                _previous = _node;
                _node = _node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            Node _previous = null;
            Node _node = head;

            while (_node != null)
            {
                if (_node.value == _value)
                {
                    if (_previous == null && _node.next == null)
                    {
                        _node = head = tail = null;
                    }
                    else if (_previous == null)
                    {
                        head = _node.next;
                        _node.next = null;
                        _node = head;
                    }
                    else if (_node.next == null)
                    {
                        tail = _previous;
                        _node = _previous.next = null;
                    }
                    else
                    {
                        _previous.next = _node.next;
                        _node.next = null;
                        _node = _previous.next;
                    }
                }
                else
                {
                    _previous = _node;
                    _node = _node.next;
                }
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
            }
            else if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head = _nodeToInsert;
            }
            else if (_nodeAfter.next == null)
            {
                tail.next = _nodeToInsert;
                tail = _nodeToInsert;
            }
            else
            {
                _nodeToInsert.next = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
            }
        }

    }
}