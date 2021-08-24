using System.Collections;

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
            var indexOfList = 0;
            var indexOfArray = 0;

            for (var pointer = _head; pointer.HasNext(); pointer = pointer.Next)
            {
                if (indexOfList < arrayIndex)
                    array[indexOfArray++] = pointer.Data;

                indexOfList++;
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
            var indexOfList = 0;
            var indexOfArray = 0;

            for (var pointer = _head; pointer.HasNext(); pointer = pointer.Next)
            {
                if (indexOfList < index)
                    array.SetValue(pointer.Data, indexOfArray);

                indexOfList++;
            }
        }

        public int IndexOf(T item)
        {
            if (item is null) return -1;
            if (_head is null) return -1;

            var indexOfList = 0;

            for (var pointer = _head; pointer.HasNext(); pointer = pointer.Next)
            {
                if (pointer.Data?.Equals(item) ?? false)
                    return indexOfList;

                indexOfList++;
            }

            return -1;
        }

#nullable enable
        public T? Find(Predicate<T> match)
#nullable restore
        {
            if (match is null) throw new ArgumentNullException(nameof(match));
            if (_head is null) return default;


            for (var pointer = _head; pointer.HasNext(); pointer = pointer.Next)
            {
                if (match.Invoke(pointer.Data))
                    return pointer.Data;
            }

            return default;
        }
    }

}
