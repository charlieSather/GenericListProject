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
        public GenericList()
        {
            items = new T[0];
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return items[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
               
        public void Add(T item)
        {
            if (Capacity == 0)
            {
                items = new T[4];
                Capacity = 4;
                items[0] = item;
                Count++;
            }
            else if (Capacity == Count)
            {
                Capacity *= 2;
                T[] newList = new T[Capacity];

                for (int i = 0; i < Count; i++)
                {
                    newList[i] = items[i];
                }

                items = newList;
                items[Count] = item;
                Count++;
            }
            else
            {
                items[Count] = item;
                Count++;
            }
        }

        public bool Remove(T item)
        {
            //if T not same as GenericList<T> throw Exception immediately
            bool removedItem = false;

            if (Count < 1)
            {
                return removedItem;
            }


            for (int i = 0; i < Count; i++)
            {
                //Equals() fails on most reference types, users need to override Equals() method accordingly or use a workaround 
                if (items[i].Equals(item))
                {

                    if(i != Count - 1)
                    {
                       T[] newList = new T[Capacity];

                        for(int j = 0; j < Count - 1; j++)
                        {
                            if (j >= i)
                            {
                                newList[j] = items[j + 1];
                            }
                            else
                            {
                                newList[j] = items[j];
                            }
                        }
                        items = newList;
                        Count--;
                    }
                    else
                    {
                        T[] newList = new T[Capacity];

                        for (int j = 0; j < Count - 1; j++)
                        {                           
                            newList[j] = items[j];
                        }
                        items = newList;
                        Count--;
                    }
                    removedItem = true;
                    break;
                }
            }
            return removedItem;
        }

        public static GenericList<T> operator +(GenericList<T> listOne, GenericList<T> listTwo)
        {
            return new GenericList<T>();
        }

        public static GenericList<T> operator -(GenericList<T> listOne, GenericList<T> listTwo)
        {
            return new GenericList<T>();
        }

        public GenericList<T> Zip(GenericList<T> list)
        {
            return new GenericList<T>();
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for(int i = 0; i < Count; i++)
            {
                str.Append(items[i].ToString());
            }

            return str.ToString();
        }


    }
}
