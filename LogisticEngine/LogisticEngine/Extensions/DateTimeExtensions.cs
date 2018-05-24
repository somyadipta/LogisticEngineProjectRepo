using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LogisticEngine.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToCustomFormat1(this DateTime dateTime)
        {
            return $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month)} {dateTime.Day}, {dateTime.Year}";
        }
    }
}