﻿using LinkedList;
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

        private int Count
        {
            get
            {
                return count;
            }
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

        public void Add(T item)
        {
            AddLast(item);
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