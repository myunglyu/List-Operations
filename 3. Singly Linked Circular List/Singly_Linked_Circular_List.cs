using System.Diagnostics.Tracing;

namespace _3._Singly_Linked_Circular_List;

class Program
{
    static void Main(string[] args)
    {
        // Create and populate a new circular list with integers
        MyCircularList<int> myCircularList = new MyCircularList<int>();
        myCircularList.Add(3);
        myCircularList.Add(1);
        myCircularList.Add(2);
        myCircularList.Add(5);
        myCircularList.Add(4);
        myCircularList.PrintList();
        
        // Display the initial state of the list
        Console.WriteLine($"Now the list is: {myCircularList}, Count: {myCircularList.Count}");

        // Demonstrate Contains operation
        Console.WriteLine($"List contains 4: {myCircularList.Contains(4)}");

        // Demonstrate Remove operation
        myCircularList.Remove(3);
        Console.WriteLine($"After removing 3, List: {myCircularList}, Count: {myCircularList.Count}");
        myCircularList.Remove(2);
        Console.WriteLine($"After removing 2, List: {myCircularList}, Count: {myCircularList.Count}");
        myCircularList.Remove(4);
        Console.WriteLine($"After removing 4, List: {myCircularList}, Count: {myCircularList.Count}");

        // Test removing non-existent item
        myCircularList.Remove(999);
        Console.WriteLine($"After trying to remove 999, List: {myCircularList}, Count: {myCircularList.Count}");

        // Demonstrate Clear operation
        myCircularList.Clear();
        Console.WriteLine($"After clearing, List: {myCircularList}, Count: {myCircularList.Count}");

        // Test with strings
        MyCircularList<string> stringList = new MyCircularList<string>();
        stringList.Add("Hello");
        stringList.Add("World");
        stringList.Add("C#");
        stringList.Add("Programming");
        stringList.Add("Language");

        // Display the initial state of the list
        Console.WriteLine($"Now the list is: {stringList}, Count: {stringList.Count}");

        // Demonstrate Contains operation
        Console.WriteLine($"List contains C#: {stringList.Contains("C#")}");
        Console.WriteLine($"List contains Python: {stringList.Contains("Python")}");

        // Demonstrate Remove operation
        stringList.Remove("Hello");
        Console.WriteLine($"After removing Hello, List: {stringList}, Count: {stringList.Count}");
        stringList.Remove("World");
        Console.WriteLine($"After removing World, List: {stringList}, Count: {stringList.Count}");
        stringList.Remove("Language");
        Console.WriteLine($"After removing Language, List: {stringList}, Count: {stringList.Count}");

        // Test removing non-existent item
        stringList.Remove("Python");
        Console.WriteLine($"After trying to remove Python, List: {stringList}, Count: {stringList.Count}");

        // Demonstrate Clear operation
        stringList.Clear();
        Console.WriteLine($"After clearing, List: {stringList}, Count: {stringList.Count}");
    }

    public class Node<T>
    {
        public T Data;                    // Data stored in the node
        public Node<T>? Next = null;      // Reference to the next node

        public Node(T data)
        {
            Data = data;
        }
    }

    internal class MyCircularList<T>
    {
        private Node<T> head;             // Reference to the first node
        private Node<T> current;          // Reference to the current/last node
        public int Count { get; private set; }  // Number of nodes in the list

        // Initializes an empty circular list
        public MyCircularList()
        {
            head = null;
            current = null;
            Count = 0;
        }

        // Checks if the list is empty
        public bool IsEmpty()
        {
            return Count == 0;
        }

        // Adds a new item to the end of the list
        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (IsEmpty())
            {
                // First node becomes both head and current
                head = current = newNode;
            }
            else
            {
                // Link new node to head and update current
                newNode.Next = head;
                current.Next = newNode;
                current = newNode;
            }
            Count++;
        }

        // Checks if an item exists in the list
        public bool Contains(T item)
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty");
                return false;
            }

            // Traverse the list once
            Node<T> current = head;
            do
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            } while (current != head);

            return false;
        }

        // Removes the first occurrence of an item from the list
        public void Remove(T item)
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty");
                return;
            }

            // Special case: removing head node
            if (head.Data.Equals(item))
            {
                if (Count == 1)
                {
                    // List becomes empty
                    head = null;
                    current = null;
                }
                else
                {
                    // Update head and maintain circular structure
                    current.Next = head.Next;
                    head = head.Next;
                }
                Count--;
                return;
            }

            // Search for item in rest of list
            Node<T> prev = head;
            Node<T> curr = head.Next;
            
            while (curr != head)
            {
                if (curr.Data.Equals(item))
                {
                    // Update links and maintain circular structure
                    prev.Next = curr.Next;
                    if (curr == current)
                    {
                        current = prev;
                    }
                    Count--;
                    return;
                }
                prev = curr;
                curr = curr.Next;
            }

            Console.WriteLine($"The item '{item}' is not in the list");
        }

        // Clears all items from the list
        public void Clear()
        {
            head = null;    // Remove reference to first node
            current = null; // Remove reference to last node 
            Count = 0;     // Reset count
        }

        // Returns a string representation of the list
        public override string ToString()
        {
            if (Count == 0)
            {
                return "The list is empty";
            }

            // Build space-separated string of values
            Node<T> node = head;
            string result = "";
            do
            {
                result += node.Data + " ";
                node = node.Next;
            } while (node != head);

            return result.TrimEnd();
        }

        // Prints the list contents to console
        public void PrintList()
        {
            if (Count == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            // Print each value followed by a space
            Node<T> node = head;
            do
            {
                Console.Write(node.Data + " ");
                node = node.Next;
            } while (node != head);
            Console.WriteLine();
        }
    }
}
