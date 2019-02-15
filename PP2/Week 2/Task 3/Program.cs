using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Nursat\Desktop\test\3\Proga");//создаю переменную, хранящую в себе информацию о папке
            PrintInfo(dir, 0);//вызываю принтинфо
            Console.ReadKey();
        }
        private static void PrintInfo(FileSystemInfo fsi, int k)//создаю функцию с двумя аргументами
        {
            string line = new string(' ', k);//создаю строку с к пробелами
            line = line + fsi.Name;//записываю в строку имя папки
            Console.WriteLine(line);//вывод строки

            if (fsi.GetType() == typeof(DirectoryInfo))//если fsi - папка, условие
            {
                var items = (fsi as DirectoryInfo).GetFileSystemInfos();//записываем в переменную все файлы и папки из дир
                foreach (var i in items)//цикл, проходящий по всем элементам итемс
                {
                    if (i.GetType() == typeof(FileInfo))//условие - если i это файл
                    {
                        PrintInfo(i, k + 4);//вызов функции принтинфо
                    }
                    
                }
                foreach (var i in items)//цикл, проходящий по всем элементам итемс
                {
                    if (i.GetType() == typeof(DirectoryInfo))//условие - если i это папка
                    {
                        PrintInfo(i, k + 4);//вызов принтинфо
                    }

                }
            }
        }
    }
}
