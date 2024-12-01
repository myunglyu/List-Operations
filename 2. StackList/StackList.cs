namespace _2._StackList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of MyStack with int type
            MyStack<int> myStack = new MyStack<int>();
            
            // Push elements onto the stack
            myStack.Push(3);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(5);
            myStack.Push(4);
            System.Console.WriteLine($"Now the stack is: {myStack}, Count: {myStack.Count}");

            // Check if the stack contains the element 3
            System.Console.WriteLine($"Stack contains 3: {myStack.Contains(3)}");

            // Peek the top element of the stack
            System.Console.WriteLine($"Peek top element: {myStack.Peek()}");

            // Pop the top element of the stack
            System.Console.WriteLine($"Pop top element: {myStack.Pop()}");
            System.Console.WriteLine($"After popping, Stack: {myStack}, Count: {myStack.Count}");
            
            // Clear the stack
            myStack.Clear();
            System.Console.WriteLine($"After clearing, Stack: {myStack}, Count: {myStack.Count}");
        }

        internal class MyStack<T>
        {
            private T[] list; // Array to store stack elements
            public int Count { get; private set; } // Property to get the number of elements in the stack

            // Constructor to initialize the stack
            public MyStack()
            {
                list = new T[4]; // Initial capacity of the stack
                Count = 0; // Initial count is 0
            }

            // Method to clear the stack
            public void Clear()
            {
                list = new T[4]; // Reset the array
                Count = 0; // Reset the count
            }

            // Method to check if the stack contains a specific element
            public bool Contains(T item)
            {
                if (Count == 0)
                {
                    System.Console.WriteLine("The stack is empty");
                }
                foreach (var i in list)
                {
                    if (i.Equals(item))
                    {
                        return true;
                    }
                }
                return false;
            }

            // Method to peek the top element of the stack without removing it
            public string Peek()
            {
                if (Count == 0)
                {
                    return "The stack is empty";
                }
                return list[^1]!.ToString();
            }

            // Method to pop the top element of the stack
            public string Pop()
            {
                if (Count == 0)
                {
                    return "The stack is empty";
                }
                else
                {
                    string result = list[^1].ToString(); // Get the top element
                    list = list[..^1]; // Remove the top element
                    Count--; // Decrease the count
                    if (Count < list.Length / 2)
                    {
                        Array.Resize(ref list, list.Length / 2); // Resize the array if necessary
                    }
                    return $"{result} has been popped from the stack";
                }
            }

            // Method to push an element onto the stack
            public void Push(T item)
            {
                if (Count == list.Length)
                {
                    Array.Resize(ref list, list.Length * 2); // Resize the array if necessary
                }
                list[Count] = item; // Add the element to the stack
                Count++; // Increase the count
                System.Console.WriteLine($"The element {item} has been added to the stack");
            }

            // Override ToString method to return a string representation of the stack
            public override string ToString()
            {
                string result = "";
                for (int i = 0; i < Count; i++)
                {
                    result += list[i].ToString() + " ";
                }
                return result;
            }
        }
    }
}
