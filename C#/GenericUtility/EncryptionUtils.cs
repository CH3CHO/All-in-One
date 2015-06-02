using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GenericUtility
{
    public static class EncryptionUtils
    {
        public static string GetMd5(string text, bool upper = false)
        {
            return GetHash(MD5.Create(), text, upper);
        }

        public static string GetSha1(string text, bool upper = false)
        {
            return GetHash(SHA1.Create(), text, upper);
        }

        private static string GetHash(HashAlgorithm algorithm, string text, bool upper)
        {
            var hashData = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            var hashToStringFormat = upper ? "X2" : "x2";
            return string.Join(string.Empty, hashData.Select(b => b.ToString(hashToStringFormat)));
        }
    }
}