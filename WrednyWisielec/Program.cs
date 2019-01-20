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
            Console.Write("Witaj w grze Wredny Wisielec!\n\nZasady gry:\n1. Podajesz literę\n2. Jeśli litera istnieje w słowie to zostaje ona wypisana\n3. Jeśli litera nie istnieje w słowie to tracisz życie\n4. Wygrywasz jeśli odgadniesz wszystkie litery słowa\n5. Przegrywasz jeśli stracisz wszystkie życia\n\nZrozumiałeś? No to zaczynajmy!\n");

            //Losowanie długości słowa i wczytanie słów z odpowiedniego pliku tekstowego do tablicy
            string path = "../../s" + new Random((int)DateTime.Now.Ticks).Next(2, 15) + ".txt";
            string[] slowa = File.ReadAllLines(path);

            //Tablice przechowujące, które słowa zostały wyeliminowane z gry
            bool[] pozycjeWcześniejsze = new bool[slowa.Length];
            bool[] pozycjeObecne = new bool[slowa.Length];

            //Zmienne przechowujące stan gry
            int iloscProb = 15; //ilość prób gracza
            bool koniec = false; //stan konca gry
            bool wygrana = false; //stan wygranej gracza

            //Tablica liter wybranych przez gracza
            string[] litery = new string[34];

            //Zmienna chwilowo przechowująca wybraną literę gracza, potrzebna do wykonywania operacji sprawdzania wartości wciśniętego klawisza
            string litera;

            //Zmienna przechowująca słowo wybrane przez program do drugiego etapu gry
            string wybraneSlowo = string.Empty;

            //Pętla z grą
            while (koniec == false)
            {
                //Wypisanie ile gracz posiada prób
                Console.Write("\nIlość żyć: {0}", iloscProb);

                //Wypisanie użytych liter w grze
                Console.Write("\nLitery: ");
                for (int i = 0; i < litery.Length; i++)
                {
                    if (litery[i] != null)
                    {
                        Console.Write("{0} ", litery[i]);
                    }
                    else
                    {
                        break;
                    }
                }

                //Sprawdzenie etapu rozgrywki
                if (wybraneSlowo.Equals(string.Empty)) //I etap
                {
                    //Zmyłka dla gracza
                    Console.Write("\nSłowo: ");
                    for (int i = 0; i < slowa[0].Length; i++)
                    {
                        Console.Write("_ ");
                    }

                    //Wybór litery przez gracza
                    do
                    {
                        Console.Write("\n\nPodaj literę: ");
                        litera = Console.ReadLine().ToLower();
                    } while (litera == "" || litera.Length > 1 || !(Char.IsLetter(litera, 0)));

                    //Wprowadzenie litery do tablicy liter
                    for (int i = 0; i < litery.Length; i++)
                    {
                        if (litery[i] == null)
                        {
                            litery[i] = litera;
                            break;
                        }
                    }

                    //Weryfikacja słów nie zawierających wybranej litery
                    for (int i = 0; i < slowa.Length; i++)
                    {
                        if (slowa[i].Contains(litera))
                        {
                            pozycjeObecne[i] = true;
                        }
                    }

                    //Sprawdzenie ilości pozostałych słów
                    int iloscSlow = 0;
                    for (int i = 0; i < slowa.Length; i++)
                    {
                        if (pozycjeObecne[i] == false)
                        {
                            iloscSlow++;
                        }
                    }

                    //Wybranie kontunuacji gry
                    if (iloscSlow > 1) //Więcej niż jedno słowo spełniające warunek
                    {
                        //Zapisanie obecnego stanu gry jako poprzedniego stanu
                        Array.Copy(pozycjeObecne, pozycjeWcześniejsze, pozycjeObecne.Length);
                        
                        //Sprawdzenie ilości pozostałych prób gracza
                        if (--iloscProb == 0)
                        {
                            koniec = true;
                        }
                    }
                    else if (iloscSlow == 1) //Jedno słowo spełniające warunek
                    {
                        //Wybranie tego słowa do dalszej części gry
                        for (int i = 0; i < slowa.Length; i++)
                        {
                            if (pozycjeObecne[i] == false)
                            {
                                wybraneSlowo = slowa[i];
                                break;
                            }
                        }
                    }
                    else //Brak słów spełniających warunek
                    {
                        //Sprawdzenie ilości słów spełniających warunki
                        iloscSlow = 0;
                        for (int i = 0; i < slowa.Length; i++)
                        {
                            if (pozycjeWcześniejsze[i] == false)
                            {
                                iloscSlow++;
                            }
                        }
                        //Losowanie słowa do dalszej części gry
                        int losowaPozycja;
                        while (wybraneSlowo.Equals(string.Empty))
                        {
                            losowaPozycja = new Random((int)DateTime.Now.Ticks).Next(++iloscSlow);
                            for(int i = 0; i < slowa.Length; i++)
                            {
                                if(pozycjeWcześniejsze[i] == false)
                                {
                                    if(--iloscSlow == 0)
                                    {
                                        wybraneSlowo = slowa[i];
                                    }
                                }
                            }
                        }
                    }
                } //koniec I etapu
                else //II etap
                {
                    //Wypisanie liter odgadniętych przez gracza w słowie
                    Console.Write("\nSłowo: ");
                    bool wszystkoOdgadnięte = true;
                    for (int i = 0; i < wybraneSlowo.Length; i++)
                    {
                        for (int j = 0; j < litery.Length; j++)
                        {

                            if (litery[j] == null)
                            {
                                Console.Write("_ ");
                                wszystkoOdgadnięte = false;
                                break;
                            }
                            if (wybraneSlowo[i].Equals(litery[j][0]))
                            {
                                Console.Write("{0} ", litery[j]);
                                break;
                            }
                        }
                    }

                    //Sprawdzenie czy gracz odgadł wszystkie litery
                    if (wszystkoOdgadnięte == true)
                    {
                        wygrana = true;
                        koniec = true;
                    }
                    else
                    {
                        //Wybór litery przez gracza
                        do
                        {
                            Console.Write("\n\nPodaj literę: ");
                            litera = Console.ReadLine().ToLower();
                        } while (litera == "" || litera.Length > 1 || !(Char.IsLetter(litera, 0)));

                        //Wprowadzenie litery do tablicy liter
                        for (int i = 0; i < litery.Length; i++)
                        {
                            if (litery[i] == null)
                            {
                                litery[i] = litera;
                                break;
                            }
                        }

                        //Sprawdzenie czy litera zawiera się w słowie
                        if (!(wybraneSlowo.Contains(litera)))
                        {
                            if (--iloscProb == 0)
                            {
                                koniec = true;
                            }
                        }
                    }
                } //koniec II etapu
            } //koniec gry         

            //Wypis przegranej gracza.
            if (wygrana == false)
            {
                Console.Write("Czyżbyś nie znał(a) słowa \"{0}\"?", wybraneSlowo);
                Console.Write("\nNiestety Wredny Wisielec cię pokonał.");
            }

            //Wypis wygranej gracza.
            else
            {
                Console.Write("\nGratulacje w pokonaniu gry!");
            }

            Console.ReadKey();

        } //Main End
    } //Class End
}