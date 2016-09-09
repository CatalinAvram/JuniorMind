using LinkedList;

namespace LinkedList
{
    class Node<T>
    {
        private T data;
        private Node<T> next;
        private Node<T> previous;

        public Node(T data)
        {
            this.data = data;
        }

        public T Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Node<T> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }
    }
}