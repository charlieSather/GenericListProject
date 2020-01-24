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
            listOne.Add(2);
            listOne.Add(2);
            listOne.Add(2);
            listOne.Add(1);

            listTwo.Add(2);
            listTwo.Add(3);
            listTwo.Add(4);

            GenericList<int> listThree = listOne - listTwo;



            List<int> one = new List<int> { 1, 2, 3 };
            List<int> two = new List<int> { 4, 5, 6 };


            myList.Remove(10);
            Console.WriteLine(myList);

            strList.Remove("3");

            people.Remove(new Person("2", 4));

            ints.Remove(4);

            ints.Remove(10);

            Console.WriteLine(ints);


        }
    }
}
