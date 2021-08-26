using System.Collections;

namespace DataStructure
{

    public class LinkedList<T> : IEnumerable<T>, ICollection<T>, ICollection
    {
        public int Count => _count;

        public DataNode<T>? Head => _head;
        public DataNode<T>? Tail => _tail;

        private int _count;
        private DataNode<T>? _head;
        private DataNode<T>? _tail;

        public bool IsReadOnly => false;

        // TODO: Implemente sysnc method.
        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        /// <summary>
        /// Insert a new node at the end of LinkedList.
        /// </summary>
        /// <param name="val">value</param>
        public void Add(T val)
            => _head ??= (_tail = new(val, next: _tail));

        /// <summary>
        /// Insert a new node at the head of LinkedList.
        /// </summary>
        /// <param name="val">value</param>
        public void AddFirst(T val)
            => _tail ??= (_head = new(val, next: _head));

        public void Clear()
        {
            _head = _tail = null;
            _count = 0;
        }

        public bool Contains(T val)
            => Find(x => x?.Equals(val) ?? false) is not null;

        public void CopyTo(T[] array, int arrayIndex)
        {
            var indexOfList = 0;
            var indexOfArray = 0;

            for (var pointer = _head; pointer!.HasNext(); pointer = pointer.Next)
            {
                if (indexOfList < arrayIndex)
                    array[indexOfArray++] = pointer.Data;

                indexOfList++;
            }
        }

        public DataNode<T>? Find(T? item)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            var indexOfList = 0;
            var indexOfArray = 0;

            for (var pointer = _head; pointer!.HasNext(); pointer = pointer.Next)
            {
                if (indexOfList < index)
                    array.SetValue(pointer.Data, indexOfArray);

                indexOfList++;
            }
        }

        public int IndexOf(T item)
            => IndexOf(x => x?.Equals(item) ?? false);

        public int IndexOf(Predicate<T> match)
        {
            var ret = -1;
            if (_head is null) return ret;

            (_, ret) = FindNode(x => match.Invoke(x.Data));

            return ret;
        }

        public T? Find(Predicate<T> match)
        {
            if (match is null) throw new ArgumentNullException(nameof(match));
            if (_head is null) return default;

            (var ret, _) = FindNode(x => match(x.Data));

            return ret is null ? default : ret.Data;
        }

        private (DataNode<T>?, int) FindNode(Predicate<DataNode<T>> match)
        {
            var indexOfList = 0;

            for (var pointer = _head; pointer!.HasNext(); pointer = pointer.Next)
            { 
                if (match.Invoke(pointer))
                    return (pointer, indexOfList++);
            }

            return (null, -1);
        }
    }

}
