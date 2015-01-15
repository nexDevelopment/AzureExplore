using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AzureExplore.Models
{
    class StorageAccounts
    {
        //static string _account;
        //static string _key;
        //static string stringToSign;
        //static string authSignature;

        public void GetAccounts()
        {

        }

        public async static void AddAccount(string account, string key)
        {
            //_account = account;
            //_key = key;

            //string key = tPdoyMB5YopNibic+IxnzzzkYZlIhAa3ojS1gCFY/SRuq4NYcGFN6oypH5SjvPdtgUrICA4tFsMF9w9pSRjBJQ==;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();

            string stringToSign = String.Format("GET\n"
                                        + "\n" // content encoding
                                        + "\n" // content language
                                        + "\n" // content length
                                        + "\n" // content md5
                                        + "\n" // content type
                                        + "\n" // date
                                        + "\n" // if modified since
                                        + "\n" // if match
                                        + "\n" // if none match
                                        + "\n" // if unmodified since
                                        + "\n" // range
                                        + "x-ms-date:" + DateTime.UtcNow.ToString("R") + "\nx-ms-version:2012-02-12\n" // headers
                                        + "/{0}\ncomp:list", account);

            string authSignature = Auth.SignAuth(stringToSign, account, key);

            client.DefaultRequestHeaders.Add("x-ms-date", DateTime.UtcNow.ToString("R"));
            client.DefaultRequestHeaders.Add("x-ms-version", "2014-02-14");
            client.DefaultRequestHeaders.Add("Authorization", authSignature);

            var response = new HttpResponseMessage();
            string reader;
            XDocument xml = new XDocument();

            try
            {
                response = await client.GetAsync(new Uri("https://jimmygarrido.blob.core.windows.net/?comp=list"));
                response.EnsureSuccessStatusCode();
                reader = await response.Content.ReadAsStringAsync();
                xml = XDocument.Parse(reader);
            }
            catch (Exception)
            {
                //ErrorHandler.NetworkError("Error getting predictions. Check network connection and try again.");
            }
        } 
    }
}
