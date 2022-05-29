using System;

namespace Hash.HashFunctions
{
    class HashWithArray
    {
        readonly HashTableElement[] HashTable;
        readonly int Count;
        readonly int Step = 3;

        private int CountWord;

        public HashWithArray(int count)
        {
            Count = count;
            HashTable = new HashTableElement[Count];
            for (int i = 0; i < Count; i++)
            {
                HashTable[i] = new HashTableElement();
            }
        }

        public HashWithArray()
        {
            Count = 1024;
            HashTable = new HashTableElement[Count];
            for (int i = 0; i < Count; i++)
            {
                HashTable[i] = new HashTableElement();
            }
        }

        public void ConsoleWrite()
        {
            for (int i = 0; i < Count; i++)
            {
                if (HashTable[i].name != "")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("hash: " + i);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("word: " + HashTable[i].name);
                }
            }
        }
        public int HashCode (string name)
        {
            int h = -1; 
            if (name.Length > 0)
            {
                h = 0;
                char[] current = name.ToCharArray();
                for (int i = 0; i < current.Length; i++)
                {
                    int key = 999 / current[i];
                    h = key*h+current[i];
                }
                if (h < 0)
                    h *= -1;
                if (h >= Count)
                    h %= Count;
            }
            return h;
        }

        public string MakeHashTable (string[] array)
        {
            CountWord = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                int index = HashCode(array[i]);
                if (index != -1)
                {
                    HashTableElement current = new(array[i]);
                    while (HashTable[index].name.Length != 0)
                    {
                        index += Step;
                        if (index >= Count)
                            index -= Count;
                    }
                    HashTable[index] = current;
                }
                else
                {
                    return "Error!";
                }
            }
            return "Done!";
        }

        public string Add (string name)
        {
            if (CountWord >= Count)
            {
                return "HashTable full";
            }
            int index = HashCode(name);
            if (index != -1)
            {
                HashTableElement current = new(name);
                while (HashTable[index].name.Length != 0)
                {
                    index += Step;
                    if (index >= Count)
                        index -= Count;
                }
                HashTable[index] = current;
                return "Done!";
            }
                return "Error!";
        }

        public string Search(string name)
        {
            int index = HashCode(name);
            if (index != -1)
            {
                if (HashTable[index].name != name)
                {
                    do
                    {
                        index += Step;
                        if (index >= Count)
                            index -= Count;
                    } while (HashTable[index].name != name && HashTable[index].presence == true);
                    if (HashTable[index].name != name)
                    {
                        return "there is no word";
                    }
                    else
                        return $"{HashTable[index].name} hash: {index}";
                }
                else
                    return $"{HashTable[index].name} hash: {index}";
            }
            return "Error!";
        }

        public string Delete (string name)
        {
            int index = HashCode(name);
            if (index != -1)
            {
                if (HashTable[index].name != name)
                {
                    do
                    {
                        index += Step;
                        if (index >= Count)
                            index -= Count;
                    } while (HashTable[index].name != name && HashTable[index].presence == true);
                    if (HashTable[index].name != name)
                    {
                        return "there is no word";
                    }
                    else
                    {
                        HashTable[index].Delete();
                        return "Done!";
                    }

                }
                else
                {
                    HashTable[index].Delete();
                    return "Done!";
                }
            }
            return "Error!";

        }
    }
}
