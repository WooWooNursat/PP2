using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Nursat\Desktop\test\2\in.txt", FileMode.Open, FileAccess.Read);//создаю файлстрим
            StreamReader sr = new StreamReader(fs);//создаю стримридер
            string line = sr.ReadLine();//записываю в строку
            sr.Close();//закрываю стримридер
            fs.Close();//закрываю файлстрим
            string[] arr = line.Split();//записываю в массив 
            string line2="";//создаю строку пустую
            foreach (var o in arr)//цикл, проходящий по всему массиву
            {
                
                int element = int.Parse(o);//строку в инт
                for (int i = 2; i <= Math.Sqrt(element); i++)//цикл от 2 до корня числа
                {
                    if (element % i == 0 && element!=1)//если число делится на i и число не 1
                    {
                        goto metka;//переход на 35 строку
                    }
                    
                }
                line2 = line2 + o + " ";//записываю число в строку

            metka:;
            }
            FileStream fs2 = new FileStream(@"C:\Users\Nursat\Desktop\test\2\out.txt", FileMode.Open, FileAccess.Write);//создаю файлстрим
            StreamWriter swr = new StreamWriter(fs2);//создаю стримрайтер
            swr.Write(line2.Trim());//записываю строку в файл

            swr.Close();//закрываю стримрайтер
            fs2.Close();//закрываю файлстрим
            Console.ReadKey();
        }
    }
}
