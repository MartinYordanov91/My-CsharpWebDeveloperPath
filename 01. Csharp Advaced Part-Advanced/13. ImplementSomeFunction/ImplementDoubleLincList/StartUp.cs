namespace LinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("<------ Custom Doubly Linked List ------> ");
            DoublyLinkedList myList = new DoublyLinkedList();

            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);
            myList.AddLast(1);
            myList.AddLast(2);
            myList.AddLast(3);

            Nodes note = myList.Head;
            while (note != null)
            {
                Console.Write(note.Value + ", ");
                note = note.Next;
            }

            Console.WriteLine( );
            myList.RemoveFirst();

            note = myList.Head;
            while (note != null)
            {
                Console.Write(note.Value + ", ");
                note = note.Next;
            }

            Console.WriteLine();
            myList.RemoveLast();

            note = myList.Head;
            while (note != null)
            {
                Console.Write(note.Value + ", ");
                note = note.Next;
            }
            Console.WriteLine();

            myList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
            int[] myListToArray = myList.ToArray();

            Console.WriteLine(string.Join(", " , myListToArray));
            Console.WriteLine();
            Console.WriteLine("<------ Custom Doubly Linked List ------> ");
            
            
        }
    }
}