using DataStructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Collections.Generic
{
    public class MixedList<T> : ICollection<T>, ICollection, IEnumerable<T>, IEnumerable, IList<T>
    {
        private TwoWayListNode<T[]> _headArray = new(new T[2]);
        private TwoWayListNode<T[]> _currentArray = new(new T[2]);
        private int _currentIndexInArray;
        private int _count;

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Add(T item)
        {
            if (_currentIndexInArray >= _currentArray.Data!.Length)
            {
                _currentArray = new (new T[_currentArray.Data!.Length << 1], prev: _currentArray);
                _currentIndexInArray = 0;
            }

            _currentArray!.Data![++_currentIndexInArray] = item;
            _count++;
        }

        public void Clear()
        {
            _headArray = _currentArray = new(new T[2]);
            _currentIndexInArray = 0;
            _count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
