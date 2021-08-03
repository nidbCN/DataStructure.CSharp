namespace DataStructure
{
    internal class DataNode<T>
    {
        public DataNode(T data) : this(data, null)
        {

        }

        public DataNode(T data, DataNode<T> prev)
        {
            Data = data;
            Prev = prev;
        }

        public DataNode<T> Next { get; set; }
        public DataNode<T> Prev { get; set; }
        public bool HasNext() => !(Next is null);
        public bool HasPrev() => !(Prev is null);
        public T Data { get; set; }
    }
}
