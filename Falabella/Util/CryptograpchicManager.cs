using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Util
{
    public class CryptograpchicManager
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Retorna la cadena cifrada
        /// </summary>
        /// <param name="str">Cadena</param>
        /// <returns>Cadena cifrada</returns>
        public static string GetHash(string str)
        {

            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();

        }
    }
}
