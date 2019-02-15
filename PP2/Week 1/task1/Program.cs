using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine()); //ввожу число в виде строки и сразу переводим в int 
            string line = Console.ReadLine(); //ввожу строку, состоящую из чисел
            string[] arr = line.Split();//убираю пробелы и записываем числа в массив
            int[] arr1 = new int[a];//создаю массив
            int g = 0;//создаю переменную типа int и присваиваю значение 0
            foreach (var o in arr)//прохожу по каждому элементу массива
            {
                int t = int.Parse(o);//перевожу элемент массива в int
                int k=0;//создаю переменную типа int и присваиваю значение 0
                for (int i = 2; i <= Math.Sqrt(t); i++)//создаю цикл и прохожу с 1 до t
                {
                    if(t%i==0)//ставлю условие: если t по модулю
                    {
                        k++;  //увеличиваю на 1
                    }
                }
                if(k==0 && t!=1)//ставлю условие:если к равняется 2
                {
                    
                    arr1[g] = t;//приравниваю элемент массива под номером g к t
                    g++;//увеличиваю на 1
                    
                }
            }
            Console.WriteLine(g); //вывожу g
            for(int i=0;i<g;i++)//цикл, который проходит с нуля до g
            {
                Console.Write(arr1[i]+ " ");//вывожу элементы массива
            }
            Console.ReadKey();
        }
    }
}
