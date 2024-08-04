using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;

namespace TRW.GameLibraries.Character
{
    public class CharacterPropertyCollection<T>: IEnumerable<T>
        where T:CharacterPropertyBase
    {
        #region Fields
        private FilterableCollection<T> _collection = new FilterableCollection<T>();
        private HashSet<string> _categories = new HashSet<string>();
        #endregion

        #region Constructors
        public CharacterPropertyCollection(ICollection<T> baseCollection)
        {
            foreach (T item in baseCollection)
            {
                _categories.Add(item.Category);
                _collection.Add(item.Clone() as T);
            }


        }
        #endregion

        #region Properties
        public HashSet<string> Categories
        {
            get { return _categories; }
        }
        #endregion

        #region Publics
        public List<T> Filter(params string[] category)
        {
            List<T> filtered = new List<T>();

            _collection.Filter(t => category.Contains(t.Item.Category));

            foreach(T filteredItem in _collection)
            {
                filtered.Add(filteredItem.Clone() as T);
            }

            _collection.ClearFilter();

            return filtered;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_collection).GetEnumerator();
        }

        public void Remove(T item)
        {
            _collection.Remove(item);
        }
        #endregion
    }
}
