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
        public FileSystemInfo[] Content
        {
            get;
            set;
        }

        int selected;
        public int Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (value < 0)
                {
                    selected = Content.Length - 1;
                }
                else if (value >= Content.Length)
                {
                    selected = 0;
                }
                else { selected = value; }
            }

        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for(int i = 0; i < Content.Length; i++)
            {
                if (i == Selected)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                else Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(Content[i].Name);
            }
        }
    }

    enum FarMode
    {
        DirectoryView,
        FileView
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\Nursat\Desktop\test");
            Stack<Layer> history = new Stack<Layer>();
            FarMode farMode = FarMode.DirectoryView;
            history.Push(
                new Layer
                {
                    Content = root.GetFileSystemInfos(),
                    Selected = 0
                }
            );
            while (true)
            {
                if(farMode == FarMode.DirectoryView)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().Selected--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().Selected++;
                        break;
                    case ConsoleKey.Enter:
                        int i = history.Peek().Selected;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[i];
                        if(fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            history.Push(
                                new Layer
                                {
                                    Content = (fileSystemInfo as DirectoryInfo).GetFileSystemInfos(),
                                    Selected = 0
                                }
                            );
                        }
                        else
                        {
                            farMode = FarMode.FileView;
                            using(FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using(StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if(farMode == FarMode.DirectoryView)
                        {
                            history.Pop();
                        }
                        else
                        {
                            farMode = FarMode.DirectoryView;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Delete:
                        int j = history.Peek().Selected;
                        FileSystemInfo fsi = history.Peek().Content[j];
                        if(fsi.GetType() == typeof(DirectoryInfo))
                        {
                            Directory.Delete(fsi.FullName, true);
                            history.Peek().Content = (fsi as DirectoryInfo).Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            File.Delete(fsi.FullName);
                            history.Peek().Content = (fsi as FileInfo).Directory.GetFileSystemInfos();
                        }
                        break;
                    case ConsoleKey.F9:
                        int x = history.Peek().Selected;
                        FileSystemInfo fsi2 = history.Peek().Content[x];
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        string rename = Console.ReadLine();
                        if(fsi2.GetType() == typeof(DirectoryInfo))
                        {
                            string pathOfDir = (fsi2 as DirectoryInfo).Parent.FullName;
                            string repath = Path.Combine(pathOfDir, rename);
                            Directory.Move(fsi2.FullName, repath);
                            history.Peek().Content = (fsi2 as DirectoryInfo).Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            rename = rename + ".txt";
                            string pathOfFile = (fsi2 as FileInfo).Directory.FullName;
                            string repath1 = Path.Combine(pathOfFile, rename);
                            File.Move(fsi2.FullName, repath1);
                            history.Peek().Content = (fsi2 as FileInfo).Directory.GetFileSystemInfos();
                        }
                        break;
                }
            }
            
        }
    }
}
