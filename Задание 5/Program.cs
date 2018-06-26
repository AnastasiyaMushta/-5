using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 5");
            Console.ResetColor();
            int n; // Рпзмер матрицы
            int Menu;
            //создание матрицы
            Console.WriteLine("Введите размер матрицы:");
            while (!Int32.TryParse(Console.ReadLine(), out n) || (n < 1) || n > int.MaxValue)
                Console.WriteLine("Введи целое число больше 1, но не выходящие за пределы допустимого значения {0}!", double.MaxValue);
            int[,] matrix = new int[n, n];

            //способ заполнения матрицы
            Console.WriteLine("Выберите действие:\n1 - заполнить матрицу вручную\n2 - заполнить матрицу автоматически");
            while (!Int32.TryParse(Console.ReadLine(), out Menu) || (Menu < 1) || Menu > 2)
                Console.WriteLine("Выбери один из пунктов!");
            switch (Menu)
            {
                case 1:
                    UserNumbers(ref matrix);        //ручное заполнение
                    break;
                case 2:
                    RndNumbers(ref matrix);      //автоматическое заполнение
                    break;
            }
            Print(matrix);
            // Поиск суммы после каждого отрицательного элемента 
            Search(matrix);
            Console.ReadLine();
        }
        /// <summary>
        /// Ручное заполнение
        /// </summary>
        /// <param name="matrix">Матрица</param>
        static void UserNumbers(ref int[,] matrix)
        {
            Console.WriteLine("Для заполнения вводите целые числа от -100 до 100:");
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    Console.WriteLine("m[{0};{1}]", i, j);
                    while (!Int32.TryParse(Console.ReadLine(), out matrix[i, j]) || (matrix[i, j] < -100) || (matrix[i, j] > 100))
                        Console.WriteLine("Вводите элементы от -100 до 100");
                }
            }
        } 
        /// <summary>
        /// Автоматическое заполнение 
        /// </summary>
        /// <param name="matrix">Матрица</param>
        static void RndNumbers(ref int[,] matrix)
        {
            Random r = new Random();
            Console.WriteLine("Автоматическое заполнение матрицы случайными числами от -100 до 100");
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    matrix[i, j] = r.Next(-100, 101);
                    
                }
            }
        }
        /// <summary>
        /// Поиск суммы после каждого отрицательного
        /// </summary>
        /// <param name="matrix">Матрица заполненная </param>
        static void Search(int[,] matrix)
        {
            int[] massum = new int[(int)Math.Sqrt(matrix.Length)]; // массив сумм
            for(int i=0; i<massum.Length; i++) {massum[i] = 100;}
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                bool row = true; //все элементы положительны
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++) //поиск отрицательных элементов строки
                {
                    if (matrix[i, j] < 0)
                    {
                        row = false;
                        massum[i] = Sum(matrix, i, j);
                        break;
                    }
                }

            }
            Print(massum);
        }  
        /// <summary>
        /// Подсчет суммы
        /// </summary>
        /// <param name="matrix">Исходная матрица</param>
        /// <param name="i">Строка в котором содержится отрицательное число</param>
        /// <param name="index_j">Столбец в котором содержится отрицательное число</param>
        /// <returns></returns>
        static int Sum(int[,] matrix,  int i, int index_j)
        {
            int sum=0;
            for(int j = index_j+1; j< Math.Sqrt(matrix.Length); j++)
            {
                sum += matrix[i, j];
            }
            return sum;
        }
        /// <summary>
        /// Печать исходной матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        static void Print(int[,] matrix)
        {
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    Console.Write(String.Format($"{matrix[i, j],4} "));
                }
                Console.WriteLine();
            }
        } 
        /// <summary>
        /// Печать массива сумм
        /// </summary>
        /// <param name="massum">Массив с посчитанными суммами</param>
        static void Print(int[] massum) 
        {
            Console.WriteLine("Посчитанные суммы, после каждого отрицательного элемента в строке,\nесли в строке все элементы положительные, то сумма равна 100:");
            foreach(int s in massum )
            {
                Console.WriteLine(s);
            }
        }
        
    }
}
    
