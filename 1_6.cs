using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures10
{

    class Deque<T>
    {
        readonly LinkedList linkedList;

        public Deque()
        {
            linkedList = new LinkedList();
        }

        public void AddFront(T item)
        {
            linkedList.AddHead(new Node(item));
        }

        public void AddTail(T item)
        {
            linkedList.AddTail(new Node(item));
        }

        public T RemoveFront()
        {
            var obj = linkedList.Head;
            var isDeleted = linkedList.RemoveHead();
            if (isDeleted) return obj.value;
            return default;
        }

        public T RemoveTail()
        {
            var obj = linkedList.Tail;
            var isDeleted = linkedList.RemoveTail();
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

            public void AddHead(Node _node)
            {
                _node.next = Head;
                Head.prev = _node;
                Head = _node;
                Head.prev = dummy;
            }

            public void AddTail(Node _node)
            {
                Tail.next = _node;
                _node.prev = Tail;
                _node.next = dummy;
                Tail = _node;
            }

            public bool RemoveHead()
            {
                return Remove(Head);
            }

            public bool RemoveTail()
            {
                return Remove(Tail);
            }

            bool Remove(Node node)
            {
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