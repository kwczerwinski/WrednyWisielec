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

            //Tablica przechowująca, które słowa zostały wyeliminowane z gry
            bool[] pozycje = new bool[slowa.Length];
            for(int i=0; i < pozycje.Length; i++)
            {
                pozycje[i] = true;
            }

            //Zmienne przechowujące stan gry
            int iloscProb = 20; //ilość prób gracza
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
            while(koniec == false)
            {
                //1. Wybór litery przez gracza
                do
                {
                    Console.WriteLine("Podaj literę: ");
                    litera = Console.ReadLine().ToLower();
                } while (litera.Length > 1);

                //2. Weryfikacja słów nie zawierających wybranych liter
                bool[] tmp = pozycje;
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
                //3.3. Jeśli ilość prób gracza = 0, idź do 12.
                
                int check = -1;
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] == false)
                    {
                        continue;
                    }
                    else if (check == -1)
                    {
                        check = i;
                    }
                    else if (check != -1)
                    {
                        pozycje = tmp;
                        if(--iloscProb == 0)
                        {
                            koniec = true;
                        }
                        break;
                    }
                    if (i == tmp.Length)
                    {
                        //4. Losuj słowo, które nie zawiera liter z tablicy liter.
                        if (check != -1)
                        {
                            wybraneSlowo = slowa[check];
                        }
                        else
                        {
                            int losowaPozycja;
                            while (wybraneSlowo == null)
                            {
                                losowaPozycja = new Random((int)DateTime.Now.Ticks).Next(pozycje.Length);
                                if (pozycje[losowaPozycja] != false)
                                {
                                    wybraneSlowo = slowa[losowaPozycja];
                                }
                            }
                        }
                    }
                }
                //3.4. Wróć do punktu 1





            }

            while(koniec == false)
            {
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
            }

            //12. Wypis przegranej gracza.
            if (wygrana == false)
            {
                Console.WriteLine("Niestety Wredny Wisielec cię pokonał.")
            }

            //13. Wypis wygranej gracza.
            else
            {
                Console.WriteLine("Gratulacje w pokonaniu gry!")
            }
        }
        
    }
}
