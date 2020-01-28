using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>();

            GenericList<int> myList = new GenericList<int>();
            GenericList<string> strList = new GenericList<string>();
            GenericList<Person> people = new GenericList<Person>();

            Console.WriteLine(ints);


            for (int i = 0; i < 9; i++)
            {
                myList.Add(i);
                ints.Add(i);
                strList.Add(i.ToString());
                people.Add(new Person(i.ToString(), i * i));
            }

            GenericList<int> listOne = new GenericList<int>();
            GenericList<int> listTwo = new GenericList<int>();

            listOne.Add(2);
            listOne.Add(10);
            listOne.Add(7);
            listOne.Add(5);
            listOne.Add(1);

            listTwo.Add(2);
            listTwo.Add(3);
            listTwo.Add(4);

            listOne.Sort();

            List<string> strings = new List<string> { "Charlie", "Dave", "David", "Chris", "Trevor", "Adam" };
            strings.Sort();

            GenericList<string> myStrings = new GenericList<string>();

            myStrings.Add("Charlie");
            myStrings.Add("Dave");
            myStrings.Add("David");
            myStrings.Add("Chris");
            myStrings.Add("Trevor");
            myStrings.Add("Adam");

            myStrings.QuickSort();


            GenericList<int> listThree = listOne - listTwo;

            GenericList<int> odd = new GenericList<int>();
            GenericList<int> even = new GenericList<int>();
            GenericList<int> empty = new GenericList<int>();


            odd.Add(1);
            odd.Add(3);
            odd.Add(5);

            even.Add(2);

            GenericList<int> result = odd.Zip(even);
            GenericList<int> emptyResult = odd.Zip(empty);


            List<int> one = new List<int> { 1, 2, 3 };
            List<int> two = new List<int> { 4, 5, 6 };


            myList.Remove(10);
            Console.WriteLine(myList);

            strList.Remove("3");

            people.Remove(new Person("2", 4));

            ints.Remove(4);

            ints.Remove(10);

            GenericList<int> lists = new GenericList<int>();
            lists.AddRange(new List<int> { 1, 2, 3, 4, 5, 6, 7 });

            lists.Reverse();

            Console.WriteLine(ints);

            List<int> sortedList = new List<int> { 1, 5, 3, 10, 15, 3, 4, 6 };
            sortedList.Sort();

            Console.WriteLine(sortedList.ToString());

            foreach (int item in sortedList)
            {
                Console.WriteLine(item);
            }

            foreach (int item in lists)
            {
                Console.WriteLine(item);
            }

            GenericList<int> removeTest = new GenericList<int> { 1, 2, 3, 4, 5 };

            removeTest.Remove(5);


            GenericList<string> newList = new GenericList<string> { "dave's", "List", "Can't", "Do", "This" };

            newList.QuickSort();

            GenericList<char> newLists = new GenericList<char> {'n','m','a','b','p','k'};
            newLists.Sort();
            newLists.QuickSort();

            List<int> thisList = sortedList.GetRange(0, sortedList.Count);

            Console.WriteLine(myStrings.FindIndex(x => x == "Charlie"));


            GenericList<int> l = new GenericList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            myList.FindIndex(3, 10, x => x == 12);

            Console.ReadLine();


        }
    }
}
