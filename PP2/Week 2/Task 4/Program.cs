using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string f = "file.txt";
            
            string path = @"C:\Users\Nursat\Desktop\test\4\path";
            string path1 = @"C:\Users\Nursat\Desktop\test\4\path1";
            
            string source = Path.Combine(path, f);
            string dest = Path.Combine(path1, f);

            FileStream fs = File.Create(source);
            StreamWriter sr = new StreamWriter(fs);
            sr.Write("bla bla");
            sr.Close();
            fs.Close();

            

            File.Copy(source, dest, true);

            File.Delete(source);
            
        }
    }
}
