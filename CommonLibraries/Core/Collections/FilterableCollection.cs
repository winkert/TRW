using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace TRW.CommonLibraries.Core
{
    public class FilterableCollection<T> : ICollection<T>, IEnumerable<T> where T : IComparable<T>
    {
        #region Fields
        private List<FilterableItem<T>> _items;
        internal protected Func<FilterableItem<T>, bool> ActiveFilter { get; private set; }
        #endregion

        public FilterableCollection()
        {
            _items = new List<FilterableItem<T>>();
            ActiveFilter = null;
        }

        #region Properties
        public int Count => _items.Where(f => !f.Filtered).Count();
        public int FilteredCount => _items.Where(f => f.Filtered).Count();

        public bool IsReadOnly => false;

        public bool Filtered => ActiveFilter != null;

        public T this[int index]
        {
            get
            {
                if(index < 0 || index >= _items.Count)
                    throw new ArgumentOutOfRangeException("index");

                return _items[index].Item;
            }
            set
            {
                if (index < 0 || index >= _items.Count)
                    throw new ArgumentOutOfRangeException("index");

                _items[index].Item = value;
                if (Filtered && !ActiveFilter(value))
                    _items[index].Filtered = true;
            }
        }

        #endregion

        #region Publics
        public void Add(T item)
        {
            FilterableItem<T> newItem = new FilterableItem<T>(item, _items.Count);
            if (Filtered && !ActiveFilter(item))
                newItem.Filtered = true;

            _items.Add(newItem);
        }

        public void AddRange(T[] items)
        {
            foreach (T item in items)
                Add(item);

        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(new FilterableItem<T>(item));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)_items).CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (FilterableItem<T> item in _items)
            {
                if (!item.Filtered)
                    yield return item.Item;
            }
        }

        public bool Remove(T item)
        {
            bool result = ((ICollection<T>)_items).Remove(item);
            if (Filtered)
            {
                RefreshFilter();
            }

            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Add a filter to collection
        /// </summary>
        /// <param name="expr">Lambda expression to filter the collection. e.g. t => t.Id > 1</param>
        public void Filter(Func<FilterableItem<T>, bool> expr)
        {
            ActiveFilter = expr;
            RefreshFilter();
        }

        public void ClearFilter()
        {
            ActiveFilter = null;
            RefreshFilter();
        }

        public void Refresh()
        {
            RefreshFilter();
        }
        #endregion

        #region Privates
        private void RefreshFilter()
        {
            if (Filtered)
            {
                _items.ForEach(i => i.Filtered = !ActiveFilter(i));
            }
            else
            {
                _items.ForEach(i => i.Filtered = false);
            }
        }

        #endregion
    }

    public class FilterableItem<T> where T : IComparable<T>
    {
        public FilterableItem(T item)
        {
            Item = item;
            Filtered = false;
            ItemIndex = -1;
        }
        internal FilterableItem(T item, long itemIndex)
        {
            Item = item;
            Filtered = false;
            ItemIndex = itemIndex;
        }

        /// <summary>
        /// Item is filtered out of view
        /// </summary>
        internal bool Filtered { get; set; }
        public T Item { get; set; }
        internal long ItemIndex { get; set; }

        public int CompareTo(T other)
        {
            return Item.CompareTo(other);
        }

        public override bool Equals(object obj)
        {
            return obj is FilterableItem<T> item &&
                   EqualityComparer<T>.Default.Equals(Item, item.Item);
        }

        public override int GetHashCode()
        {
            return -979861770 + EqualityComparer<T>.Default.GetHashCode(Item);
        }

        public static bool operator ==(FilterableItem<T> left, T right) => left.CompareTo(right) == 0;
        public static bool operator !=(FilterableItem<T> left, T right) => left.CompareTo(right) != 0;
        public static bool operator >(FilterableItem<T> left, T right) => left.CompareTo(right) > 0;
        public static bool operator <(FilterableItem<T> left, T right) => left.CompareTo(right) < 0;

        public static implicit operator T(FilterableItem<T> item) => item.Item;
        public static implicit operator FilterableItem<T>(T item) => new FilterableItem<T>(item);
    }

}
