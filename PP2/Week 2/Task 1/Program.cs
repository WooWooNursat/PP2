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
        public static bool Print()
        {
            FileStream fs = new FileStream(@"C:\Users\Nursat\Desktop\test\1\file.txt", FileMode.Open, FileAccess.Read);//создаю файлстрим для просмотра файла
            StreamReader sr = new StreamReader(fs);//создаю стримридер
            string line = sr.ReadLine();//строка, в которую переписываю информацию из файла
            fs.Close();//закрываю файлстрим
            sr.Close();//закрываю стримридер

            for (int i = 0; i < line.Length / 2; i++)//цикл от начала до половины строки
            {
                if (line[i] != line[line.Length - i - 1])//условие - если элемент ай не равен элементу длина строки - ай - 1
                {
                    return false;//возвращаем фолз

                }
                
                  
                
            }
            return true;//возвращаю тру
        }
        static void Main(string[] args)
        {

            if (Print() == false)//условие - если принт равен фолз
            {
                Console.WriteLine("No");//вывод нет
            }
            else Console.WriteLine("Yes");//вывод да
            Console.ReadKey();
        }
    }
}
