
using System;
namespace DoublyLinkedList
{
    public class Node<T>
    {
        public T Value;

        public Node<T> Next;

        public Node<T> Prev;

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            } 
            else
            {
                head.Prev = newNode;
                newNode.Next = head;
                head = newNode;
            }
        }

        public Node<T> Find(T value)
        {
            var current = head;
            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void Remove(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                head = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                tail = node.Prev;
            }
        }
        public void PrintForward()
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
        public void PrintBackward()
        {
            var current = tail;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Prev;
            }
        }




    }
}

