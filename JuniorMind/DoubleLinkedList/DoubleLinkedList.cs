using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class DoublyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> sentinel;
        private int count;

        public DoublyLinkedList()
        {
            sentinel = new Node<T>(default(T));
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            count = 0;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T item)
        {       
            Node<T> node = new Node<T>(item);
            node.Previous = sentinel;
            node.Next = sentinel.Next;            
            sentinel.Next.Previous = node;
            sentinel.Next = node;
       
            count++;              
        }
      
        public void AddLast(T item)
        {                 
            Node<T> node = new Node<T>(item);
            node.Next = sentinel;
            node.Previous = sentinel.Previous;
            sentinel.Previous.Next = node;
            sentinel.Previous = node;
        
            count++;
        }

        public bool Remove(T item)
        {
            for(Node<T> i = sentinel.Next; i != sentinel; i = i.Next)
                if(i.Data.Equals(item))
                {
                    i.Previous.Next = i.Next;
                    i.Next.Previous = i.Previous;
                    count--;
                    return true;
                }
            return false;
        }

        public void RemoveFirst()
        {
            if (sentinel.Next == sentinel)
                throw new InvalidOperationException();
            sentinel.Next = sentinel.Next.Next;
            sentinel.Next.Previous = sentinel;
            count--;
        }

        public void RemoveLast()
        {
            if (sentinel.Previous == sentinel)
                throw new InvalidOperationException();
            sentinel.Previous = sentinel.Previous.Previous;
            sentinel.Previous.Next = sentinel;
            count--;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            for (Node<T> i = sentinel.Next; i != sentinel; i = i.Next)
                if (i.Data.Equals(item))
                    return true;
            return false;
        }

        public Node<T> Find(T item)
        {
            Node<T> foundNode = null;
            for (Node<T> i = sentinel.Next; i != sentinel; i = i.Next)
                if (i.Data.Equals(item))
                {
                    foundNode = i;
                    break;
                }
            return foundNode;
        }

        public void CopyTo(T[] destinationArray, int startIndex)
        {
            if (destinationArray == null)
                throw new ArgumentNullException();
            if (startIndex < 0)
                throw new IndexOutOfRangeException();
            if (count > destinationArray.Length - startIndex)
                throw new ArgumentNullException();

            int index = startIndex;              
            for (Node<T> i = sentinel.Next; i != sentinel; i = i.Next)
            {
                destinationArray[index] = i.Data;
                index++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = sentinel;
            if (current != null)
            {
                do
                {
                    yield return current.Data;
                    current = current.Next;
                } while (current != sentinel);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
