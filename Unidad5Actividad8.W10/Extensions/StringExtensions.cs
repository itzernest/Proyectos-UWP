using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad5Actividad8
{
    public static class StringExtensions
    {
        public static string SafeType(this string s)
        {
            return s;
        }

        public static DateTime? SafeDateTime(this string s)
        {            
            DateTime date;
            if (DateTime.TryParse(s, out date))
            {
                return date;
            }
            return null;
        }
    }
}
