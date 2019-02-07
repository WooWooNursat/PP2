using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//ввожу число в виде строки и сразу переводим в int
            for (int i = 1; i <= n; i++)//цикл, который проходит с 1 до n
            {
                for(int j=0;j<i;j++)//цикл, который проходит с 0 до i
                {

                    Console.Write("[*]");//вывожу "[*]"
                    

                }
                Console.WriteLine("");//вывожу "" и перехожу на следующую строку
            }
        }
    }
}
