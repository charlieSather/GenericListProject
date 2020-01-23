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


            for (int i = 0; i < 9; i++)
            {
                myList.Add(i);
                ints.Add(i);
                strList.Add(i.ToString());
            }

            myList.Remove(4);
            myList.Remove(8);

            strList.Remove("3");

            ints.Remove(4);


        }
    }
}
