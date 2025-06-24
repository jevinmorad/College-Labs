using System.Collections;

while (true)
{
    Console.Write("\nEnter a program number: ");
    int n = int.Parse(Console.ReadLine());
    switch(n)
    {
        /* Create an ArrayList for StudentName and perform following operations: 
            a.Add() - To Add new student in list
            b.Remove() - To Remove Student with specified index
            c.RemoveRange() - To Remove student with specified range.
            d.Clear() - To clear all the student from the list
        */
        case 1:
            ArrayList studentNames = new ArrayList();
            studentNames.Add("Jevin");
            studentNames.Add("Dhaval");
            studentNames.Add("Yash");
            studentNames.Add("Niv");
            Console.WriteLine("Students after adding: " + string.Join(", ", studentNames.ToArray()));
            studentNames.RemoveAt(1);
            Console.WriteLine("Students after removing index 1: " + string.Join(", ", studentNames.ToArray()));
            studentNames.RemoveRange(0, 2);
            Console.WriteLine("Students after removing range(0,2): " + string.Join(", ", studentNames.ToArray()));
            studentNames.Clear();
            Console.WriteLine("Students after clearing: " + string.Join(", ", studentNames.ToArray()));
            break;

        /* Create a List for StudentName and perform following operations: 
            a.Add() - To Add new student in list
            b.Remove() - To Remove Student with specified index
            c.RemoveRange() - To Remove student with specified range.
            d.Clear() - To clear all the student from the list
        */
        case 2:
            List<string> studentList = new List<string>();
            studentList.Add("Jevin");
            studentList.Add("Dhaval");
            studentList.Add("Yash");
            Console.WriteLine("Students after adding: " + string.Join(", ", studentList));
            studentList.RemoveAt(0);
            Console.WriteLine("Students after removing index 0: " + string.Join(", ", studentList));
            studentList.RemoveRange(0, 1);
            Console.WriteLine("Students after removing range: " + string.Join(", ", studentList));
            studentList.Clear();
            Console.WriteLine("Students after clearing: " + string.Join(", ", studentList));
            break;

        /* Create a Stack which takes integer values and perform following operations: 
            a. Push() - To Add new item in stack 
            b. Pop() - To Remove item from the stack 
            c. Peek() – To Return the top item from the stack. 
            d. Contains() - To Checks whether an item exists in the stack or not. 
            e. Clear() - To clear items from stack
        */
        case 3:
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine("Stack after pushing: " + string.Join(", ", stack));
            stack.Pop();
            Console.WriteLine("Stack after popping: " + string.Join(", ", stack));
            Console.WriteLine("Top item in stack: " + stack.Peek());
            Console.WriteLine("Does stack contain 20? " + stack.Contains(20));
            stack.Clear();
            Console.WriteLine("Stack after clearing: " + string.Join(", ", stack));
            break;

        /* Create a Queue which takes integer values and perform following operations: 
            a.Enqueue() - To Add new item in queue 
            b.Dequeue() - To Remove item from the queue 
            c.Peek() – To Return the front item from the queue. 
            d.Contains() - To Checks whether an item exists in the queue or not. 
            e.Clear() - To clear items from queue
        */
        case 4:
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            Console.WriteLine("Queue after enqueueing: " + string.Join(", ", queue));
            queue.Dequeue();
            Console.WriteLine("Queue after dequeueing: " + string.Join(", ", queue));
            Console.WriteLine("Front item in queue: " + queue.Peek());
            Console.WriteLine("Does queue contain 20? " + queue.Contains(20));
            queue.Clear();
            Console.WriteLine("Queue after clearing: " + string.Join(", ", queue));
            break;

        /* Create a Dictionary collection class object and preform following operations: 
            a. Add: Adds a key-value pair. 
            b. Remove: Removes a key-value pair by key. 
            c. ContainsKey: Checks if a key exists in the hashtable. 
            d. ContainsValue: Checks if a value exists in the hashtable. 
            e. Clear: Removes all key-value pairs.
        */
        case 5:
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Jevin");
            dictionary.Add(2, "Dhaval");
            dictionary.Add(3, "Yash");
            Console.WriteLine("Dictionary after adding: " + string.Join(", ", dictionary.Select(kv => $"{kv.Key}: {kv.Value}")));
            dictionary.Remove(2);
            Console.WriteLine("Dictionary after removing key 2: " + string.Join(", ", dictionary.Select(kv => $"{kv.Key}: {kv.Value}")));
            Console.WriteLine("Does dictionary contain key 1? " + dictionary.ContainsKey(1));
            Console.WriteLine("Does dictionary contain value 'Yash'? " + dictionary.ContainsValue("Yash"));
            dictionary.Clear();
            Console.WriteLine("Dictionary after clearing: " + string.Join(", ", dictionary.Select(kv => $"{kv.Key}: {kv.Value}")));
            break;

        /*6. Create a Hashtable collection class object and preform following operations: 
            a. Add: Adds a key-value pair. 
            b. Remove: Removes a key-value pair by key. 
            c. ContainsKey: Checks if a key exists in the hashtable. 
            d. ContainsValue: Checks if a value exists in the hashtable. 
            e. Clear: Removes all key-value pairs.
        */
        case 6:
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "Jevin");
            hashtable.Add(2, "Dhaval");
            hashtable.Add(3, "Yash");
            Console.WriteLine("Hashtable after adding: " + string.Join(", ", hashtable.Keys.Cast<int>().Select(k => $"{k}: {hashtable[k]}")));
            hashtable.Remove(2);
            Console.WriteLine("Hashtable after removing key 2: " + string.Join(", ", hashtable.Keys.Cast<int>().Select(k => $"{k}: {hashtable[k]}")));
            Console.WriteLine("Does hashtable contain key 1? " + hashtable.ContainsKey(1));
            Console.WriteLine("Does hashtable contain value 'Yash'? " + hashtable.ContainsValue("Yash"));
            hashtable.Clear();
            Console.WriteLine("Hashtable after clearing: " + string.Join(", ", hashtable.Keys.Cast<int>().Select(k => $"{k}: {hashtable[k]}")));
            break;

        default:
            Console.WriteLine("Invalid program number.");
            return 0;

    }
}