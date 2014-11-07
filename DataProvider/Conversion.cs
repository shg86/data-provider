using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataProvider
{
    public static class Conversion
    {
        public static DateTime? ReadNullableDatetime(string field, IDataRecord data)
        {
            var input = data[field];
            if (input != DBNull.Value)
            {
                return Convert.ToDateTime(input);
            }

            return null;
        }

        public static string ReadNullableString(string field, IDataRecord data)
        {
            var input = data[field];
            if (input != DBNull.Value)
            {
                return Convert.ToString(input).Trim();
            }

            return null;
        }

        public static decimal ReadNullableDecimal(string field, IDataRecord data)
        {
            var input = data[field];
            if (input != DBNull.Value)
            {
                return Convert.ToDecimal(input);
            }

            return 0;
        }

        public static bool ReadNullableBool(string field, IDataRecord data)
        {
            var input = data[field];

            if (input != DBNull.Value)
            {
                return Convert.ToBoolean(input);
            }

            return false;
        }
    }
}
