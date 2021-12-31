using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StringSort
{
    //Napisz program do przetrzymywania typu String z listą 20 dowolnych słów:
    //- zaimplementuj/użyj metodę: sortowania ASC(ascending) / DESC(descending)
    //- przekonwertuj List<> na Dictionary<> używając metody ToDictionary();
    //- podobnie jak dla listy, posortuj dane w dictionary według ASC/DESC
    //TIP: Random words generator: https://www.thewordfinder.com/random-word-generator/
    // + wykorzystanie group by

    class Program
    {
        const string filePath = @"d:\wordsToSort.txt";

        static void Main(string[] args)
        {
            var words = File.ReadAllText(filePath).Split(Environment.NewLine);

            var list = new List<string>(words);

            var dictionary = list.ToDictionary(n => list.IndexOf(n), w => w);

            var listInOrderAsc =
                from l in list
                orderby l.Length
                group l by l.Substring(0, 1) into newList
                orderby newList.Key
                select newList;

            DisplayList(listInOrderAsc);

            var listInOrderDesc =
                from l in list
                orderby l descending
                group l by l.Length into newListDesc
                orderby newListDesc.Key descending
                select newListDesc;

            DisplayList(listInOrderDesc);

            var dictionaryOrder =
               from d in dictionary
               orderby d.Value descending
               group d by d.Value.Length into newDictionary
               orderby newDictionary.Key
               select newDictionary;

            DisplayDictionary(dictionaryOrder);
        }

        static void DisplayDictionary<T>(IOrderedEnumerable<IGrouping<T, KeyValuePair<int, string>>> dictionary)
        {
            foreach (var group in dictionary)
            {
                Console.WriteLine(group.Key);

                foreach (var item in group)
                {
                    Console.WriteLine($"Key: {item.Key}, value: {item.Value}");
                }
            }
            Console.WriteLine();
        }

        static void DisplayList<T>(IOrderedEnumerable<IGrouping<T, string>> list)
        {
            foreach (var group in list)
            {
                Console.WriteLine(group.Key);

                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }
    }
}
