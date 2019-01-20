using System;
using System.IO;

namespace WrednyWisielec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("../../s" + new Random((int)DateTime.Now.Ticks).Next(2, 15) + ".txt");
            //string[] slowa = File.ReadAllLines("../../slowa.txt");
            //int maksymalnaDlugoscSlowa = 0;
            //foreach(string slowo in slowa)
            //{
            //    if(slowo.Length > maksymalnaDlugoscSlowa)
            //    {
            //        maksymalnaDlugoscSlowa = slowo.Length;
            //    }
            //}

            //for(int dlugoscSlowa = 0; dlugoscSlowa < maksymalnaDlugoscSlowa; dlugoscSlowa++)
            //{
            //    int i = 0;
            //    foreach (string slowo in slowa)
            //    {
            //        if (slowo.Length == dlugoscSlowa)
            //        {
            //            i++;
            //        }
            //    }
            //    string[] tmp = new string[i];
            //    i = 0;
            //    foreach (string slowo in slowa)
            //    {
            //        if (slowo.Length == dlugoscSlowa)
            //        {
            //            tmp[i++] = slowo;
            //        }
            //    }
            //    string path = "../../s" + dlugoscSlowa + ".txt";
            //    File.WriteAllLines(path, tmp);
            //}


        } //Main End
    } //Class End
}