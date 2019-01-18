using System;
using System.IO;

namespace testy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w grze Wredny Wisielec!\n\nZasady gry:\n1. Podajesz literę\n2. Jeśli litera istnieje w słowie to zostaje ona wypisana\n3. Jeśli litera nie istnieje w słowie to tracisz życie\n4. Wygrywasz jeśli odgadniesz wszystkie litery słowa\n5. Przegrywasz jeśli stracisz wszystkie życia\n\nZrozumiałeś? No to zaczynajmy!\n");

            //Wczytanie słów w pliku tekstowego do tablicy
            string[] slowa = File.ReadAllLines("../../slowa.txt");

            //Tablica przechowująca, które słowa zostały wyeliminowane z gry
            bool[] pozycje = new bool[slowa.Length];
            for (int i = 0; i < pozycje.Length; i++)
            {
                pozycje[i] = true;
            }

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} {1}", slowa[i], pozycje[i]);
            }
        }
    }
}
