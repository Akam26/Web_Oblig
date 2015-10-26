﻿/*
* s198596 Akam Neeson
* s198518 Magnus Molaug
* s198572 Ali Mohammad
* s198574 Marius Strømme    
*/
using System.Text;
using System.Security.Cryptography;

namespace CryptoLib
{
    public static class Encryptor
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for(int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}