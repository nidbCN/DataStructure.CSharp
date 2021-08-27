using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class OneWayNode<T> : IDataNode<T>
    {
        public OneWayNode(T? data) : this(data, null)
        {

        }

        public OneWayNode(T? data, OneWayNode<T>? node)
        {
            Data = data;

            if (node is not null)
            {
                Adjacent = node;
            }
        }

        public T? Data { get; set; }

        public OneWayNode<T>? Adjacent { get; set; }
        public bool HasAdjacent => !(Adjacent is null);
    }
}
