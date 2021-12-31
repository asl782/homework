using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ListVsDictionary
{
    //List vs Dict: napisz program, który wypełni listę oraz dictionrary min. 1 mln kalkulowanych elementów(np.i* i / 5)
    //- oblicz czas ładowania danych do obu kolekcji
    //- oblicz czas wyszukiwania elementów w kolekcji
    //- porównaj efektywność List vs Dictionary

    class Program
    {
        static void Main(string[] args)
        {
            const int howMany = 1000000;
            const int toSearch = 9800;

            var list = new List<int>();
            var dictionary = new Dictionary<int, int>();

            Stopwatch sw = new Stopwatch();

            var ll = ListLoad(howMany, list, sw);
            var dl = DictionaryLoad(howMany, dictionary, sw);

            if (ll < dl)
                Console.WriteLine("List is more efficient");
            else
                Console.WriteLine("Dictionary is more efficient");

            ListSearch(toSearch, list, sw);
            DictionarySearch(toSearch, dictionary, sw);
        }

        static TimeSpan ListLoad(int howMany, List<int> list, Stopwatch sw)
        {
            TimeSpan ts;

            sw.Start();
            for (int i = 0; i < howMany; i++)
            {
                list.Add(i * i / 5);
            }
            sw.Stop();
            ts = sw.Elapsed;

            Console.WriteLine($"The load time of a LIST of {howMany} items is {ts}");
            return ts;
        }
        
        static TimeSpan DictionaryLoad(int howMany, Dictionary<int, int> dictionary, Stopwatch sw)
        {
            TimeSpan ts;

            sw.Start();
            for (int i = 0; i < howMany; i++)
            {
                dictionary.Add(i, i * i / 5);
            }
            sw.Stop();
            ts = sw.Elapsed;

            Console.WriteLine($"The load time of a DICTIONARY of {howMany} items is {ts}");
            return ts;
        }
       
        static TimeSpan ListSearch(int toSearch, List<int> list, Stopwatch sw)
        {
            TimeSpan ts;

            sw.Start();
            list.FirstOrDefault(x => x > toSearch);
            sw.Stop();
            ts = sw.Elapsed;

            Console.WriteLine($"The search time of an item in a LIST is {ts}");
            return ts;
        }
        
        static TimeSpan DictionarySearch(int toSearch, Dictionary<int, int> dictionary, Stopwatch sw)
        {
            TimeSpan ts;

            sw.Start();
            dictionary.FirstOrDefault(x => x.Value > toSearch);
            sw.Stop();
            ts = sw.Elapsed;

            Console.WriteLine($"The search time of an item in a DICTIONARY is {ts}");
            return ts;
        }
    }
}
