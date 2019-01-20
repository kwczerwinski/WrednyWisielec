using System;
using System.IO;

namespace WrednyWisielec
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] slowa = File.ReadAllLines("../../slowa.txt");

            int dlugoscSlowa = 2;
            //słowa dwuliterowe
            int i = 0;
            foreach(string slowo in slowa)
            {
                if(slowo.Length == dlugoscSlowa)
                {
                    i++;
                }
            }
            string[] tmp = new string[i];
            i = 0;
            foreach (string slowo in slowa)
            {
                if (slowo.Length == dlugoscSlowa)
                {
                    tmp[i++] = slowo;
                }
            }
            foreach(string slowo in tmp)
            {
                Console.WriteLine(slowo);
            }
            //File.WriteAllLines("../../s2.txt", tmp);

        } //Main End
    } //Class End
}