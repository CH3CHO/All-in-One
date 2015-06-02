using System;

namespace GenericUtility
{
    public static class TimeUtils
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToTimestamp(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - Epoch).TotalMilliseconds;
        }

        public static long ToTimestampInSeconds(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - Epoch).TotalSeconds;
        }

        public static DateTime FromTimestamp(long timestamp)
        {
            return Epoch.AddMilliseconds(timestamp).ToLocalTime();
        }
    }
}