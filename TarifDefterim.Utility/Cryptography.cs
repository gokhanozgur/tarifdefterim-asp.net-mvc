using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TarifDefterim.Utility
{
    public class Cryptography
    {

        public static string ToMD5(string text)
        {
            
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] array = Encoding.UTF8.GetBytes(text);

            array = md5.ComputeHash(array);

            StringBuilder sb = new StringBuilder();

            foreach (byte ba in array)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            
            return sb.ToString();
        }

    }

}
