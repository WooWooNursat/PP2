using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Student
    {
        public string name;
        public int id;
        public int year = 0;
        
        public Student(string n, int i)
        {
            name = n;
            id = i;
        }
        public void PrintInfo()
        {
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine(name + " " + id + " " + ++year);
            }
            
        }
       



    }



    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Nurik", 7);
            s.PrintInfo();
            Console.ReadKey();
        }
    }
}
