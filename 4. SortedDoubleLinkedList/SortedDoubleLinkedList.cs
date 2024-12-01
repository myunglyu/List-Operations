namespace _4._SortedDoubleLinkedList;

class Program
{
    static void Main(string[] args)
    {
        var testList = new SortedDoublyLinkedList<int>(); // testList can only store integers
        Console.WriteLine("Display the contents of a newly created list: ");
        testList.PrintList();

        // Insert elements into the list
        Console.WriteLine($"Insert 7 to the list");
        testList.Insert(7);
        Console.WriteLine($"Insert 6 to the list");
        testList.Insert(6);
        Console.WriteLine($"Insert 14 to the list");
        testList.Insert(14);
        Console.WriteLine($"Insert 2 to the list");
        testList.Insert(2);
        Console.WriteLine($"Insert 9 to the list");
        testList.Insert(9);
        Console.WriteLine($"Insert 10 to the list");
        testList.Insert(10);
        Console.WriteLine($"Insert 12 to the list");
        testList.Insert(12);
        Console.WriteLine($"Insert 8 to the list");
        testList.Insert(8);
        
        // Display the list
        Console.WriteLine("Display the whole list");
        testList.PrintList();
        System.Console.WriteLine($"Total count of the list is {testList.Count}");

        // Check if the list contains a specific element
        Console.WriteLine($"Check if the list contains 9: {testList.Contains(9)}");
        Console.WriteLine($"Check if the list contains 10: {testList.Contains(10)}");
        Console.WriteLine($"Check if the list contains 6: {testList.Contains(6)}");
        System.Console.WriteLine($"Check if the list contains 99: {testList.Contains(99)}");

        // Remove elements from the list
        Console.WriteLine($"Remove the tail node:");
        testList.RemoveTail();
        testList.PrintList();

        Console.WriteLine($"Remove the head node:");
        testList.RemoveHead();
        testList.PrintList();

        Console.WriteLine($"Remove the node with value 9:");
        testList.Remove(9);
        testList.PrintList();
        System.Console.WriteLine($"Remove the node with value 10:");
        testList.Remove(10);
        testList.PrintList();
        System.Console.WriteLine($"Remove the node with value 6:");
        testList.Remove(6);
        testList.PrintList();
        System.Console.WriteLine($"Remove the node with value 12:");
        testList.Remove(12);
        testList.PrintList();
        System.Console.WriteLine($"Remove the node with value 99:");
        testList.Remove(99);
        testList.PrintList();
        
        // Display the head and tail nodes
        Console.WriteLine("head node is " + testList.head.Data);
        Console.WriteLine("tail node is " + testList.tail.Data);
        Console.WriteLine("count of nodes is " + testList.Count);

        // Clear the list
        Console.WriteLine("Clear the list and display the contents:");
        testList.Clear();
        testList.PrintList();

        // Test removing from an empty list
        Console.WriteLine("Remove from an empty list:");
        testList.Remove(1);

        // Test removing from a list with only one node
        Console.WriteLine("Insert 1 to the list");
        testList.Insert(1);
        testList.PrintList();
        Console.WriteLine("Remove the node with value 1:");
        testList.Remove(1);
        testList.PrintList();
    }
}
// Define the Node class
public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Prev { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}
// Define the SortedDoublyLinkedList class
public class SortedDoublyLinkedList<T> where T : IComparable<T>
{
    public Node<T> head;
    public Node<T> tail;
    public int Count { get; private set; }
    // Default Constructor for SortedDoublyLinkedList
    public SortedDoublyLinkedList()
    {
        head = tail = null;
        Count = 0;
    }
    // Method to check if the list is empty
    public bool IsEmpty(){return Count == 0;}
    // Method to insert a new node with data in a sorted order
    public void Insert(T data)
    {
        Node<T> newNode = new Node<T>(data);
        
        // If list is empty
        if (IsEmpty())
        {
            head = tail = newNode;
            Count++;
            return;
        }

        // If new node is smaller than head
        if (data.CompareTo(head.Data) <= 0)
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
            Count++;
            return;
        }

        // If new node is greater than tail
        if (data.CompareTo(tail.Data) >= 0)
        {
            newNode.Prev = tail;
            tail.Next = newNode;
            tail = newNode;
            Count++;
            return;
        }

        // Find the right position
        Node<T> current = head;
        while (current != null && current.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        // Insert before current
        newNode.Next = current;
        newNode.Prev = current.Prev;
        current.Prev.Next = newNode;
        current.Prev = newNode;
        Count++;
    }
    // Method to display the list
    public void PrintList()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error: The list is empty");
            return;
        }

        Console.Write("Sorted List: Head");
        Node<T> curr = head;
        while (curr != null)
        {
            Console.Write(" <-");
            Console.Write(curr.Data);
            Console.Write("-> ");
            curr = curr.Next;
        }
        Console.WriteLine("Tail");
    }
    // Method to check if the list contains a specific element
    public bool Contains(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0)
                return true;
            current = current.Next;
        }
        return false;
    }
    // Method to remove the head node
    public void RemoveHead()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error: The list is empty");
            return;
        }
        else if (head == tail) // if there is only one node
        {
            System.Console.WriteLine($"[Notification] The list has been cleared");
            Clear();
        }
        else {
            System.Console.WriteLine($"[Notification] Head node with {head.Data} is removed");
            head = head.Next;
            head.Prev = null;
            Count--;
        }
    }
    // Method to remove the tail node
    public void RemoveTail()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error: The list is empty");
            return;
        }
        else if (head == tail) // if there is only one node
        {
            System.Console.WriteLine($"[Notification] The list has been cleared");
            Clear();
        }
        else
        {
            System.Console.WriteLine($"[Notification] Tail node with {tail.Data} is removed");
            tail = tail.Prev;
            tail.Next = null;
        }
        Count--;
    }
    // Method to remove a node with a specific value
    public void Remove(T data)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error: The list is empty");
            return;
        }

        if (head.Data.CompareTo(data) == 0) // if the value is same as the head node
        {
            RemoveHead();
            return;
        }

        if (tail.Data.CompareTo(data) == 0) // if the value is same as the tail node
        {
            RemoveTail();
            return;
        }

        Node<T> current = head.Next; // start from the second node
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0) // if the value is found
            {
            current.Prev.Next = current.Next; // link the previous node to the next node and skip the current node
            current.Next.Prev = current.Prev;
            Count--;
            System.Console.WriteLine($"[Notification] Node with '{data}' is removed");
            return;
            }
            current = current.Next; // move to the next node
        }
        System.Console.WriteLine($"Error: Node with '{data}' is not found");
    }
    // Method to clear the list
    public void Clear()
    {
        head = tail = null;
        Count = 0;
    }
}