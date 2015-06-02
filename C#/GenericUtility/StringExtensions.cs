namespace GenericUtility
{
    public static class StringExtensions
    {
        public static int ToInt(this string text)
        {
            int value;
            int.TryParse(text, out value);
            return value;
        }

        public static long ToLong(this string text)
        {
            long value;
            long.TryParse(text, out value);
            return value;
        }
    }
}