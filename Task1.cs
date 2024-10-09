using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{

    public class MyMatrix 
    {
        public double[][] matrix { get; set; }

        public MyMatrix(int m, int n, int range_start, int range_end, Random rnd)
        {
            matrix = new double[m][];
            for (int i = 0; i < m; ++i)
            {
                matrix[i] = new double[n];
                for (int j = 0; j < n; ++j)
                {
                    matrix[i][j] = rnd.Next(range_start, range_end);
                }
            }
        }

        public void Fill(int range_start, int range_end, Random rnd) 
        {
            for(int i = 0; i < matrix.Length; ++i) 
            {
                for(int j = 0; j < matrix[i].Length; ++j) 
                {
                    matrix[i][j] = rnd.Next(range_start, range_end);
                }
            }
        }

        public void ChangeSize(int m, int n, int range_start, int range_end, Random rnd) 
        {
            double[][] new_matrix = new double[m][];

            for (int i = 0; i < matrix.Length; ++i)
            {
                if (m < matrix.Length && i == m) break;
                new_matrix[i] = new double[n];

                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    if (n < matrix[i].Length && j == n-1) break;
                    new_matrix[i][j] = matrix[i][j];
                }

                if (n > matrix[i].Length)
                {
                    for (int g = matrix[i].Length; g < n; ++g) new_matrix[i][g] = rnd.Next(range_start, range_end);
                }
            }

            if(m > matrix.Length) 
            {
                for (int h = matrix.Length; h < m; ++h) 
                {
                    new_matrix[h] = new double[n];
                    for (int g = 0; g < n; ++g) new_matrix[h][g] = rnd.Next(range_start, range_end);
                }
            }

            matrix = new_matrix;
        }

        public void ShowPartialy(int m1, int m2, int n1, int n2) 
        {
            for (int i = m1-1; i < m2; ++i) 
            {
                for(int j = n1-1; j < n2; ++j) Console.WriteLine(matrix[i][j]);
                Console.WriteLine();
            }
        }

        public double this[int index1, int index2] 
        {
            get { return matrix[index1][index2]; }
            set { matrix[index1][index2] = value; }
        }

        public void print() 
        {
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    Console.WriteLine(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }

    public class Task1
    {
        static void Main()
        {
            Console.WriteLine("Введите нижний предел диапазона: ");
            string temp1 = Console.ReadLine();
            int range_start = Convert.ToInt32(temp1);
            Console.WriteLine("Введите верхний предел диапазона: ");
            string temp2 = Console.ReadLine();
            int range_end = Convert.ToInt32(temp2);
            Random rnd = new Random();
            MyMatrix Matrix = new MyMatrix(3, 3, range_start, range_end, rnd);
            Matrix.Fill(range_start, range_end, rnd);
            Matrix.ChangeSize(4, 5, range_start, range_end, rnd);
            Matrix.ShowPartialy(2, 3, 2, 4);
            Console.WriteLine(Matrix[0, 2]);
        }
    }
}
