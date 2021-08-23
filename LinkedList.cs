using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class LinkedList<T> : IEnumerable<T>, ICollection<T>, ICollection
    {
        public int Count => _count;
        private int _count;

#nullable enable
        private DataNode<T>? _head;
        private DataNode<T>? _tail;
#nullable disable

        public bool IsReadOnly => false;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        /// <summary>
        /// Insert a new node at the end of LinkedList.
        /// </summary>
        /// <param name="val">value</param>
        public void Add(T val) =>
            _head ??= (_tail = new(val, _tail));

        public void Clear()
        {
            _head = _tail = null;
            _count = 0;
        }

        public bool Contains(T val)
        {
            for (var pointer = _head; pointer.HasNext(); pointer = pointer.Next)
                if (pointer.Data.Equals(val))
                    return true;

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var counter = 0;
            var index = 0;

            for (var pointer = _head; pointer.HasNext(); pointer = pointer.Next)
            {
                if (counter < arrayIndex)
                {
                    array[index++] = pointer.Data;
                }

                counter++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
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
