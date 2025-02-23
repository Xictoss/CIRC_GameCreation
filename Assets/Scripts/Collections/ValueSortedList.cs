using System.Collections.Generic;
using System.Linq;

namespace CIRC.Collections
{
    public class ValueSortedList<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>> _list = new List<KeyValuePair<TKey, TValue>>();
        public List<KeyValuePair<TKey, TValue>> List => _list;
        
        public bool TryAdd(TKey key, TValue value)
        {
            if (!ContainsKey(key))
            {
                _list.Add(new KeyValuePair<TKey, TValue>(key, value));
                _list.OrderByDescending(kvp => kvp.Value);
                return true;
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            return _list.Exists(kvp => kvp.Key.Equals(key));
        }

        public bool TryRemove(TKey key)
        {
            int index = _list.FindIndex(kvp => kvp.Key.Equals(key));
            if (index >= 0)
            {
                _list.RemoveAt(index);
                return true;
            }

            return false;
        }
        
        public TValue GetValue(TKey key)
        {
            int index = _list.FindIndex(kvp => kvp.Key.Equals(key));
            if (index == -1)
            {
                throw new KeyNotFoundException("The key was not found in the collection.");
            }

            return _list[index].Value;
        }

        public TValue[] GetValues()
        {
            return _list.Select(kvp => kvp.Value).ToArray();
        }

        public TKey[] GetKeys()
        {
            return _list.Select(kvp => kvp.Key).ToArray();
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}