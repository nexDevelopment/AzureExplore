using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace AzureExplore.Views
{
    public class AccountCell : TextCell
    {
        public AccountCell()
        {
            SetBinding(TextProperty, new Binding("Name"));

            TextColor = Color.White;
            
        }
    }
}
