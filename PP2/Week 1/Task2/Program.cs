using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());// создаю инт и ввожу значение
            string line = Console.ReadLine();//записываю в строку
            string[] arr = line.Split();//из строки записываю в массив
            string[] arr1 = new string[2*n];//создаю новый массив в два раза больше
            for (int j=0;j<arr.Length;j++)//цикл от начала до конца длины массива
            {
                arr1[2 * j] = arr1[2 * j + 1] = arr[j];//записываю два раза элементы 
            }
            for(int j = 0; j < arr1.Length; j++)//цикл от начала до конца длины массива
            {
                Console.Write(arr1[j] + " ");//вывод элементов нового массива
            }
            Console.ReadKey();
        }
    }
}
