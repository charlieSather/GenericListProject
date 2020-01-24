using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericCompareTo<T>
    {

        public int CompareTo(T firstItem, T secondItem)
        {
            if (firstItem.Equals(secondItem))
            {
                return 0;
            }
            return 1;
        }


    }
}
