using System;
using System.Collections.Generic;

namespace Lotto
{
        //Lotto Generator: Napisz generator do umożliwienia wylosowania kuponu "chybił-trafił" w lotto.
        //Losowane jest 6 z 49 liczb, wyświetlane według kolejności od 1 do 49.

    class Program
    {
        static void Main(string[] args)
        {
            int ileZakladow = 0;

            while (ileZakladow < 1 || ileZakladow > 10)
            {
                Console.WriteLine("Podaj ile zakładów (od 1 do 10) i naciśnij Enter");
                string odpowiedz = Console.ReadLine();
                int.TryParse(odpowiedz, out ileZakladow);
            }

            Console.WriteLine("Wygenerowany kupon:");
            Wyswietl(ChybilTrafil.GenerujKupon(ileZakladow));
        }

        public static void Wyswietl(List<int>[] tablicaNumerow)
        {
            foreach (var t in tablicaNumerow)
            {
                foreach (var l in t)
                {
                    Console.Write($"{l} ");
                }
                Console.WriteLine();
            }
        }
    }
}
