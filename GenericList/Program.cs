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
          
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            int[] toArr = ints.ToArray();

            GenericList<int> myList = new GenericList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            myList.TrimExcess();

            Console.WriteLine();


            Console.ReadLine();


        }
    }
}
