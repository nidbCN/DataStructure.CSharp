using System;

namespace DataStructure
{
    public class Stack<T>
    {
        private DataNode<T> node;
        public uint Count { get; set; }

        public void Push(T data)
        {
            Count++;
            node = new DataNode<T>(data, node);
        }

        public T Pop()
        {
            if (!node.HasPrev()) throw new IndexOutOfRangeException();

            Count--;
            return (node = node.Prev).Data;
        }
    }
}
