using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures99
{

    public class Queue<T>
    {
        readonly LinkedList linkedList;

        public Queue()
        {
            linkedList = new LinkedList();
        }

        public void Enqueue(T item)
        {
            linkedList.AddInTail(new Node(item));
        }

        public T Dequeue()
        {
            var obj = linkedList.Head;
            var isDeleted = linkedList.RemoveFromHead();
            if (isDeleted) return obj.value;
            return default;
        }

        public int Size()
        {
            return linkedList.Count();
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

            public void AddInTail(Node _item)
            {
                Tail.next = _item;
                _item.prev = Tail;
                _item.next = dummy;
                Tail = _item;
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
            public Dummy() : base(default) { }
        }

    }
}