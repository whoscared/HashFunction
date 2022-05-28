using System;
using Hash.HashFunctions;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] check = 
            {   
                "ferfervger","vefrvtbyynb","cece","rbtybhytfvgdf", "evrdevrbvf",
                "ejcfnscjkn", "mcdejcw", "kfne", "wmkenc", "mvcke", "wkecndekfc", "vrv", "a", "a",
                "edrcfedrverfv", "tbrtbbnytnyunytbf", "esrcrv", "tt", "qxsw", "btrf",
                "cjbedcfb","nkewce","ejbccejc","cnedcjbveivru","cebcubvc","kcenwcvev",
                "cbedhxsjdsnkjcbhsxnkl","kernbnfjvbjr","kendcei","vkrfniv","edkncfis","newcic"
            };

            HashWithList first = new(255);
            int checksd = first.HashCode("edrcfedrverfv");
            first.MakeHashTable(check);
            //Console.WriteLine(first.SearchString("kfne"));
            Console.WriteLine(checksd);
            Console.WriteLine("=============================");
            HashWithList second = new(255);
            second.SetValues(30);
            int checnd = second.HashCode("edrcfedrverfv");
            second.MakeHashTable(check);
            Console.WriteLine(checnd);
            //Console.WriteLine(second.SearchString("kfne"));
            Console.ReadKey();
            


        }
    }
}
