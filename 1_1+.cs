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
            Node previous = null;
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (previous == null && node.next == null)
                    {
                        head = tail = null;
                    }
                    else if (previous == null)
                    {
                        head = node.next;
                        node.next = null;
                    }
                    else if (node.next == null)
                    {
                        tail = previous;
                        previous.next = null;
                    }
                    else
                    {
                        previous.next = node.next;
                        node.next = null;
                    }
                    return true;
                }

                previous = node;
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            Node previous = null;
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (previous == null && node.next == null)
                    {
                        node = head = tail = null;
                    }
                    else if (previous == null)
                    {
                        head = node.next;
                        node.next = null;
                        node = head;
                    }
                    else if (node.next == null)
                    {
                        tail = previous;
                        node = previous.next = null;
                    }
                    else
                    {
                        previous.next = node.next;
                        node.next = null;
                        node = previous.next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.next;
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

    static class Extensions
    {
        public static LinkedList GetCombinedList(LinkedList list1, LinkedList list2)
        {
            if (list1 == null || list2 == null || list1.Count() != list2.Count())
                return null;

            LinkedList result = new LinkedList();
            Node node1 = list1.head;
            Node node2 = list2.head;

            while (node1 != null)
            {
                result.AddInTail(new Node(node1.value + node2.value));
                node1 = node1.next;
                node2 = node2.next;
            }
            return result;
        }
    }
}