using System;

namespace CustomLinkedList;

public class CustomDoublyLinkedList<T>
{
    private class Node
    {
        public Node(T value)
        {
            Value = value;

        }

        public Node Next { get; set; }
        public Node Previous { get; set; }
        public T Value { get; set; }
    }
   
    private Node head;
    private Node tail;
    public int Count { get; private set; }

    public void AddFirst(T number)
    {
        Node newNode = new(number);

        if (Count == 0)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        Count++;
    }
    public void Add(T number)
    {
        Node newNode = new(number);

        if (Count == 0)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        Count++;
    }
    public void AddLast(T number)
    {
        Node newNode = new Node(number);
        if (Count == 0)
        {
            tail = head = newNode;
        }
        else
        {
            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }
        Count++;
    }
    public T RemoveFirst()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }

        T firstElement = head.Value;
        Node newHead = head.Next;

        if (Count == 1)
        {
            head = tail = null;
        }
        else
        {
            newHead.Previous = null;
            head = newHead;
        }
        Count--;

        return firstElement;
    }
    public T Remove()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }

        T firstElement = head.Value;
        Node newHead = head.Next;

        if (Count == 1)
        {
            head = tail = null;
        }
        else
        {
            newHead.Previous = null;
            head = newHead;
        }
        Count--;

        return firstElement;
    }
    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }
        T lastElement = tail.Value;
        Node newTail = tail.Previous;

        if (Count == 1)
        {
            tail = head = null;
        }
        else
        {
            newTail.Next = null;
            tail = newTail;
        }
        Count--;
        return lastElement;
    }
    public void ForEach(Action<T> action)
    {
        Node note = head;
        while (note != null)
        {
            action(note.Value);
            note = note.Next;
        }
    }
    public T[] ToArray()
    {
        T[] array = new T[Count];


        var note = head;
        for (int i = 0; i < Count; i++)
        {
            array[i] = note.Value;
            note = note.Next;
        }
        return array;
    }
}


