using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Student
    {
        public string name;//создаю строку 
        public int id;//создаю инт
        public int year = 0;//создаю инт
        
        public Student(string n, int i)//конструктор с двумя параметрами
        {
            name = n;//в строку записываю первый параметр
            id = i;//в инт записываю второй параметр
        }
        public void PrintInfo()//функция, которая выводит имя, айди и год
        {
            
                Console.WriteLine(name + " " + id + " " + year);//вывод
            
            
        }
        public void Incrementyear()//функция, увеличивающая год
            {
                year++;//увеличение 
            }



    }



    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Nursat", 7);//новая переменная с типом студент
            s.PrintInfo();//вызов функции
            s.Incrementyear();//вызов функции
            s.PrintInfo();//вызов функции
            Console.ReadKey();
        }
    }
}

