using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList<T> : IEnumerable<T>
    {
        static T[] _items;

        T[] items;

        int count;
        public int Count { get { return count; } }
        int capacity;
        static int _capacity;

        public int Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    capacity = value;
                }
            }
        }
        public GenericList()
        {
            items = new T[0];
        }
        static GenericList()
        {
            _items = new T[0];
            _capacity = 4;
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
            }
            items[Count] = item;
            count++;
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
                        count--;
                    }
                    else
                    {
                        T[] newList = new T[Capacity];

                        for (int j = 0; j < Count - 1; j++)
                        {
                            newList[j] = items[j];
                        }
                        items = newList;
                        count--;
                    }
                    removedItem = true;
                    break;
                }
            }
            return removedItem;
        }


        public bool RemoveTwo(T item)
        {
            int indexFound = -1;
            bool removed = false;
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    indexFound = i;
                    break;
                }
            }
            if (indexFound >= 0)
            {

                T[] temp = new T[Capacity];

                for (int i = 0; i < Count - 1; i++)
                {
                    if (i >= indexFound)
                    {
                        temp[i] = items[i + 1];
                    }
                    else
                    {
                        temp[i] = items[i];
                    }
                }
                items = temp;
                count--;
                removed = true;
            }
            return removed;
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

            if (this[0] is int)
            {
                for (int i = 0; i < Count - 1; i++)
                {
                    for (int j = i + 1; j < Count; j++)
                    {
                        if ((int)(object)items[j] < (int)(object)items[i])
                        {
                            T temp = items[i];
                            items[i] = items[j];
                            items[j] = temp;
                        }
                    }
                }
            }
            else if (this[0] is string)
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
            foreach (T item in items)
            {
                this.Add(item);
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                T temp = items[i];
                items[i] = items[Count - (i + 1)];
                items[Count - (i + 1)] = temp;
            }
        }

        //returns Inumerator without inheriting the interface.

        //public IEnumerator<T> Loop()
        //{
        //    for(int i = 0; i < Count; i++)
        //    {
        //        yield return items[i];
        //    }
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }
        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(items, count);
        }

        class ListEnumerator<T> : IEnumerator<T>
        {
            T[] items;
            int position = -1;
            int count;

            public ListEnumerator(T[] items, int count)
            {
                this.items = items;
                this.count = count;
            }

            public bool MoveNext()
            {
                position++;
                return (position < count);
            }

            public void Reset()
            {
                position = -1;
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return Current;
                }

            }

            public T Current
            {
                get
                {
                    try
                    {
                        return items[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            private object Current1
            {
                get
                {
                    return this.Current;
                }
            }

            object IEnumerator.Current
            {
                get { return Current1; }
            }

            public void Dispose()
            {

            }




        }


    }
}
