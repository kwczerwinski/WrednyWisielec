using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testy
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] slowa = { "aaa", "bbb", "ccc" };
            string[] tmp = slowa;
            int i = 1;
            slowa = new string[tmp.Length - 1];
            for (int j = 0; j < i; j++)
            {
                slowa[j] = tmp[j];
            }
            for(int j = i+1)
            foreach (string a in slowa)
            {
                Console.WriteLine(a);
            }
        }
    }
}
