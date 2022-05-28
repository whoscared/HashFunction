using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash.HashFuncktions
{
    class HashWithList
    {
        readonly List<string>[] hashTable;
        readonly int Count;

        private int first = 0;
        private int dicplacement = 0;
        //private int last = 255;

        public HashWithList (int count)
        {
            Count = count;
            hashTable = new List<string>[Count];
            for (int i = 0; i < Count; i++)
            {
                hashTable[i] = new List<string>();
            }
        }

        public void SetValues(int first)
        {
            this.first = first;
            dicplacement = -first;
            //this.last = last;
        }

        public string SearchString(string name)
        {
            int index = HashCode(name);
            index += dicplacement;
            for (int i = 0; i < hashTable[index].Count; i++)
            {
                if (hashTable[index][i] == name)
                    return $"{name}+{index}";
            }
            return "Слово отсутствует!";
        }
        public bool DeleteValue(string name)
        {
            int index = HashCode(name);
            index += dicplacement;
            for (int i = 0; i < hashTable[index].Count; i++)
            {
                if (hashTable[index][i] == name)
                {
                    hashTable[index].RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void AddValue(string name)
        {
            int index = HashCode(name);
            index += dicplacement;
            hashTable[index].Add(name);
        }

        public void MakeHashTable(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int index = HashCode(array[i]);
                index += dicplacement;
                hashTable[index].Add(array[i]);
            }
        }

        public int HashCode(string name)
        {
            int h = 0;
            if (name.Length > 0)
            {
                char[] current = name.ToCharArray();
                for (int i = 0; i < name.Length; i++)
                {
                    h = 31 * h + current[i];
                }
            }
            if (h < 0)
                h *= -1;
            if (h > Count)
                h %= (Count);
            if (h < first)
                h += first;
            return h;
        }
    }
}
