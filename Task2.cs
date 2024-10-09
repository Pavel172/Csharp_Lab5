using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    public class MyList<T> : IEnumerable<T>
    {
        public T[] list { get; set; }
        public int count { get; set; }
        
        public MyList() 
        {
            T[] list = Array.Empty<T>();
            count = 0;
        }

        public MyList(params T[] parameters)
        {
            count = parameters.Length;
            list = new T[parameters.Length];
            for (int i = 0; i < parameters.Length; ++i) 
            {
                list[i] = parameters[i];
            }
        }

        public MyList(MyList<T> another_list) 
        {
            list = new T[another_list.count];
            count = another_list.count;
            for (int i = 0; i < another_list.count; ++i)
            {
                list[i] = another_list[i];
            }
        }

        public MyList(MyList<T> another_list, params T[] parameters)
        {
            list = new T[another_list.count + parameters.Length];
            count = another_list.count + parameters.Length;
            int j = 0;
            for (int i = 0; i < another_list.count; ++i)
            {
                list[i] = another_list[i];
            }
            for(int i = another_list.count; i < count; ++i) 
            { 
                list[i] = parameters[j];
                ++j;
            }
        }

        public MyList(int count)
        {
            this.count = count;
            list = new T[count];
        }

        public T this[int index] 
        {
            get 
            {
                return list[index];
            }

            set 
            {
                list[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator() 
        {
            for(int i = 0; i < count; ++i) 
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public void Add(T item) 
        {
            ++count;
            T[] new_list = new T[count];
            if (count == 1)
            {
                new_list[0] = item;
                list = new_list;
            }
            if(count > 1) 
            {
                for (int i = 0; i < count-1; ++i)
                {
                    new_list[i] = list[i];
                }
                new_list[count - 1] = item;
                list = new_list;
            }
        }

        public void print() 
        {
            for(int i = 0; i < count; ++i) Console.WriteLine(list[i]);
        }

    }



    public class Task2
    {
        static void Main()
        {
            MyList<int> list1 = new MyList<int>() { 2, 3, 4};
            MyList<int> list2 = new MyList<int> { 1, 2 };
            MyList<int> list3 = new MyList<int>(list2, 2, 3, 4);
            MyList<int> list4 = new MyList<int>(list2) { 1,2,3 };
            list4.Add(5);
            Console.WriteLine(list4.count);
            Console.WriteLine("---------------------------------------------");
            list4.print();
        }
    }
}