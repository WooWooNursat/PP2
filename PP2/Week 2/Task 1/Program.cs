using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Nursat\Desktop\test\1\file.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            fs.Close();
            sr.Close();
            for(int i = 0; i < line.Length/2; i++)
            {
                if (line[i] != line[line.Length - i - 1])
                {
                    Console.WriteLine("No");
                    break;
                }
                else if (i == (line.Length/2) - 1)
                {
                    Console.WriteLine("Yes");
                }
            }
            Console.ReadKey();
        }
    }
}
