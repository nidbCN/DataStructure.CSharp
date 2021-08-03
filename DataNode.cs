namespace DataStructure
{
    internal class DataNode<T>
    {
        DataNode<T> Next { get; set; }
        DataNode<T> Prev { get; set; }

        T Data { get; set; }
    }
}
