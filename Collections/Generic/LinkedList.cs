using System;
using System.Collections;
using System.Collections.Generic;
using DataStructure.Models;

namespace DataStructure.Collections.Generic
{
    public class LinkedList<T> : IEnumerable<T>, ICollection<T>, ICollection, IDataCollection<T>
    {
        #region Properties
        /// <summary>
        /// The number of elements contained in the LinkedList<T>.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// The first node of LinkedList.
        /// </summary>
        public TwoWayListNode<T>? Head => _head;

        /// <summary>
        /// The last node of LinkedList.
        /// </summary>
        public TwoWayListNode<T>? Tail => _tail;
        #endregion

        #region Fields
        private int _count;
        private TwoWayListNode<T>? _head;
        private TwoWayListNode<T>? _tail;
        #endregion

        #region Methods
        public LinkedList()
        {

        }

        public LinkedList(IEnumerable<T> list)
        {
            if (list is null) return;

            foreach (var item in list)
            {
                AddLast(item);
            }
        }

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

            for (var pointer = Head; pointer!.HasNext(); pointer = pointer.Next)
            {
                if (indexOfList >= arrayIndex)
#nullable disable
                    array[indexOfArray++] = pointer!.Data;
#nullable restore
                indexOfList++;
            }
        }

        public TwoWayListNode<T>? Find(T? item)
            => Find(x => EqualityComparer<T>.Default.Equals(item, x));

        public TwoWayListNode<T>? Find(T? item, EqualityComparer<T> comparer)
            => Find(x => comparer.Equals(item, x));

        public TwoWayListNode<T>? Find(Predicate<T> match)
        {
            if (match is null) throw new ArgumentNullException(nameof(match));
            if (_head is null) return default;

#nullable disable
            (var result, _) = FindNode(x => match(x!.Data));
#nullable restore

            return result;
        }

        public TwoWayListNode<T>? FindLast(T? item)
            => FindLast(x => EqualityComparer<T>.Default.Equals(item, x));

        public TwoWayListNode<T>? FindLast(Predicate<T> match)
        {
            if (match is null) throw new ArgumentNullException(nameof(match));
            if (_tail is null) return default;

#nullable disable
            (var result, _) = FindLastNode(x => match(x!.Data));
#nullable restore

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T? item)
            => Remove(Find(item));

        public bool Remove(TwoWayListNode<T>? node)
        {
            if (node is null) return false;

            if (node.HasPrev())
            {
                if (node.HasNext())
                {
                    node.Prev!.Next = node.Next;
                    node.Next!.Prev = node.Prev;
                }
                else
                {
                    _tail = node.Prev;
                    node.Prev!.Next = null;
                    node.Prev = null;
                }
            }
            else
            {
                if (node.HasNext())
                {
                    _head = node.Next;
                    node.Next!.Prev = null;
                    node.Next = null;
                }
                else
                {
                    _head = null;
                    _tail = null;
                }
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            var indexOfList = 0;
            var indexOfArray = 0;

            for (var pointer = Head; pointer!.HasNext(); pointer = pointer.Next)
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

#nullable disable
            (_, result) = FindNode(x => match.Invoke(x!.Data));
#nullable restore
            return result;
        }

        public int LastIndexOf(T item)
            => LastIndexOf(x => EqualityComparer<T>.Default.Equals(item, x));

        public int LastIndexOf(Predicate<T> match)
        {
            if (match is null) throw new ArgumentNullException(nameof(match));

            var result = -1;

            if (_tail is null) return result;
#nullable disable
            (_, result) = FindLastNode(x => match.Invoke(x!.Data));
#nullable restore
            return result;
        }
        #endregion

        #region Private Methods
        private (TwoWayListNode<T>?, int) FindNode(Predicate<TwoWayListNode<T>> match)
        {
            var indexOfList = 0;

            for (var pointer = Head; pointer!.HasNext(); pointer = pointer.Next)
            {
                if (match.Invoke(pointer))
                    return (pointer, indexOfList++);
            }

            return (null, -1);
        }

        private (TwoWayListNode<T>?, int) FindLastNode(Predicate<TwoWayListNode<T>> match)
        {
            var indexOfList = Count;

            for (var pointer = Tail; pointer!.HasPrev(); pointer = pointer.Prev)
            {
                if (match.Invoke(pointer))
                    return (pointer, --indexOfList);
            }

            return (null, -1);
        }
        #endregion
    }

}
