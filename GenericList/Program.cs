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
            GenericList<string> myList = new GenericList<string> { "Adam", "Steve", "Dave", "Charlie" };

            myList.Insert(2, "Jeff");

            Console.ReadLine();


        }
    }
}
