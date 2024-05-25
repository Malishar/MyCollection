using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public class MyHashTable<T> where T : ICloneable, new()
    {
        public Point<T>?[] table;
        public int Capacity => table.Length;

        public MyHashTable(int length = 10)
        {
            table = new Point<T>[length];
        }

        public void AddPoint(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null)
            {
                table[index] = new Point<T>(data);
            }
            else
            {
                Point<T>? current = table[index];
                while (current.Next != null)
                {
                    if (current.Data.Equals(data))
                        return;
                    current = current.Next;
                }
                current.Next = new Point<T>(data);
                current.Next.Pred = current;
            }
        }

        public bool Contains(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null)
                return false;
            Point<T> current = table[index];
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public bool RemoveData(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
            {
                if (table[index].Next == null)
                    table[index] = null;
                else
                {
                    table[index] = table[index].Next;
                    table[index].Pred = null;
                }
                return true;
            }
            else
            {
                Point<T> current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        if (current.Pred != null)
                            current.Pred.Next = current.Next;
                        if (current.Next != null)
                            current.Next.Pred = current.Pred;
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }

        public int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        public void PrintTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.Write($"{i}: ");
                Point<T>? current = table[i];
                while (current != null)
                {
                    Console.Write($"{current.Data} ");
                    current = current.Next;
                }
                Console.WriteLine();
            }
        }
    }
}