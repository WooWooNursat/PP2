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
            int n = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            string[] arr = line.Split();
            for(int j=0;j<arr.Length;j++)
            {
                for(int i=0;i<2;i++)
                {
                    Console.Write(arr[j] + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
