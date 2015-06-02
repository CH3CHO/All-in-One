using System;

namespace GenericUtility
{
    public static class DateTimeExtensions
    {
        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddMilliseconds(-1);
        }
    }
}