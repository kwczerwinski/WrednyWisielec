using System;
using System.IO;

namespace WrednyWisielec
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program stworzony na potrzeby zajęć Programowanie Komputerów
            //Wyższa Szkoła Bankowa w Gdańsku, kierunek Informatyka, semestr I
            //Wykonanie: Krzysztof Czerwinski

            //Informacje wstępne
            Console.WriteLine("Witaj w grze Wredny Wisielec!\n\nZasady gry:\n1. Podajesz literę\n 2. Jeśli litera istnieje w słowie to zostaje ona wypisana 3. Jeśli litera nie istnieje w słowie to tracisz życie 4. Wygrywasz jeśli odgadniesz wszystkie litery słowa 5. Przegrywasz jeśli stracisz wszystkie życia\n\nZrozumiałeś? No to zaczynajmy!\n");

            //Wczytanie słów w pliku tekstowego do tablicy
            string[] slowa = File.ReadAllLines("slowa.txt");

            //Zmienna przechowująca ilość prób gracza
            int iloscProb = 20;

            //Tablica liter wybranych przez gracza
            char[] litery = new char[iloscProb];

            //Zmienna chwilowo przechowująca wybraną literę gracza, potrzebna do wykonywania operacji sprawdzania wartości wciśniętego klawisza
            string litera;

            //Pętla z grą

            //1. Wybór litery przez gracza
            do
            {
                Console.WriteLine("Podaj literę: ");
                litera = Console.ReadLine().ToLower();
            } while (litera.Length > 1);

            //2. Weryfikacja ilości słów nie zawierających wybranych liter
            int[] pozycje = null;
            for (int i = 0; i < slowa.Length; i++)
            {
                if (slowa[i].Contains(litera.ToString()))
                {
                    if (pozycje == null)
                    {
                        pozycje = new int[1];
                        pozycje[0] = i;
                    }
                    int[] tmp = pozycje;
                    pozycje = new int[tmp.Length + 1];
                    for(int j = 0; j < tmp.Length; j++)
                    {
                        pozycje[i] = tmp[i];
                    }
                    pozycje[pozycje.Length - 1] = i;
                }
            }
            

            //3. Jeśli ilość słów > 0 i ilość prób gracza > 0 to,

            //3.1. Wprowadź literę do tablicy liter

            //3.2. Obniż ilość prób gracza o 1

            //3.3. Jeśli ilość prób gracza = 0, idź do 12.

            //3.4. Wróć do punktu 1

            //4. Losuj słowo, które nie zawiera liter z tablicy liter.

            //5. Wypisz pozycje ostatniej litery wybranej przez gracza.

            //6. Jeśli ilość prób gracza = 0, idź do 12.

            //7. Wybór litery przez gracza.

            //8. Jeśli litera jest w danym słowie:

            //8.1. Wypisz pozycje litery w danym słowie

            //8.2. Jeśli słowo zostało odkryte, idź do 13.

            //8.3. Wróć do 7.

            //9. Obniż ilość prób gracza o 1.

            //10. Jeśli ilość prób gracza = 0. idź do 12.

            //11. Wróć do 7.

            //12. Wypis przegranej gracza.

            //13. Wypis wygranej gracza.
        }
    }
}
