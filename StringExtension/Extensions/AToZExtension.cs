using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringExtension.Enums;

namespace StringExtension.Extensions
{
    public static class AToZExtension
    {
        public static string ChangeAToZ(this string str, LetterTypeEnum.LetterType letterType)
        {
            if (letterType == LetterTypeEnum.LetterType.IgnoreCapitals)
            {
                return str.Replace('a', 'z').Replace('A', 'Z');
            }

            else
            {
                return str.Replace('a', 'z');
            }
        }
    }
}
