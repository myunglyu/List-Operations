/*
Gereric List Implemented
 */

namespace Assignment3_1_GenericClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create an instance
            MyArrayList<int> list = new MyArrayList<int>();
            // check count and capacity
            Console.WriteLine("An empty list is crated, list count: " + list.Count);
            //add to these numbers to the  list
            list.Add(3);
            Console.WriteLine($"After appending 3, Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(1);
            Console.WriteLine($"After appending 1, Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(2);
            Console.WriteLine($"After appending 2, Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(5);
            Console.WriteLine($"After appending 5, Count: {list.Count}, Capacity: {list.Capacity}");
            list.Add(0);
            Console.WriteLine($"After appending 0, Count: {list.Count}, Capacity: {list.Capacity}");
            Console.WriteLine("Now the list is: ");
            list.DisplayList();
            list.Sort(); // sort the list using built-in QuickSort algorithm
            Console.WriteLine("After sorting:");
            list.DisplayList();
            Console.WriteLine("Element at index 2: " + list[2]);
            list.Clear();
            Console.WriteLine($"After invoking Clear(), Count: {list.Count}, Capacity: {list.Capacity}");

            // create a new instance with char type
            MyArrayList<char> charList = new MyArrayList<char>();
            // check count and capacity
            Console.WriteLine("An empty list is created, list count: " + charList.Count);
            // add elements to the list
            charList.Add('c');
            Console.WriteLine($"After appending 'c', Count: {charList.Count}, Capacity: {charList.Capacity}");
            charList.Add('e');
            Console.WriteLine($"After appending 'e', Count: {charList.Count}, Capacity: {charList.Capacity}");
            charList.Add('a');
            Console.WriteLine($"After appending 'a', Count: {charList.Count}, Capacity: {charList.Capacity}");
            charList.Add('b');
            Console.WriteLine($"After appending 'b', Count: {charList.Count}, Capacity: {charList.Capacity}");
            charList.Add('d');
            Console.WriteLine($"After appending 'd', Count: {charList.Count}, Capacity: {charList.Capacity}");
            Console.WriteLine("Now the list is: ");
            charList.DisplayList();
            charList.Sort(); // sort the list using built-in QuickSort algorithm
            Console.WriteLine("After sorting:");
            charList.DisplayList();
            Console.WriteLine("Element at index 3: " + charList[3]);
            charList.Clear();
            Console.WriteLine($"After invoking Clear(), Count: {charList.Count}, Capacity: {charList.Capacity}");
        }
    }

    internal class MyArrayList<T> where T : IComparable<T>
    {
        T[] values; // ArrayList data are stored in an array called values
        public int Count { get; private set; }
        public int Capacity
        {
            get { return values.Length; }
        }

        public MyArrayList(int Capacity = 4) // constructor with default capacity of 4
        {
            values = new T[Capacity]; // allocate the array
            Count = 0; // initially, count is set to 0;
        }

        // append a new element to the end of list
        public void Add(T newValue)
        {
            // check if array is full
            if (Count == Capacity)
            {
                Resize();
            }
            // put newValue into the array at position count
            values[Count] = newValue;
            Count++;
        }

        private void Resize()
        {
            // create a new array of double capacity
            T[] tmp = new T[2 * Capacity];
            // copy over the old values
            for (int pos = 0; pos < Capacity; pos++)
            {
                tmp[pos] = values[pos];
            }
            // reference values array to the new tmp array
            values = tmp;
        }

        public void AddLast(T newValue)
        {
            Add(newValue); // Add method adds a new value to the end
            // or try this: insert(newValue, Count)
        }

        public void AddFirst(T newValue)
        {
            Insert(newValue, 0);
        }

        // insert a new value at a given index
        public void Insert(T newValue, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count}");
            // check if the array is full, double its capacity if needed
            if (Count == Capacity)
                Resize();
            // shift everything from position i to Count-1, to the right by one position
            for (int i = Count; i > index; i--)
            {
                values[i] = values[i - 1];
            }
            // insert the new value
            values[index] = newValue;
            Count++;
        }

        public void DeleteLast()
        {
            if (Count == 0) //you CAN't delete last from an empty list
                throw new IndexOutOfRangeException("You CAN't delete last from an empty list");
            Count--; // just decrement the Count without removing it
        }

        public void DeleteFirst()
        {
            Delete(0);
        }

        // delete an element at a given index
        public void Delete(int index)
        {
            // validate index
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException($"index should be between {0} and {Count - 1}");
            // shift everything (that is past index i) to the left one position
            for (int i = index; i < Count - 1; i++)
                values[i] = values[i + 1];
            Count--;

        }
        public void Clear()
        {
            Count = 0;
            values = new T[4]; // reinitialize the array with default capacity
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void DisplayList()
        {
            if (IsEmpty())
                Console.WriteLine("Empty list!");
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Write(values[i] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        // indexer allows indexing like t[2] to work if t is an instance of ArrayList
        public T this[int i] 
        {
            get { return values[i]; }
            set { values[i] = value; }
        }

        public void Sort()
        {
            QuickSortHelper(values, 0, Count - 1);
        }

        public static void QuickSortHelper(T[] arr, int startIdx, int endIdx)
        {
            if (startIdx < endIdx) //if we have at least 2 elements in the "slice"
            {
                int q = Partition(arr, startIdx, endIdx); //partition the array
                QuickSortHelper(arr, startIdx, q - 1); //sort the first "half"
                QuickSortHelper(arr, q + 1, endIdx); //sort the first "half"
            }
        }

        public static int Partition(T[] arr, int startIdx, int endIdx)
        {
            T pivot = arr[endIdx];//last element = the pivot

            int holder = startIdx - 1; //will tell the position of the last <= pivot value
            for (int i = startIdx; i < endIdx; i++)
            {
                if (arr[i].CompareTo(pivot) <= 0)
                {
                    holder++;
                    T tmp = arr[i];
                    arr[i] = arr[holder];
                    arr[holder] = tmp;
                }
            }
            holder++;
            // swapping
            T tmp2 = arr[endIdx];
            arr[endIdx] = arr[holder];
            arr[holder] = tmp2;
            return holder;
        }
    }
}
