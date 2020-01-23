using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList<T>
    {
        T[] items;
        public int Count { get; private set; }
        public int Capacity { get; set; }


        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public void Add(T item)
        {
                                 
        }

        public bool Remove(T item)
        {

            return false;
        }

    }
}
