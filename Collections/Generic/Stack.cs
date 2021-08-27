using System;
using System.Collections;
using System.Collections.Generic;
using DataStructure.Models;

namespace DataStructure
{
    public class Stack<T> : ICollection, IEnumerable<T>
    {
        public OneWayNode<T>? TopNode => _topNode;
        public int Count => _count;
        private OneWayNode<T>? _topNode;
        private int _count;
        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Push(T data)
        {
            _count++;
            _topNode = new OneWayNode<T>(data, linkTo: _topNode);
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
            throw new NotImplementedException();
        }
    }
}
