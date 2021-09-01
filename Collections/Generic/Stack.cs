using System;
using System.Collections;
using System.Collections.Generic;
using DataStructure.Models;

namespace DataStructure
{
    public class Stack<T> : ICollection, IEnumerable<T>
    {
        /// <summary>
        /// Top node of stack.
        /// </summary>
        public OneWayListNode<T>? TopNode => _topNode;

        /// <summary>
        /// Number of stack.
        /// </summary>
        public int Count => _count;


        private OneWayListNode<T>? _topNode;

        private OneWayListNode<T>? _bottomNode;

        private int _count;
        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();


        public void Push(T data)
        {
            _count++;
            _bottomNode ??= _topNode = new OneWayListNode<T>(data, linkTo: _topNode);
        }


        public T? Pop()
        {
            if (_topNode is null) throw new IndexOutOfRangeException();

            _count--;

            var data = _topNode.Data;

            _topNode = _topNode.Adjacent;

            return data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void CopyTo(Array array, int index)
        {
            if (_bottomNode is null) return;
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (index < Count) throw new ArgumentOutOfRangeException(nameof(index));

            var indexOfStack = 0;
            var indexOfArray = 0;

            for (var pointer = _bottomNode; pointer!.HasAdjacent(); pointer = pointer.Adjacent)
            {
                if (indexOfStack >= index)
                {
                    array.SetValue(pointer.Data, indexOfArray++);
                    indexOfStack++;
                }
            }
        }
    }
}
