using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public static class Excel
    {
        public static DateTime ConvertToDateTime(double excelDate)
        {
            //source: http://www.clear-lines.com/blog/post/Converting-Excel-date-format-to-SystemDateTime.aspx
            if (excelDate < 1) { throw new ArgumentException("Excel date cannot be less than 0!"); }

            DateTime dateOfReference = new DateTime(1900, 1, 1);
            if (excelDate > 60d) { excelDate = excelDate - 2; }
            else { excelDate = excelDate - 1; }
            return dateOfReference.AddDays(excelDate);
        }
    }
}
