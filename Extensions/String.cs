using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class String
    {
        /// <summary>
        /// Haalt laatste X karakters van een string op.
        /// </summary>
        public static string Last(this string source, int lengte)
        {
            if (lengte >= source.Length)
                return source;
            return source.Substring(source.Length - lengte);
        }
    }
}
