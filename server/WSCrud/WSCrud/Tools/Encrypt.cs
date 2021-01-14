using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace WSCrud.Tools
{
    public class Encrypt
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] strem = null;
            StringBuilder sb = new StringBuilder();
            strem = sha256.ComputeHash(encoding.GetBytes(str));

            for (int i = 0; i < strem.Length; i++)
            {
                sb.AppendFormat("{0:x2}", strem[i]);
            }

            return sb.ToString();
        }
    }
}
