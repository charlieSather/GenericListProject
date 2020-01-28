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

            GenericList<int> myList = new GenericList<int> { 10, 15, 5, 8, 2, 3, 11, 9, 1, 0, 1 };

            myList.Sort(2, 10, Comparer<int>.Default);

            Console.WriteLine();


            Console.ReadLine();


        }
    }
}
