using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public class MyCollection<T> : IEnumerable<T>, ICollection<T> where T : ICloneable, new()
    {
        private MyHashTable<T> _hashTable;

        public MyCollection()
        {
            _hashTable = new MyHashTable<T>();
        }

        public MyCollection(int capacity)
        {
            _hashTable = new MyHashTable<T>(capacity);
        }

        public MyCollection(MyCollection<T> collection)
        {
            _hashTable = new MyHashTable<T>(collection._hashTable.Capacity);
            foreach (var item in collection)
            {
                _hashTable.AddPoint((T)item.Clone());
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var item in this)
                {
                    count++;
                }
                return count;
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _hashTable.AddPoint(item);
        }

        public void Clear()
        {
            _hashTable = new MyHashTable<T>(_hashTable.Capacity);
        }

        public bool Contains(T item)
        {
            return _hashTable.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public bool Remove(T item)
        {
            return _hashTable.RemoveData(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _hashTable.Capacity; i++)
            {
                Point<T>? current = _hashTable.table[i];
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyCollection<T> DeepClone()
        {
            return new MyCollection<T>(this);
        }

        public MyCollection<T> ShallowCopy()
        {
            return new MyCollection<T>(_hashTable.Capacity)
            {
                _hashTable = this._hashTable
            };
        }

        public void PrintCollection()
        {
            _hashTable.PrintTable();
        }
    }
}