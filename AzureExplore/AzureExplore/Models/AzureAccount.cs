using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureExplore.Models
{
    class AzureAccount
    {
        private string _accountName;

        public string Name
        {
            get
            {
                return _accountName;
            }
        }

        AzureAccount() { }

        public AzureAccount(string name)
        {
            _accountName = name;
        }
    }
}
