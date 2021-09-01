namespace DataStructure.Models
{
    public class BinaryTreeNode<T> : IDataNode<T>
    {
        public T? Data { get; set; }

        public BinaryTreeNode<T>? LeftChild { get; set; }
        public BinaryTreeNode<T>? RightChild { get; set; }

        public bool HasLeftChild() => !(LeftChild is null);
        public bool HasRightChild() => !(RightChild is null);

        public BinaryTreeNode()
        {

        }

        public BinaryTreeNode(T? data, BinaryTreeNode<T>? leftChild = null, BinaryTreeNode<T>? rightChild = null)
        {
            Data = data;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
