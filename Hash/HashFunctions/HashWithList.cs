using System.Collections.Generic;
using System;

namespace Hash.HashFunctions
{
    class HashWithList
    {
        readonly List<string>[] hashTable;
        readonly int Count;

        public HashWithList (int count)
        {
            Count = count;
            hashTable = new List<string>[Count];
            for (int i = 0; i < Count; i++)
            {
                hashTable[i] = new List<string>();
            }
        }
        public HashWithList()
        {
            Count = 1024;
            hashTable = new List<string>[Count];
            for (int i = 0; i < Count; i++)
            {
                hashTable[i] = new List<string>();
            }
        }

        public void ConsoleWrite()
        {
            for (int i = 0; i < Count; i++)
            {
                if (hashTable[i].Count != 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("hash: " + i+ "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("word: ");
                    for (int j = 0; j < hashTable[i].Count; j++)
                    {
                        Console.WriteLine(hashTable[i][j]);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public string Search(string name)
        {
            int index = HashCode(name);
            if (index != -1)
            {
                for (int i = 0; i < hashTable[index].Count; i++)
                {
                    if (hashTable[index][i] == name)
                        return $"{name} hash: {index}";
                }
            }
            return "Error";
        }
        public string Delete(string name)
        {
            int index = HashCode(name);
            if (index != -1)
            {
                for (int i = 0; i < hashTable[index].Count; i++)
                {
                    if (hashTable[index][i] == name)
                    {
                        hashTable[index].RemoveAt(i);
                        return "Done!";
                    }
                }
            }
            return "Error";
        }
        public string Add(string name)
        {
            int index = HashCode(name);
            if (index != -1)
            {
                hashTable[index].Add(name);
                return "Done!";
            }
            return "Error";
        }
        public string MakeHashTable(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int index = HashCode(array[i]);
                if (index != -1 )
                {
                    if (hashTable[index].IndexOf(array[i]) == -1)
                    hashTable[index].Add(array[i]);
                }
                else
                {
                    return "Error";
                }
            }
            return "Done!";
        }
        public int HashCode(string name)
        {
            int h = -1;
            if (name.Length > 0)
            {
                h = 0;
                char[] current = name.ToCharArray();
                for (int i = 0; i < name.Length; i++)
                {
                    h = (47 * h + current[i] * i + 9)%Count;
                }
            }
            if (h < 0)
                h *= -1;
            return h;
        }
    }
}
