namespace DataStructure.Models
{
    public class OneWayNode<T> : IDataNode<T>
    {
        public OneWayNode(T? data, OneWayNode<T>? linkTo = null, OneWayNode<T>? linkFor = null)
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

        public OneWayNode<T>? Adjacent { get; set; }
        public bool HasAdjacent => !(Adjacent is null);
    }
}
