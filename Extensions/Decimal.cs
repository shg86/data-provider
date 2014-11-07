using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class Decimal
    {
        public static decimal WorktimeFromDatabase(this decimal werktijd)
        {
            return _Afronden(werktijd / 60);
        }

        public static decimal WorktimeToDatabase(this decimal werktijd)
        {
            return _Afronden(werktijd * 60);
        }

        private static decimal _Afronden(decimal werktijd)
        {
            return Math.Round(werktijd, 2);
        }
    }
}
