using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice10
{
    class Program
    {
        /// <summary>
        /// 14.	Задание 533в из книги 
        /// Абрамов С.А., Гнездилова Г.Г., Капустина Е.Н., Селюн М.И. Задачи по программированию. М.: Наука, 1988.
        /// На входе: n, X1, X2, ..., Xn
        /// На выход: (X1 + X2 + 2*Xn)(X2 + X3 + 2*Xn-1)...(Xn-1 + Xn + 2*X2)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Point test, mark;
            Random r = new Random();
            int N, temp, sum = 1;
            

            #region Ввод
            Console.WriteLine("Введите количество элементов");
            N = int.Parse(Console.ReadLine());
            while (N < 2)
            {
                Console.WriteLine("Формула не может быть посчитана для данного числа элементов");
                Console.WriteLine("Введите количество элементов");
                N = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("0 - Не случайно");
            Console.WriteLine("Не 0 - Случайное заполнение списка");

            temp = int.Parse(Console.ReadLine());
            if (temp == 0)
            {
                Console.WriteLine("Введите элемент, осталось: {0}", N);
                test = new Point(int.Parse(Console.ReadLine()));
                mark = test;
                N--;
                do
                {
                    Console.WriteLine("Введите элемент, осталось: {0}", N);
                    mark.Next = new Point(int.Parse(Console.ReadLine()), mark);
                    mark = mark.Next;
                    N--;
                } while (N != 0);
            }
            else
            {

                test = new Point(r.Next(-10, 11));
                mark = test;
                N--;
                do
                {
                    mark.Next = new Point(r.Next(-10, 11), mark);
                    mark = mark.Next;
                    N--;
                } while (N != 0);
            }
            mark = test;
            temp = 1;
            Console.Clear();
            while (mark != null)
            {
                Console.WriteLine("{0, 3}: {1, -3}", temp, mark.Info);
                mark = mark.Next;
                temp++;
            }

            #endregion
            mark = test;

            while (mark.Next != null)
                mark = mark.Next;

            test = test.Next;

            while (test != null)
            {
                sum = sum * (test.Previous.Info + test.Info + 2 * mark.Info);
                mark = mark.Previous;
                test = test.Next;
            }
            Console.WriteLine("Результат: {0}", sum);
        }
    }
}
