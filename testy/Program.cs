using System;
using System.IO;

namespace testy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program stworzony na potrzeby zajęć Programowanie Komputerów
            //Wyższa Szkoła Bankowa w Gdańsku, kierunek Informatyka, semestr I
            //Wykonanie: Krzysztof Czerwinski

            //Informacje wstępne
            Console.WriteLine("Witaj w grze Wredny Wisielec!\n\nZasady gry:\n1. Podajesz literę\n2. Jeśli litera istnieje w słowie to zostaje ona wypisana\n3. Jeśli litera nie istnieje w słowie to tracisz życie\n4. Wygrywasz jeśli odgadniesz wszystkie litery słowa\n5. Przegrywasz jeśli stracisz wszystkie życia\n\nZrozumiałeś? No to zaczynajmy!\n");

            //Wczytanie słów w pliku tekstowego do tablicy
            string[] slowa = { "abakus", "atanela", "bumb" };

            //Tablica przechowująca, które słowa zostały wyeliminowane z gry
            bool[] pozycje = new bool[slowa.Length];
            for (int i = 0; i < pozycje.Length; i++)
            {
                pozycje[i] = true;
            }

            //Zmienne przechowujące stan gry
            int iloscProb = 10; //ilość prób gracza
            bool koniec = false; //stan konca gry
            bool wygrana = false; //stan wygranej gracza

            //Tablica liter wybranych przez gracza
            string[] litery = new string[iloscProb];
            for (int i = 0; i < litery.Length; i++)
            {
                litery[i] = null;
            }

            //Zmienna chwilowo przechowująca wybraną literę gracza, potrzebna do wykonywania operacji sprawdzania wartości wciśniętego klawisza
            string litera;

            //Zmienna przechowująca słowo wybrane przez program do drugiego etapu gry
            string wybraneSlowo = null;

            //Pętla z grą
            int check = -1;
            while (koniec == false)
            {
                wypis(slowa, pozycje, litery);

                //1. Wybór litery przez gracza
                do
                {
                    Console.WriteLine("Podaj literę: ");
                    litera = Console.ReadLine().ToLower();
                } while (litera == "" || litera.Length > 1 || !(Char.IsLetter(litera, 0)));

                //2. Weryfikacja słów nie zawierających wybranych liter
                bool[] tmp = new bool[slowa.Length];
                Array.Copy(pozycje, tmp, pozycje.Length);
                for (int i = 0; i < slowa.Length; i++)
                {
                    if (tmp[i] == false)
                    {
                        continue;
                    }
                    if (slowa[i].Contains(litera))
                    {
                        tmp[i] = false;
                    }
                }

                //3. Jeśli ilość słów > 0 i ilość prób gracza > 0 to,
                //3.1. Wprowadź literę do tablicy liter
                //3.2. Obniż ilość prób gracza o 1
                //3.3. Jeśli ilość prób gracza = 0, idź do 11.

                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] == false)
                    {
                        if (i == tmp.Length - 1)
                        {
                            //4. Losuj słowo, które nie zawiera liter z tablicy liter.
                            int losowaPozycja;
                            while (wybraneSlowo == null)
                            {
                                losowaPozycja = new Random((int)DateTime.Now.Ticks).Next(pozycje.Length);
                                if (pozycje[losowaPozycja] == true)
                                {
                                    wybraneSlowo = slowa[losowaPozycja];
                                }
                            }
                            break;
                        }
                        continue;
                    }
                    else if (check == -1)
                    {
                        check = i;
                        continue;
                    }
                    else if (check != -1)
                    {
                        Array.Copy(tmp, pozycje, pozycje.Length);
                        if (--iloscProb == 0)
                        {
                            koniec = true;
                        }
                        break;
                    }
                }
                //3.4. Wróć do punktu 1
                for (int i = 0; i < litery.Length; i++)
                {
                    if (litery[i] == null)
                    {
                        litery[i] = litera;
                        break;
                    }
                }

                if(wybraneSlowo != null)
                {
                    break;
                }
            }

            Console.WriteLine(wybraneSlowo);
            Console.ReadKey();
        }

        static void wypis(string[] s, bool[] p, string[] l)
        {
            for(int i = 0; i < s.Length; i++)
            {
                Console.WriteLine($"{s[i]} {p[i]}");
            }
            foreach(var tmp in l)
            {
                if(tmp != null)
                {
                    Console.WriteLine("{0} ", tmp);
                }
            }
        }
    }
}
