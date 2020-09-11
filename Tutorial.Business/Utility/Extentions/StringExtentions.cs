using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Tutorial.Business.Utility.Extentions
{
    public static class StringExtentions
    {

        public static string GetHashValue(this string input, HashAlgorithm algorithm)
        {
             
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedBytes);
        }


    }
}
