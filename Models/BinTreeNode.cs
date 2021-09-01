using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Models
{
    public class BinTreeNode<T> : IDataNode<T>
    {
        public T? Data { get; set; }

        public BinTreeNode<T>? LeftChild { get; set; }
        public BinTreeNode<T>? RightChild { get; set; }

        public bool HasLeftChild => !(LeftChild is null);
        public bool HasRightChild => !(RightChild is null);

        public BinTreeNode()
        {

        }

        public BinTreeNode(T? data, BinTreeNode<T>? leftChild = null, BinTreeNode<T>? rightChild = null)
        {
            Data = data;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
