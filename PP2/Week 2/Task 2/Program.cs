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
            FileStream fs = new FileStream(@"C:\Users\Nursat\Desktop\test\2\in.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            sr.Close();
            fs.Close();
            string[] arr = line.Split();
            string line2="";
            foreach(var o in arr)
            {
                int element = int.Parse(o);
                for(int i = 1; i <= Math.Sqrt(element); i++)
                {
                    if (element % i == 0 && i!=1)
                    {
                        goto metka;
                    }
                    
                }
                line2 = line2 + o + " ";
                
            metka:;
            }
            FileStream fs2 = new FileStream(@"C:\Users\Nursat\Desktop\test\2\out.txt", FileMode.Open, FileAccess.Write);
            StreamWriter swr = new StreamWriter(fs2);
            swr.Write(line2.Trim());
            
            swr.Close();
            fs2.Close();
            
        }
    }
}
