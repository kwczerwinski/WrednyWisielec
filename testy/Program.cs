using System;
using System.IO;

namespace testy
{
    class Program
    {
        static void Main(string[] args)
        {
            string litera;
            do
            {
                Console.WriteLine("Podaj literę: ");
                litera = Console.ReadLine().ToLower();
            } while (litera.Length > 1 || !(Char.IsLetter(litera, 0)));

            Console.WriteLine("\n{0}", litera);
        }
    }
}
