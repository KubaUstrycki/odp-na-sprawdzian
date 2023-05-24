using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
/*
1.Wygeneruj tablice AAA zawierającą n elementów ciągu fibonacciego. (n = 100)
1,1,2,3,5,8,13,21….

2.Wypisz wszystkie liczby pierwsze parzyste z wygenerowanej tablicy  AAA  (sprawdzam czy umiecie myśleć)

3.Wygeneruj tablice BBB w której zawarte będą wszystkie liczby pierwsze z tablicy AAA. 

4.Powiedz w której z nich znajduje się najmniejsza liczba.  (sprawdzam czy umiecie myśleć)

5.Wymnóż wszystkie elementy z tablicy BBB  wyświetl tą liczbę. Wypisz czynniki pierwsze - w jednej linijce (sprawdzam czy umiecie myśleć).

6.Ile jest liczb w int podzielnych przez 1. (sprawdzam czy umiecie myśleć)
Wyświetl wynik.

7.Ratunkowe;)
Wypisz wszystkie liczby powtarzające się przynajmniej dwa razy w ciagu fibonacciego.
(sprawdzam czy umiecie myśleć).
*/
namespace ConsoleApp2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] a = {};
            var AAA = a.ToList();
            List<int> BBB = new List<int>();
            int n = int.Parse(Console.ReadLine());
            int i = -1;
            int x = 0;
            int o = 0;
            int ilz = 1;
            while (n != 0)
            {
                if (AAA.Count < 2)
                {
                    AAA.Add(1);
                    i++;
                }
                else
                {
                    x = AAA[i] + AAA[i - 1];
                    i++;
                    AAA.Add(x);
                    n = n - 1;
                    o = 0;
                    for (int j = 1; j < x; j++)
                    {
                        if (AAA[i] % j == 0)
                        {
                            o++;   
                        }
                        
                    }
                    if (o == 1)
                    { 
                        BBB.Add(x);
                    }
                    


                }
                
                
                
            }
            for (int ss = 0; ss < BBB.Count; ss++)
            {
                ilz *= BBB[ss];
            }
            Console.WriteLine("ZAD 1");
            Console.WriteLine(String.Join(", ", AAA)); 
            Console.WriteLine("\nZAD 2");
            Console.WriteLine(2);
            Console.WriteLine("\nZAD 3");
            Console.WriteLine(String.Join(", ", BBB)); 
            Console.WriteLine("\nZAD 4");
            Console.WriteLine(ilz); 
            Console.WriteLine(String.Join(" * ", BBB));
            Console.WriteLine("\nZAD 5");
            Console.WriteLine(String.Join(", ", AAA));
            Console.WriteLine("\nZAD 6");
            Console.WriteLine(AAA.Count);
            Console.WriteLine("\nZAD 7");
            Console.WriteLine(1);
            Console.ReadKey();
            
        }
    }
}
