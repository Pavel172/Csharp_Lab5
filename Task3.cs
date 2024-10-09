using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class MyDictionary<TKey, TValue> : IEnumerable
    {
        private int count;
        public TKey[] keys { get; set; }
        public TValue[] values { get; set; }

        public MyDictionary()
        {
            keys = Array.Empty<TKey>();
            values = Array.Empty<TValue>();
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(TKey key, TValue value)
        {
            ++count;
            TKey[] new_keys = new TKey[count];
            TValue[] new_values = new TValue[count];
            if(count == 1)
            {
                new_keys[0] = key;
                new_values[0] = value;
                keys = new_keys;
                values = new_values;
            }
            if(count > 1) 
            {
                for(int i = 0; i < count-1; i++) 
                {
                    new_keys[i] = keys[i];
                    new_values[i] = values[i];
                }
                new_keys[count-1] = key;
                new_values[count - 1] = value;
                keys = new_keys;
                values = new_values;
            }
        }


        public TValue this[TKey index]
        {
            get
            {
                for (int i = 0; i < count; ++i)
                {
                    if (keys[i].Equals(index)) return values[i];
                }
                throw new KeyNotFoundException();
            }
            set { Add(index, value); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerable<TValue> GetEnumerator()
        {
            for(int i = 0; i < count; ++i) 
            {
                yield return values[i];
            }
        }

        public void print() 
        {
            for(int i = 0; i < count; ++i) 
            {
                Console.WriteLine($"key: {keys[i]} value: {values[i]}");
            }   
        }
    }

    public class Task3
    {
        static void Main()
        {
            MyDictionary<int, string> dictionary = new MyDictionary<int, string>();
            dictionary.Add(53, "text1");
            dictionary.Add(45, "text2");
            dictionary.Add(511, "text3");
            dictionary.print();
            int i = 1, j = 1;
            foreach (var item in dictionary.values) 
            {
                Console.WriteLine($"{i} значение: {item}");
                ++i;
            }

            foreach (var item in dictionary.keys)
            {
                Console.WriteLine($"{j} ключ: {item}");
                ++j;
            }
        }
    }
}
