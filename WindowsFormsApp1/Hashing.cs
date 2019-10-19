using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Hashing
    {
        public static string Sha256(string data)
        {
            SHA256 sHA256 = SHA256.Create();
            byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
