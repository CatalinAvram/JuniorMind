using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IListImplementation
{
    class List<T> : IList<T>
    {
        private T[] myList = new T[0];
        private int count = 0;

        public T this[int index]
        {
            get
            {
                return myList[index];
            }

            set
            {
                myList[index] = value;
            }
        }

        public int Count
        {
            get
            {
               return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            Array.Resize(ref myList, count + 1);
            myList[count] = item;
            count++;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            foreach(T value in myList)
            {
                if(value.ToString() == item.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < count; ++i)           
                array[i + arrayIndex] = myList[i];         
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(T value in myList)
            {
                yield return value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
                if (myList[i].Equals(item))
                    return i;
            return -1;
        }

        public void Insert(int index, T item)
        {
            Array.Resize(ref myList, count + 1);
            count++;
            for (int i = count - 1; i > index; i--)
                myList[i] = myList[i - 1];
            myList[index] = item;
        }

        public bool Remove(T item)
        {
            if (myList.Contains(item))
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > count - 1)
                throw new IndexOutOfRangeException();
            for (int i = index; i < count - 1; i++)
                    myList[i] = myList[i + 1];
            Array.Resize(ref myList, count - 1);
            count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
