using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateUIviaSeparteThread
{
    public static class StringExtensions
    {
        public static string LJ(this string str, int width, char chr = ' ')
        {
            return str.PadRight(width, chr);
        }

        public static string RJ(this string str, int width, char chr = ' ', int rightSpaces = 0)
        {
            return str.PadLeft(width, chr) + "".PadLeft(rightSpaces);
        }

        public static string LJ(this int num, int width, char chr = ' ')
        {
            return num.ToString().LJ(width, chr);
        }

        public static string RJ(this int num, int width, char chr = ' ', int rightSpaces = 0)
        {
            return num.ToString().RJ(width, chr, rightSpaces);
        }

    }

}
