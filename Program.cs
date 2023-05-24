namespace gra
{
    class gra
    {
        static int[,] postacie = { { 200, 60, 0, 15 }, { 150, 30, 150, 20 }, { 120, 40, 30, 35 } }; //Postacie do wywboru pokolei
        static String[] nazwyPostaci = { "Wojownik", "Mag", "Bandyta" }; // Nazwy Postaci

        static int hp, attack, mana, gold = 0; //tworzenie statow jeszcze nie przypisane do postaci
        static int mhp, mattack, mmana, mgold = 0; // tworzenie statow potwora nie przypisane bo robią się nowe
        static String name = ""; // tworzenie nazwy 

        static void komunikat(string x)
        {
            Console.Clear(); // czyści konsole
            Console.WriteLine(x); // pisze tekst
            Console.ReadKey(); // czeka na cokolwiek
            Console.Clear(); // znpwu czysci
        }

        public static void wyborpostac()
        {
            while (hp == 0) // jeśli będzie zły numer to wróci bo nie jest przypisane (mogło to być wszystko inne)
            {
                Console.WriteLine("Wybor postaci: \n Wojownik - 1 \n Mag - 2 \n bandyta - 3 "); // pisze
                int input = int.Parse(Console.ReadLine()); // pyta się o numer z wczesniejszego pytania
                if (input != 1 && input != 2 && input != 3) // jesli bedą inne inz 1,2 lub 3 to wraca (  && znaczy i)
                {
                    komunikat("zły numer");
                }
                else
                {
                    int x = input - 1; // -1 bo indeksy zaczynają się od zera a użytkownik jest pytany od 1
                    hp = postacie[x, 0]; // przypisuje wszystkie staty z wcześniejszej listy postaci
                    attack = postacie[x, 1];
                    mana = postacie[x, 2];
                    gold = postacie[x, 3];
                    name = nazwyPostaci[x];
                }
            }
        }

        public static void statyporwora()
        {
            Random rnd = new Random(); // tworzy randoma
            mhp = rnd.Next(20, 50); // przypisuje randomowe liczby od x, do ,x
            mattack = rnd.Next(15, 50);
            mmana = rnd.Next(5, 20);
            mgold = rnd.Next(3, 40);
        }

        public static void heal()
        {
            if (mana >= 20) // sprawdza czy masz wystarczająco many
            {
                hp += 15; // dodaje hp z heala
                mana -= 20; // zabiera mane z użycia
                komunikat("Użyłeś Heala (+15 hp  -20 many)");

            }
            else
            {
                komunikat("Brak many"); // jeśli nie masz many to no
            }
        }

        public static void boost() // to samo co wcześniejszy
        {
            if (mana >= 30)
            {
                hp += 10;
                attack += 10;
                mana -= 30;
                komunikat("Użyłeś Boosta (+10 hp   +10 dmg   -30 many)");
            }
            else
            {
                komunikat("Brak many");
            }
        }

        public static void sklep()
        {
            Console.Clear(); // clear
            Console.WriteLine("\n *Widzisz ceny na tablic* ");
            Console.WriteLine("\n1 - +25hp = 5 złota \n 2 - +20 ataku = 15 złota \n 3 - +50 many = 8 złota \n dowolny inny numer - wyjdz");
            int input = int.Parse(Console.ReadLine()); // pyta się
            switch (input)
            {
                case 1: // jesli input to 1
                    Heal(); // wywołuje(używa) heala
                    break;
                case 2:
                    Bron(); // to samo co wcześniej
                    break;
                case 3:
                    AddMana(); // x
                    break;
                default:
                    komunikat("\nWychodzisz ze sklepu"); // jeśli wciśnie inny numerek to wychodzi
                    break;
            }
        }


        static void AddMana()
        {
            if (gold - 8 < 0) // sprawdza czy nasz wystarczająco hajsu
            {
                komunikat($"\nnie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {8 - gold} złota"); // ile potrzebujesz
            }
            else // jeśli masz
            {
                gold -= 8; // zabiera ci hajs
                mana += 50; // daje ci mane
            }
        }

        static void Bron() // to samo ...
        {
            if ((gold - 15) < 0)
            {
                komunikat($"\nnie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {15 - gold} złota");
            }
            else
            {
                gold -= 15;
                attack += 20;
            }
        }

        static void Heal() // ...
        {
            if ((gold - 5) < 0)
            {
                komunikat($"\nnie masz wystarczająco pieniędzy\n Potrzebujesz jeszcze {5 - gold} złota");
            }
            else
            {
                gold -= 5;
                hp += 25;
            }
        }

        static void Main() // główna funkcja w grze
        {
            wyborpostac(); // wywołuje 
            while (hp > 0) // dopoki nie zdechniesz to robi to wszystko
            {

                Console.Clear(); // clear
                Console.WriteLine($"\n{name}:\n hp - {hp}\n dmg - {attack}\n mana - {mana}\n złoto - {gold}"); // wypisuje staty
                Console.WriteLine("\n=========================\n");
                Console.WriteLine("\nCo chcesz zrobić? \n 1 - Idz do sklepu\n 2 - Idz na wyprawe");
                int inp = int.Parse(Console.ReadLine()); // pyta się
                if (inp == 1) // jeśli dostał 1 to idzie do sklepu
                {
                    sklep(); // wywołuje
                }
                else if (inp == 2) // jeśli na wyprawe
                {
                    Console.Clear();
                    statyporwora(); // wywołuje to co wcześniej było te takie randomy
                    wyprawa(); // wychodzi

                }
            }
        }



        static void walka()
        {
            Console.Clear();
            Console.WriteLine("Walka");

            komunikat($"\nPotwór zadaje ci {mattack}"); // mówi ile zadał ci
            hp -= mattack;
            komunikat($"\nTy zadajesz mu {attack}"); // ile zadałeś ty
            mhp -= attack;

            if (hp <= 0) // jeśli masz mniej niż 0 to zdychasz
            {
                komunikat("UMARŁEŚ!!!!");
                return;
            }
            if (mhp <= 0) // jeśli on ma
            {
                komunikat($"\nzabierasz potworowi {mgold} złota i pobierasz kawałki many z jego duszy");
                gold += mgold; // loocisz borowika do zera 
                mana += mmana;
            }
        }

        static void zaklecia()
        {

            Console.Clear();
            Console.WriteLine("\nZaklęcia\n 1 - heal(+15   hp   -20 many)\n 3 - Boost(+10 hp   +10 dmg   -30 many)");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1: // jeśli 1 
                    heal(); // czarymary heal
                    break;
                case 2:
                    boost(); // czarymary boost
                    break;
                default:
                    komunikat("\nzły numer"); // jesteś idiotą i wpisałeś zły numer
                    break;
            }
        }

        static void ucieczka()
        {
            komunikat("\nUciekasz"); // robisz to co każdy szanowany się mężczyzna po wynikach ciążowych
            Random rnd = new Random(); // random
            int ucieczka = rnd.Next(1, 6); // losuje ci czy uciekniesz
            if (ucieczka == 2 || ucieczka == 5) // jeśli miałeś 2 lub 5 to uciekasz ( || to jest lub)
            {
                komunikat("\nUdaje ci się uciec"); // wow
                mhp = 0; // wtedy wywala tamto spotkanie go 
            }
            else // inaczej to dostajesz na pizde od niego
            {
                hp -= (mattack * 2); // jego attack razy 2 💀💀 
                komunikat("\nNie udaje ci się uciec potwór zadaje ci podwójne obrażenia");
            }
        }

        static void wyprawa()
        {
            while (mhp > 0) // to co było powyżej napisane o tyn mhp = 0 to tu działa
            {
                Console.Clear();
                Console.WriteLine("\n Spotykasz potwora\nCo robisz?\n 1 - Walczysz\n 2 - Używasz Zaklęć\n 3 - Spróbuj ucieczki");
                Console.WriteLine($"\n Potwór: hp - {mhp}\n dmg - {mattack}\n mana - {mmana}\n złoto - {mgold}"); // ile on ma hp itd
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        walka(); // wywołuje funkcję
                        break;
                    case 2:
                        zaklecia(); // ...
                        break;
                    case 3:
                        ucieczka(); // ...
                        break;
                    default:
                        komunikat("zły numer");
                        break;
                }
            }
        }
    }
}
// koniec mam nadzieje na 6 

// COOOO ROSYJSKA SIGMA ŚRODA W 3D KTÓRA PROŚI O LIKE https://www.youtube.com/shorts/WvQlgq_sZbE 😮😮😮😮😮😮😮😮 polecam kocham środe bo mam tylko 3 lekcje kc