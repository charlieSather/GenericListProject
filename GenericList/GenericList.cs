﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList<T> : IEnumerable
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
            bool removedItem = false;

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    RemoveAt(i);
                    removedItem = true;
                    break;
                }
            }
            return removedItem;

        }

        public static GenericList<T> operator +(GenericList<T> listOne, GenericList<T> listTwo)
        {
            GenericList<T> newList = new GenericList<T>();

            for (int i = 0; i < listOne.Count; i++)
            {
                newList.Add(listOne[i]);
            }
            for (int i = 0; i < listTwo.count; i++)
            {
                newList.Add(listTwo[i]);
            }
            return newList;
        }

        public static GenericList<T> operator -(GenericList<T> listOne, GenericList<T> listTwo)
        {
            GenericList<T> newList = MakeCopy(listOne);

            for (int i = 0; i < listTwo.Count; i++)
            {
                int counter = 0;
                while (counter < newList.Count)
                {
                    if (newList[counter].Equals(listTwo[i]))
                    {
                        newList.Remove(listTwo[i]);
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            return newList;
        }

        //public static GenericList<T> operator -(GenericList<T> listOne, GenericList<T> listTwo)
        //{
        //    GenericList<T> newList = new GenericList<T>();

        //    foreach (T item in listOne)
        //    {
        //        if (!listTwo.Contains(item))
        //        {
        //            newList.Add(item);
        //        }
        //    }
        //    return newList;
        //}

        //public static GenericList<T> operator -(GenericList<T> listOne, GenericList<T> listTwo)
        //{
        //    GenericList<T> newList = MakeCopy(listOne);

        //    foreach(T item in listTwo)
        //    {
        //        while (newList.Remove(item)) { }
        //    }

        //    return newList;
        //}

        public static GenericList<T> Zip(GenericList<T> listOne, GenericList<T> listTwo)
        {
            GenericList<T> newList = new GenericList<T>();

            if (listOne.Count < listTwo.Count)
            {
                for (int i = 0; i < listTwo.Count; i++)
                {
                    if (i < listOne.Count)
                    {
                        newList.Add(listOne[i]);
                    }
                    newList.Add(listTwo[i]);
                }
            }
            else
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    newList.Add(listOne[i]);
                    if (i < listTwo.Count)
                    {
                        newList.Add(listTwo[i]);
                    }
                }
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
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (Compare(items[j], items[i]) < 0)
                    {
                        T temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        public void Sort()
        {
            MergeSort(items, 0, Count - 1);

        }
        public void Sort(Comparison<T> comparison)
        {
            if (comparison is null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (comparison(items[j], items[i]) < 0)
                    {
                        T temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        public void Sort(int index, int count, IComparer<T> comparer)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index + count > Count)
            {
                throw new ArgumentException();
            }

            for (int i = index; i < index + count - 1; i++)
            {
                for (int j = i + 1; j < index + count; j++)
                {
                    if (comparer.Compare(items[j], items[i]) < 0)
                    {
                        T temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        public void MergeSort(T[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middle = (leftIndex + rightIndex) / 2;
                MergeSort(arr, leftIndex, middle);
                MergeSort(arr, middle + 1, rightIndex);


                Merge(arr, leftIndex, middle, rightIndex);
            }
        }

        public void Merge(T[] arr, int leftIndex, int middleIndex, int rightIndex)
        {
            int i, j, k;

            int sizeLeft = middleIndex - leftIndex + 1;
            int sizeRight = rightIndex - middleIndex;

            T[] tempLeft = new T[sizeLeft];
            T[] tempRight = new T[sizeRight];

            for (i = 0; i < sizeLeft; i++)
            {
                tempLeft[i] = arr[leftIndex + i];
            }
            for (j = 0; j < sizeRight; j++)
            {
                tempRight[j] = arr[middleIndex + 1 + j];
            }

            i = 0; j = 0; k = 0;
            for (k = leftIndex; k < rightIndex + 1; k++)
            {
                if (i == sizeLeft)
                {
                    arr[k] = tempRight[j];
                    j++;
                }
                else if (j == sizeRight)
                {
                    arr[k] = tempLeft[i];
                    i++;
                }
                else if (Compare(tempLeft[i], tempRight[j]) <= 0)
                {
                    arr[k] = tempLeft[i];
                    i++;
                }
                else
                {
                    arr[k] = tempRight[j];
                    j++;
                }
            }
        }

        public int Compare(T itemOne, T itemTwo)
        {
            if (itemOne is int)
            {
                return ((int)(object)itemOne).CompareTo((int)(object)itemTwo);
            }
            else if (itemOne is string)
            {
                return ((string)(object)itemOne).CompareTo((string)(object)itemTwo);
            }
            else if (itemOne is char)
            {
                return ((char)(object)itemOne).CompareTo((char)(object)itemTwo);
            }
            else
            {
                throw new InvalidOperationException();
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

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(T item, int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(T item, int index, int count)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; count > 0; i++)
            {
                if (this[i].Equals(item))
                {
                    return i;
                }
                count--;
            }
            return -1;
        }

        public void AddRange(IEnumerable items)
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

        public void RemoveRange(int index, int count)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int i = index;
            while (i < Count && count > 0)
            {
                this.Remove(items[i]);
                count--;
            }
        }

        public void Clear()
        {
            count = 0;
            Capacity = 4;
            items = new T[Capacity];
        }

        public GenericList<T> GetRange(int index, int count)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            GenericList<T> newList = new GenericList<T>();

            for (int i = index; i < Count && count > 0; i++)
            {
                newList.Add(items[i]);
                count--;
            }

            return newList;

        }
        public GenericList<T> GetRange(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            GenericList<T> newList = new GenericList<T>();

            for (int i = index; i < Count; i++)
            {
                newList.Add(items[i]);
            }

            return newList;

        }

        public T[] CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex] = items[i];
                arrayIndex++;
            }
            return array;
        }

        public T[] CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; count > 0; i++)
            {
                array[arrayIndex] = this[i];
                arrayIndex++;
                count--;
            }
            return array;
        }


        public T[] CopyTo(T[] array)
        {
            for (int i = 0; i < Count; i++)
            {
                array[i] = items[i];
            }
            return array;
        }

        public bool Exists(Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException();
            }

            foreach (T item in this)
            {
                if (match(item))
                {
                    return true;
                }
            }
            return false;
        }


        public T Find(Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException();
            }

            foreach (T item in this)
            {
                if (match(item))
                {
                    return item;
                }
            }
            return default;
        }


        public int FindIndex(Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException();
            }

            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (match(items[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public int FindIndex(int startIndex, Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException();
            }
            if (startIndex >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int index = -1;
            for (int i = startIndex; i < Count; i++)
            {
                if (match(items[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException();
            }
            if (startIndex >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int index = -1;
            for (int i = startIndex; count > 0; i++)
            {
                if (match(this[i]))
                {
                    index = i;
                    break;
                }
                count--;
            }
            return index;
        }

        public void ForEach(Action<T> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException();
            }
            foreach (T item in this)
            {
                action(item);
            }
        }

        public GenericList<K> ConvertAll<K>(Converter<T, K> converter)
        {
            GenericList<K> newList = new GenericList<K>();
            foreach (T item in this)
            {
                newList.Add(converter(item));
            }
            return newList;
        }
        public T FindLast(Predicate<T> match)
        {
            T last = default;

            foreach (T item in this)
            {
                if (match(item))
                {
                    last = item;
                }
            }
            return last;
        }

        public int FindLastIndex(Predicate<T> match)
        {
            int last = -1;

            for (int i = 0; i < Count; i++)
            {
                if (match(items[i]))
                {
                    last = i;
                }
            }
            return last;
        }

        public int FindLastIndex(int startIndex, Predicate<T> match)
        {
            if (startIndex >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int last = -1;

            for (int i = startIndex; i < Count; i++)
            {
                if (match(items[i]))
                {
                    last = i;
                }
            }
            return last;
        }

        public int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int last = -1;

            for (int i = startIndex; count > 0; i++)
            {
                if (match(items[i]))
                {
                    last = i;
                }
                count--;
            }
            return last;
        }

        public void Insert(int index, T item)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == Count)
            {
                Add(item);
                return;
            }
            else if (Count == Capacity)
            {
                capacity *= 2;
            }

            int counter = 0;
            T[] newArray = new T[Capacity];
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    newArray[counter] = item;
                    counter++;
                }
                newArray[counter] = items[i];
                counter++;
            }
            count++;
            items = newArray;
        }

        //TODO
        //Go back and refactor this without using Insert() Method
        public void InsertRange(int index, IEnumerable collection)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (collection is null)
            {
                throw new ArgumentNullException();
            }
            else if (index == Count)
            {
                AddRange(collection);
                return;
            }

            foreach (T item in collection)
            {
                Insert(index, item);
                index++;
            }
        }

        public int RemoveAll(Predicate<T> match)
        {
            int removed = 0;
            int i = 0;

            while (i < Count)
            {
                if (match(this[i]))
                {
                    removed++;
                    Remove(this[i]);
                }
                else
                {
                    i++;
                }
            }
            return removed;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (index == Count - 1)
            {
                items[Count - 1] = default;
            }

            int counter = index;
            for (int i = index + 1; i < Count; i++)
            {
                items[counter] = items[i];
                counter++;
            }
            items[counter] = default;
            count--;
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                arr[i] = items[i];
            }

            return arr;
        }


        //the TrimExcess method does nothing if the list is at more than 90 percent of capacity.
        public void TrimExcess()
        {
            if (((double)Count / (double)Capacity) < 0.9)
            {
                items = ToArray();
                capacity = Count;
            }
        }
        public bool TrueForAll(Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException();
            }

            foreach (T item in this)
            {
                if (!match(item))
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }
    }
}
