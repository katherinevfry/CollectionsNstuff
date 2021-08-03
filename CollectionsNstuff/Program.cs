using System;
using System.Collections.Generic;

namespace CollectionsNstuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //All of these methods mutate the original collection

            //List<T> is a generic type, that requires me to tell it what kind of stuff it does/uses
            //string in this case is the type parameter
            var e14Names = new List<string>();

            //add a single item 
            //works like .push in JS, appends to end.
            e14Names.Add("Katy");
            e14Names.Add("Chie");
            e14Names.Add("Holly");

            //inserts Chris between Chie and Holly
            e14Names.Insert(2, "Chris");

            //list initializer. you can leave off the parentheses like above.
            var teacherNames = new List<string> { "Nathan", "Jameka", "Dylan", "Tom" };

            //everything on an interface is public (e.g. ICollection, IEnumerable<t>, etc.)
            //add one collection to another
            e14Names.AddRange(teacherNames);

            //remove tom (this uses something called reference equality)
            e14Names.Remove("Tom");

            //removes the item at index 2
            e14Names.RemoveAt(2);

            //remove by expression || lambda expression
            e14Names.RemoveAll(name => name.StartsWith("N"));

            //normal c# foreach loop
            foreach (var name in e14Names)
            {
                Console.WriteLine($"{name} is in e14!");
            }

            //lists have a special way of looping
            //an action takes in a string and returns nothing
            e14Names.ForEach(name => Console.WriteLine($"{name} is in e14"));

            //get the item at the index of 0
            var firstStudent = e14Names[0];

            //Dictionary<TKey, TValue> -- Open generic (no one has told it how to behave yet)
            //Arity (`2) -> how many generic type parameters a type has. Dictionary`2
            //dictionaries are good for infrequently updated but often read data
            //good for loading information at startup or in the background and fast retrieval on demand (caching)
            //like a physical dictionary, kinda
            //keys MUST be unique

            //a dictionary keyed  by strings where strings are the value
            var dictionary = new Dictionary<string, string>(); //closed generic (we have told it how to behave)

            dictionary.Add("penultimate", "second to last");
            dictionary.Add("Gib", "the things that stick out of rollercoasters");
            dictionary.Add("Arbitrary", "Someone who doesn't like Arby's");

            //indexed by key value
            var definition = dictionary["Gib"];

            //you can't do this -- dictionaries require each key to be unique
            //dictionary.Add("Penultimate", "things said too many times at the olympics");

            //try methods
            if (!dictionary.TryAdd("penultimate", "new def"))
            {
                Console.WriteLine("It's already in the dictionary, I couldn't add it");
            }
            
            //a better way
            if (!dictionary.ContainsKey("penultimate"))
            {
                dictionary["penultimate"] = "Things said too many times at the olympics"; //reassigning the value
            }

            //give me all the keys, give me all the values
            var allTheWords = dictionary.Keys;
            var allTheValues = dictionary.Values; 

            //foreach(var item in dictionary) //each item is a key value pair
            //{
            //    Console.WriteLine($"{item.Key} : {item.Value}");
            //}

            //destructure
            foreach (var (word, def) in dictionary)
            {
                Console.WriteLine($"{word} : {def}");
            }

            //a more complicated dictionary with a list as the value
            var complicatedDictionary = new Dictionary<string, List<string>>();
            complicatedDictionary.Add("Soup", new List<string> { "Hot or cold liquid you eat." });
            var soupDefinitions = complicatedDictionary["Soup"];
            soupDefinitions.Add("This is a definition of soup");

            complicatedDictionary.Add("Arity", new List<string> { "a definition" });

            foreach (var (word, definitions) in complicatedDictionary)
            {
                Console.WriteLine(word);
                foreach (var def in definitions)
                {
                    Console.WriteLine($"\t{def}");
                }
            }

            //Hashset<T>
            //Like a list in that they store a value at an index
            //like a dictionary in that the value has to be unique
            //different in that it eliminates non-unique stuff without errors
            //pretty slow at adding data
            //super fast at getting data out, comparing data

            var jamekasName = "Jameka";

            jamekasName.GetHashCode();

            var uniqueNames = new HashSet<string>();
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Dylan");
            uniqueNames.Add("Dylan");
            uniqueNames.Add("Dylan");
            uniqueNames.Add("Dylan");
            uniqueNames.Add("Dylan");
            uniqueNames.Add("Nathan");

            uniqueNames.Remove("Dylan");
            //this hashset will have only two things inside it

            foreach(var name in uniqueNames)
            {
                Console.WriteLine($"{name} is unique");
            }

            //Queue<T>
            //FIFO - first in first out
            //for things that have to be done in order


            var queue = new Queue<int>();

            queue.Enqueue(3);
            queue.Enqueue(7);
            queue.Enqueue(12);
            queue.Enqueue(1);
            queue.Enqueue(400);

            //adds to the end of the line every time


            //these are not really interable

            while(queue.Count > 0)
            {
                Console.WriteLine($"dequeueing {queue.Dequeue()}");
            }

            //Stack<T>
            //LIFO - last in first out
            //in order; bias toward recency
            //take the first thing off the stack

            var stack = new Stack<int>();
            stack.Push(2);
            stack.Push(7);
            stack.Push(4);
            stack.Push(8);
            stack.Push(0);

            while(stack.Count > 0)
            {
                Console.WriteLine($"poping {stack.Pop()}");
            }
        }
    }
}
