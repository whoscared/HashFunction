using System;
using System.Diagnostics;
using System.IO;
using Hash.HashFunctions;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new("forcheck.txt", FileMode.Open);
            StreamReader stream = new(file);

            string text = "";

            while (!stream.EndOfStream)
            {
                text += stream.ReadLine();
            }

            var Words = text.Split(new[] { ',', '.', ' ', ';', ':', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            Stopwatch timer = new();

            Console.WriteLine("Hash-function");
            Console.WriteLine("1) Hash With Array 2) Hash With List");
            int whatishash = Int32.Parse(Console.ReadLine());

            if (whatishash == 1)
            {
                timer.Start();
                HashWithArray withArray = new(Words.Length+1000);
                withArray.MakeHashTable(Words);
                timer.Stop();

                Console.WriteLine("Time :" + timer.ElapsedMilliseconds);
                timer.Reset();

                bool menu = true;
                while (menu)
                {
                    Console.WriteLine("1. Print hash-table\n2. Search string\n3. Add string\n4. Delete string\n5. Close\n");
                    int action = Int32.Parse(Console.ReadLine());
                    if (action == 1)
                    {
                        withArray.ConsoleWrite();
                    }
                    else if (action == 2)
                    {
                        Console.Write("String :");
                        string word = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(withArray.Search(word));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (action == 3)
                    {
                        Console.Write("String :");
                        string word = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(withArray.Add(word));
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else if (action == 4)
                    {
                        Console.Write("String :");
                        string word = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(withArray.Delete(word));
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else if (action == 5)
                        menu = !menu;
                }

            }
            else if (whatishash == 2)
            {
                timer.Start();
                HashWithList withList = new(5000);
                withList.MakeHashTable(Words);
                timer.Stop();

                Console.WriteLine("Time :" + timer.ElapsedMilliseconds);
                timer.Reset();

                bool menu = true;
                while (menu)
                {
                    Console.WriteLine("1. Print hash-table\n2. Search string\n3. Add string\n4. Delete string\n5. Close\n");
                    int action = Int32.Parse(Console.ReadLine());
                    if (action == 1)
                    {
                        withList.ConsoleWrite();
                    }
                    else if (action == 2)
                    {
                        Console.Write("String :");
                        string word = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(withList.Search(word));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (action == 3)
                    {
                        Console.Write("String :");
                        string word = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(withList.Add(word));
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else if (action == 4)
                    {
                        Console.Write("String :");
                        string word = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(withList.Delete(word));
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else if (action == 5)
                        menu = !menu;
                }

            }
        }
    }
}
