using System.Collections;

namespace DataStructure
{

    public class LinkedList<T> : IEnumerable<T>, ICollection<T>, ICollection
    {
        /// <summary>
        /// The number of elements contained in the LinkedList<T>.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// The first node of LinkedList.
        /// </summary>
        public DataNode<T>? Head => _head;

        /// <summary>
        /// The last node of LinkedList.
        /// </summary>
        public DataNode<T>? Tail => _tail;


        private int _count;
        private DataNode<T>? _head;
        private DataNode<T>? _tail;


        public bool IsReadOnly => false;

        // TODO: Implemente sysnc method.
        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        void ICollection<T>.Add(T val)
            => AddFirst(val);

        /// <summary>
        /// Insert a new node at the head of LinkedList.
        /// </summary>
        /// <param name="val">value</param>
        public void AddFirst(T val)
            => _tail ??= (_head = new(val, next: _head));

        public void AddLast(T val)
            => _head ??= (_tail = new(val, next: _tail));

        public void Clear()
        {
            _head = _tail = null;
            _count = 0;
        }

        public bool Contains(T val)
            => Find(val) is not null;

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
            => Find(x => EqualityComparer<T>.Default.Equals(item, x));


        public DataNode<T>? Find(Predicate<T> match)
        {
            if (match is null) throw new ArgumentNullException(nameof(match));
            if (_head is null) return default;

            (var result, _) = FindNode(x => match(x.Data));

            return result;
        }

        public DataNode<T>? FindLast(T? item)
            => FindLast(x => EqualityComparer<T>.Default.Equals(item, x));

        public DataNode<T>? FindLast(Predicate<T> match)
        {
            if (match is null) throw new ArgumentNullException(nameof(match));
            if (_tail is null) return default;

            (var result, _) = FindLastNode(x => match(x.Data));

            return result;
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
            => IndexOf(x => EqualityComparer<T>.Default.Equals(item, x));

        public int IndexOf(Predicate<T> match)
        {
            if (match is null) throw new ArgumentNullException(nameof(match));

            var result = -1;

            if (_head is null) return result;

            (_, result) = FindNode(x => match.Invoke(x.Data));

            return result;
        }

        public int LastIndexOf(Predicate<T> match)
        {
            if (match is null) throw new ArgumentNullException(nameof(match));

            var result = -1;

            if (_tail is null) return result;

            (_, result) = FindLastNode(x => match.Invoke(x.Data));

            return result;
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

        private (DataNode<T>?, int) FindLastNode(Predicate<DataNode<T>> match)
        {
            var indexOfList = Count;

            for (var pointer = _tail; pointer!.HasPrev(); pointer = pointer.Prev)
            {
                if (match.Invoke(pointer))
                    return (pointer, --indexOfList);
            }

            return (null, -1);
        }
    }

}
