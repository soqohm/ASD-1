using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures7
{

    public class Stack<T>
    {
        readonly LinkedList linkedList;

        public Stack()
        {
            linkedList = new LinkedList();
        }

        public int Size()
        {
            return linkedList.Count();
        }

        public T Pop()
        {
            var obj = linkedList.Head;
            var isDeleted = linkedList.RemoveFromHead();
            if (isDeleted) return obj.value;
            return default(T);
        }

        public void Push(T val)
        {
            linkedList.AddInHead(new Node(val));
        }

        public T Peek()
        {
            return linkedList.Head.value;
        }

        class LinkedList
        {
            public Node Head { get { return dummy.next; } set { dummy.next = value; } }
            public Node Tail { get { return dummy.prev; } set { dummy.prev = value; } }

            readonly Dummy dummy;

            public LinkedList()
            {
                dummy = new Dummy();
                dummy.next = dummy.prev = dummy;
            }

            public int Count()
            {
                int count = 0;
                Node node = Head;

                while (!(node is Dummy))
                {
                    node = node.next;
                    count++;
                }
                return count;
            }

            public void AddInHead(Node _node)
            {
                _node.next = Head;
                Head.prev = _node;
                Head = _node;
                Head.prev = dummy;
            }

            public bool RemoveFromHead()
            {
                Node node = Head;
                if (node is Dummy) return false;

                node.prev.next = node.next;
                node.next.prev = node.prev;
                node.next = node.prev = null;
                return true;
            }
        }

        class Node
        {
            public T value;
            public Node next, prev;
            public Node(T _value) { value = _value; }
        }

        class Dummy : Node
        {
            public Dummy() : base(default(T)) { }
        }
    }

}