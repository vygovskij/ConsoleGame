using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp8
{
    public class KeyGeneratorHelper
    {
        public static void GenerateSecretKey(byte[] secretKey)
        {
            var gen = RandomNumberGenerator.Create();
            gen.GetBytes(secretKey);

        }

        public static HMACSHA256 GenerateHmacSha(byte[] secretKey)
        {
            var hmac = new HMACSHA256(secretKey);

            return hmac;
        }
    }
}
