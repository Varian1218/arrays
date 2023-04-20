using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace CSharpExtensions
{
    public static class StringUtils
    {
        public const byte IvSize = 16;
        public const byte KeySize = 32;

        public static string Decrypt(byte[] iv, byte[] key, string value)
        {
            using var aesAlg = Aes.Create();
            aesAlg.IV = iv;
            aesAlg.Key = key;
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using var msDecrypt = new MemoryStream(Convert.FromBase64String(value));
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }

        public static string Encrypt(byte[] iv, byte[] key, string value)
        {
            using var aesAlg = Aes.Create();
            aesAlg.IV = iv;
            aesAlg.Key = key;
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(value);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static int ToHashCode(this string s)
        {
            return s.Aggregate(0, (current, t) => current * 31 + t);
        }
    }
}