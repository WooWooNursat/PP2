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
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Nursat\Desktop\test\3\Proga");
            PrintInfo(dir, 0);
            Console.ReadKey();
        }
        private static void PrintInfo(FileSystemInfo fsi, int k)
        {
            string line = new string(' ', k);
            line = line + fsi.Name;
            Console.WriteLine(line);

            if (fsi.GetType() == typeof(DirectoryInfo))
            {
                var items = (fsi as DirectoryInfo).GetFileSystemInfos();
                foreach (var i in items)
                {
                    if (i.GetType() == typeof(FileInfo))
                    {
                        PrintInfo(i, k + 4);
                    }
                    
                }
                foreach (var i in items)
                {
                    if (i.GetType() == typeof(DirectoryInfo))
                    {
                        PrintInfo(i, k + 4);
                    }

                }
            }
        }
    }
}
