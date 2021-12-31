using System;
using StringExtension.Enums;
using StringExtension.Extensions;

namespace StringExtension
{
    //Napisz metodę extension, która zostanie podpięta pod klasę String i będzie możliwość zamiany liter w napisie
    //"Ala ma kota, Kot ma PSA" wedle następującego założenia:
    //- zamieniamy literę a na z
    //- wielkość znaków ma / nie ma znaczenia (proponuje dodac enum o nazwie LetterType z wartościami AcceptCapitals / IgnoreCapitals)

    class Program
    {
        static void Main(string[] args)
        {
            string myString = "Ala ma kota, Kot ma PSA";
            
            Console.WriteLine(myString.ChangeAToZ(LetterTypeEnum.LetterType.IgnoreCapitals));
            Console.WriteLine(myString.ChangeAToZ(LetterTypeEnum.LetterType.AcceptCapitals));
        }
    }
}
