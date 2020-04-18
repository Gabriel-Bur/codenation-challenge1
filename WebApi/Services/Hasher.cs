using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public static class Hasher
    {
        public static string Hash(string toHash)
        {
            var data = Encoding.ASCII.GetBytes(toHash);
            var hashData = new SHA1Managed().ComputeHash(data);
            var hash = string.Empty;
            foreach (var b in hashData)
            {
                hash += b.ToString("X2");
            }
            return hash.ToLower();
        }
    }
}
