namespace DataStructure.Models
{
    public class TwoWayListNode<T> : IDataNode<T>
    {
        /// <summary>
        /// New a DataNode with value data and previous node.
        /// </summary>
        /// <remarks>
        /// If prev is not null, this method will link prev node with this new node.
        /// </remarks>
        /// <param name="data">value</param>
        /// <param name="prev">previous node</param>
        public TwoWayListNode(T? data, TwoWayListNode<T>? prev = null, TwoWayListNode<T>? next = null)
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

        public T? Data { get; set; }

        public TwoWayListNode<T>? Next { get; set; }
        public TwoWayListNode<T>? Prev { get; set; }
        public bool HasNext() => !(Next is null);
        public bool HasPrev() => !(Prev is null);

    }
}
