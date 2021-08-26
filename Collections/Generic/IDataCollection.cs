using System;
using System.Collections;
using System.Collections.Generic;
using DataStructure.Models;

namespace DataStructure.Collections.Generic
{
    public interface IDataCollection<T> : IEnumerable<T>, ICollection<T>, ICollection
    {
        public int IndexOf(T item);
        public int IndexOf(Predicate<T> match);

        public int LastIndexOf(T item);
        public int LastIndexOf(Predicate<T> match);

        //public IDataNode<T> Find(Predicate<T> match);
        //public IDataNode<T> Find(T item);
        //public IDataNode<T> FindLast(Predicate<T> match);
        //public IDataNode<T> FindLast(T item);
    }
}
