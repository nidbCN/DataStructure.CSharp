using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class OneWayNode<T> : IDataNode<T>
    {
        public T Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public OneWayNode<T>? Adjacent { get; set; }

        public OneWayNode()
        {

        }
    }
}
