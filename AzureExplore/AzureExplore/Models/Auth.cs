using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;
using System.Security.Cryptography;

namespace AzureExplore.Models
{
    class Auth
    {
        private static string accountKey;
        private static string accountName;
        private static string scheme = "SharedKey";

        public static string SignAuth(string stringToSign, string account, string key)
        {
            accountName = account;
            accountKey = key;
            string signature = String.Empty;

            //Byte[] dataToHmac = System.Text.Encoding.UTF8.GetBytes(stringToSign);
            //HMACSHA256 hash = new HMACSHA256(dataToHmac);
            ////var algorithm = WinRTCrypto.MacAlgorithmProvider.OpenAlgorithm(MacAlgorithm.HmacSha256);
            //CryptographicHash hasher = algorithm.CreateHash(Convert.FromBase64String(accountKey));
            //hasher.Append(dataToHmac);

            //signature = Convert.ToBase64String(hasher.GetValueAndReset());

            using (HMACSHA256 hmacSha256 = new HMACSHA256(Convert.FromBase64String(accountKey)))
            {
                Byte[] dataToHmac = System.Text.Encoding.UTF8.GetBytes(stringToSign);
                signature = Convert.ToBase64String(hmacSha256.ComputeHash(dataToHmac));
            }

            String authorizationHeader = String.Format(
                                            CultureInfo.InvariantCulture,
                                            "{0} {1}:{2}",
                                            scheme,
                                            accountName,
                                            signature 
                                            );

            return authorizationHeader;

            //return signature;
        }
    }
}
