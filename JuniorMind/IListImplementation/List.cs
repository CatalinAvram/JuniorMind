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
        private T[] list = new T[0];
        private int count = 0;

        public T this[int index]
        {
            get
            {
                return list[index];
            }

            set
            {
                list[index] = value;
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
            if (count == list.Length)
            {
                Array.Resize(ref list, count + 1);
                list[count] = item;
            }
            else            
                list[count] = item;
            count++;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            foreach(T value in list)
            {
                if(value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (array.Count() - arrayIndex < list.Count())
                throw new ArgumentException();

            for (int i = 0; i < count; ++i)           
                array[i + arrayIndex] = list[i];         
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(T value in list)
            {
                yield return value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
                if (list[i].Equals(item))
                    return i;
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= count )
                throw new ArgumentOutOfRangeException();
            Array.Resize(ref list, count + 1);
            count++;
            for (int i = count - 1; i > index; i--)
                list[i] = list[i - 1];
            list[index] = item;
        }

        public bool Remove(T item)
        {
            if (list.Contains(item))
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException();
            for (int i = index; i < count - 1; i++)
                    list[i] = list[i + 1];
            Array.Resize(ref list, count - 1);
            count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
