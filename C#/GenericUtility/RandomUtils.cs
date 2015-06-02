using System;
using System.Text;

namespace GenericUtility
{
    public static class RandomUtils
    {
        private static readonly char[] _numbers = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private static readonly char[] _numberAndLetters = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                                                            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                                            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                                            'u', 'v', 'w', 'x', 'y', 'z'};

        public static string RandumNumericString(int length)
        {
            var random = new Random();
            var builder = new StringBuilder(length);
            for (var i = 0; i < length; ++i)
            {
                builder.Append(_numbers[random.Next(_numbers.Length)]);
            }
            return builder.ToString();
        }

        public static string RandumString(int length)
        {
            var random = new Random();
            var builder = new StringBuilder(length);
            for (var i = 0; i < length; ++i)
            {
                builder.Append(_numberAndLetters[random.Next(_numberAndLetters.Length)]);
            }
            return builder.ToString();
        }
    }
}