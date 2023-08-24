using CustomLinkedList;
using System;

CustomDoublyLinkedList<int> intList = new();
intList.AddFirst(3);
intList.AddFirst(2);
intList.AddFirst(1);
intList.AddLast(4);

Console.WriteLine(intList.RemoveFirst());
Console.WriteLine(intList.RemoveLast());
int[] arr = intList.ToArray();

intList.ForEach(x => Console.Write(x + " "));

Console.WriteLine();
Console.WriteLine(intList.Count);

CustomDoublyLinkedList<string> StringList = new();
StringList.AddFirst("some");
StringList.AddFirst("random");
StringList.AddFirst("strings");
StringList.AddLast("Adding");

StringList.ForEach(x => Console.Write(x + " "));

Console.WriteLine();
Console.WriteLine(StringList.Count);