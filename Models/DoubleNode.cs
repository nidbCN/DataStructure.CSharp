namespace DataStructure.Models
{
    public class DoubleNode<T> : IDataNode<T>
    {
        /// <summary>
        /// New a DataNode with value data.
        /// </summary>
        /// <param name="data">value</param>
        public DoubleNode(T data) : this(data, null) { }

        /// <summary>
        /// New a DataNode with value data and previous node.
        /// </summary>
        /// <remarks>
        /// If prev is not null, this method will link prev node with this new node.
        /// </remarks>
        /// <param name="data">value</param>
        /// <param name="prev">previous node</param>
        public DoubleNode(T data, DoubleNode<T>? prev = null, DoubleNode<T>? next = null)
        {
            Data = data;

            if (prev is not null)
            {
                Prev = prev;
                prev.Next = this;
            }

            if (next is not null)
            {
                Next = next;
                next.Prev = this;
            }
        }

        public T Data { get; set; }

        public DoubleNode<T>? Next { get; set; }
        public DoubleNode<T>? Prev { get; set; }
        public bool HasNext() => !(Next is null);
        public bool HasPrev() => !(Prev is null);

    }
}
