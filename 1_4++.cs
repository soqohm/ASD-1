using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        readonly LinkedList linkedList;
        int Count;

        public Stack()
        {
            linkedList = new LinkedList();
        }

        public int Size()
        {
            return Count;
        }

        public T Pop()
        {
            var obj = linkedList.Head;
            var isDeleted = linkedList.RemoveFromHead();
            if (isDeleted)
            {
                Count--;
                return obj.value;
            }
            return default;
        }

        public void Push(T val)
        {
            linkedList.AddInHead(new Node(val));
            Count++;
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
            public Dummy() : base(default) { }
        }
    }

    public static class Extensions
    {
        public static bool IsBalanced(string s)
        {
            var stack = new Stack<char>();

            for (var i = s.Length - 1; i > -1; i--)
            {
                if (s[i] == ')')
                    stack.Push(s[i]);
                if (s[i] == '(' && stack.Size() == 0)
                    return false;
                if (s[i] == '(')
                    stack.Pop();
            }
            return stack.Peek() == default(char);
        }

        public static double PostfixCalc(string s)
        {
            var stack = new Stack<double>();
            var x = 0.0;
            var y = 0.0;
            var operators = new List<char>() { '+', '-', '*', '/' };

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i])) stack.Push(double.Parse(s[i].ToString()));
                if (operators.Contains(s[i])) { x = stack.Pop(); y = stack.Pop(); }
                if (s[i] == '+') stack.Push(x + y);
                if (s[i] == '-') stack.Push(x - y);
                if (s[i] == '*') stack.Push(x * y);
                if (s[i] == '/') stack.Push(x / y);
                if (s[i] == '=') return stack.Peek();
            }
            return stack.Peek();
        }
    }

}