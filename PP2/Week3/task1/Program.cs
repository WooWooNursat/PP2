using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task1
{
    class Layer
    {
        public FileSystemInfo[] Content//создаю функцию массив контент
        {
            get;//гет
            set;//сет
        }

        int selected;//переменная селектед
        public int Selected//функция селектед
        {
            get//гет
            {
                return selected;//возвращаю селектед 
            }
            set//сет
            {
                if (value < 0)//условие - если значение меньше 0
                {
                    selected = Content.Length - 1;//селектед приравниваем длину контента-1
                }
                else if (value >= Content.Length)//условие - если значение больше или равно длина контента
                {
                    selected = 0;//значение равно 0
                }
                else { selected = value; }//иначе селектед = значение
            }

        }

        public void Draw()//функция дроу
        {
            Console.BackgroundColor = ConsoleColor.Black;//меняем фон на черный
            Console.Clear();//очищаю консоль 
            for (int i = 0; i < Content.Length; i++)//цикл от начала до конца контента
            {
                if (i == Selected)//условие если ай равно селектед 
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;//цвет фона - магента
                }
                else Console.BackgroundColor = ConsoleColor.Black;//иначе черный
                Console.WriteLine(Content[i].Name);//вывод имя элемента контента ай
            }
        }
    }

    enum FarMode//перечисление енам фармод
    {
        DirectoryView,//первый 
        FileView//второй
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\Nursat\Desktop\test");//рут - информация о файле или папке
            Stack<Layer> history = new Stack<Layer>();//создаю стак
            FarMode farMode = FarMode.DirectoryView;//фармод = дайректори вью
            history.Push(//добавление в стак
                new Layer//создание новой переменной типа лэйер
                {
                    Content = root.GetFileSystemInfos(),//контент = все файлы и папки из рут
                    Selected = 0//селектед =0
                }
            );
            while (true)//бесконечный цикл
            {
                if(farMode == FarMode.DirectoryView)//если фармод = дайректори
                {
                    history.Peek().Draw();//вызов функции дроу
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();//бинды
                switch (consoleKeyInfo.Key)//свитч кейсы
                {
                    case ConsoleKey.UpArrow://1 кейс - апэрроу
                        history.Peek().Selected--;//уменьшение селектед на 1
                        break;
                    case ConsoleKey.DownArrow://2 кейс - даунэрроу
                        history.Peek().Selected++;//увеличение селектед на 1
                        break;
                    case ConsoleKey.Enter://3 кейс - интер
                        int i = history.Peek().Selected;//ай = селектед
                        FileSystemInfo fileSystemInfo = history.Peek().Content[i];//информация о элементе ай контента
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))//если файлсистем инфо - папка
                        {
                            history.Push(//добавление в стак
                                new Layer//создание новой переменной типа лэйер
                                {
                                    Content = (fileSystemInfo as DirectoryInfo).GetFileSystemInfos(),//контент = все файлы и папки из файлсистеминфо
                                    Selected = 0//селектед = 0
                                }
                            );
                        }
                        else// иначе
                        {
                            farMode = FarMode.FileView;//фармод = файлвью
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))//файлстрим для просмотра
                            {
                                using(StreamReader sr = new StreamReader(fs))//стримридер
                                {
                                    Console.BackgroundColor = ConsoleColor.White;//фон - белый
                                    Console.ForegroundColor = ConsoleColor.Black;//шрифт - черный
                                    Console.Clear();//очистить консоль
                                    Console.WriteLine(sr.ReadToEnd());//вывод всего текста из файла
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace://4 кейс - бэкспэйс
                        if (farMode == FarMode.DirectoryView)//если фармод = дайректори
                        {
                            history.Pop();//удалить последний добавленный
                        }
                        else//иначе
                        {
                            farMode = FarMode.DirectoryView;//фармод = дайректори
                            Console.ForegroundColor = ConsoleColor.White;//шрифт - белый
                        }
                        break;
                    case ConsoleKey.Delete://5 кейс = делит
                        int j = history.Peek().Selected;//джей = селектед
                        FileSystemInfo fsi = history.Peek().Content[j];//информация о элемента джей контента
                        if (fsi.GetType() == typeof(DirectoryInfo))//если фси = папка
                        {
                            Directory.Delete(fsi.FullName, true);//удалить фси
                            history.Peek().Content = (fsi as DirectoryInfo).Parent.GetFileSystemInfos();//контент = перент папка фси
                        }
                        else//иначе
                        {
                            File.Delete(fsi.FullName);//удалить фси
                            history.Peek().Content = (fsi as FileInfo).Directory.GetFileSystemInfos();//контент = папка файла фси
                        }
                        break;
                    case ConsoleKey.F9://6 кейс - ф9
                        int x = history.Peek().Selected;//икс = селектед
                        FileSystemInfo fsi2 = history.Peek().Content[x];//информация о элементе икс контента
                        Console.BackgroundColor = ConsoleColor.Black;//фон - черный
                        Console.ForegroundColor = ConsoleColor.White;//фон - белый
                        Console.Clear();//очистить консоль
                        string rename = Console.ReadLine();//вводим в строку
                        if (fsi2.GetType() == typeof(DirectoryInfo))//если фси2 = папка
                        {
                            string pathOfDir = (fsi2 as DirectoryInfo).Parent.FullName;//в стринг хаписываем перент папку
                            string repath = Path.Combine(pathOfDir, rename);//в стринг записываем путь с файлом
                            Directory.Move(fsi2.FullName, repath);//переносим из одного пути в другой
                            history.Peek().Content = (fsi2 as DirectoryInfo).Parent.GetFileSystemInfos();//контент = перент папка 
                        }
                        else//иначе
                        {
                            rename = rename + ".txt";//в строку добавляем тхт
                            string pathOfFile = (fsi2 as FileInfo).Directory.FullName;//в строку записываем путь папки файла
                            string repath1 = Path.Combine(pathOfFile, rename);//в строку записываем путь с названием файла
                            File.Move(fsi2.FullName, repath1);//переносим из одного пути в другой
                            history.Peek().Content = (fsi2 as FileInfo).Directory.GetFileSystemInfos();//контент = папка файла
                        }
                        break;
                }
            }
            
        }
    }
}
