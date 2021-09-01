namespace DataStructure.Models
{
    public class OneWayListNode<T> : IDataNode<T>
    {
        public OneWayListNode(T? data, OneWayListNode<T>? linkTo = null, OneWayListNode<T>? linkFor = null)
        {
            Data = data;

            if (linkTo is not null)
            {
                Adjacent = linkTo;
            }

            if (linkFor is not null)
            {
                linkFor.Adjacent = this;
            }
        }

        public T? Data { get; set; }

        public OneWayListNode<T>? Adjacent { get; set; }
        public bool HasAdjacent() => !(Adjacent is null);
    }
}
