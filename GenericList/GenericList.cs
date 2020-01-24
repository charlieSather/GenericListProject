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

                    if (i != Count - 1)
                    {
                        T[] newList = new T[Capacity];

                        for (int j = 0; j < Count - 1; j++)
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
            GenericList<T> newList = new GenericList<T>();

            if (listTwo.Count > 0)
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    newList.Add(listOne[i]);
                }
                for (int i = 0; i < listTwo.Count; i++)
                {
                    newList.Add(listTwo[i]);
                }
                return newList;
            }
            else
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    newList.Add(listOne[i]);
                }
                return newList;
            }
        }

        public static GenericList<T> operator -(GenericList<T> listOne, GenericList<T> listTwo)
        {
            GenericList<T> newList = MakeCopy(listOne);

            if (listTwo.Count > 0)
            {
                for (int i = 0; i < listTwo.Count; i++)
                {
                    int count = 0;
                    while (count < newList.Count)
                    {
                        if (newList[count].Equals(listTwo[i]))
                        {
                            newList.Remove(listTwo[i]);
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                return newList;
            }
            else
            {
                return newList;
            }
        }

        public GenericList<T> Zip(GenericList<T> list)
        {
            GenericList<T> newList = new GenericList<T>();

            if (list.Count > 0)
            {
                if (Count < list.Count)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i < Count)
                        {
                            newList.Add(this[i]);
                        }
                        newList.Add(list[i]);
                    }
                }
                else if (Count > list.Count)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        newList.Add(this[i]);
                        if (i < list.Count)
                        {
                            newList.Add(list[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Count; i++)
                    {
                        newList.Add(this[i]);
                        newList.Add(list[i]);
                    }
                }
            }
            else
            {
                newList = MakeCopy(this);
            }

            return newList;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                str.Append(items[i].ToString());
            }

            return str.ToString();
        }

        public static GenericList<T> MakeCopy(GenericList<T> list)
        {
            GenericList<T> myCopy = new GenericList<T>();

            for (int i = 0; i < list.Count; i++)
            {
                myCopy.Add(list[i]);
            }

            return myCopy;
        }

        public void QuickSort()
        {
            if (Count < 1)
            {
                return;
            }

            if (this[0].GetType().Equals(1.GetType()))
            {
                for (int i = 0; i < Count - 1; i++)
                {
                    for (int j = i + 1; j < Count; j++)
                    {                        
                        if ( (int) (object) items[j] < (int)(object) items[i])
                        {
                            T temp = items[i];
                            items[i] = items[j];
                            items[j] = temp;
                        }
                    }
                }

            }
            else if (this[0].GetType().Equals("".GetType()))
            {
                for (int i = 0; i < Count - 1; i++)
                {
                    for (int j = i + 1; j < Count; j++)
                    {
                        if (((string)(object)items[j]).CompareTo((string)(object)items[i]) < 0)
                        {
                            T temp = items[i];
                            items[i] = items[j];
                            items[j] = temp;
                        }
                    }
                }

            }
            else
            {
                //Sort for type not supported.
            }
        }

        public bool Contains(T item)
        {
            bool itemFound = false;

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    itemFound = true;
                    break;
                }
            }
            return itemFound;
        }

        public int GetIndexAt(T item)
        {
            int indexFound = -1;

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    indexFound = i;
                    break;
                }

            }

            return indexFound;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                this.Add(item);
            }
        }
    }
}
