using AzureExplore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AzureExplore.Views
{
    class AddAccountPage : ContentPage
    {
        Entry accountInput;
        Entry keyInput;

        public AddAccountPage()
        {
            BackgroundColor = Color.FromHex("#1a1a1a");

            var layout = new StackLayout();
            layout.Padding = 20;

            Label accountLabel = new Label { Text = "Account Name", FontSize = 21, TextColor = Color.White };
            //accountLabel.TextColor = Font.SystemFontOfSize(14, FontAttributes.Bold);
            accountInput = new Entry { Placeholder = "Account", TextColor = Color.Black, Text="jimmygarrido" };
            Label keyLabel = new Label { Text = "Account Key", FontSize = 21, TextColor = Color.White };
            keyInput = new Entry { Placeholder = "Key", TextColor = Color.Black, Text = "tPdoyMB5YopNibic+IxnzzzkYZlIhAa3ojS1gCFY/SRuq4NYcGFN6oypH5SjvPdtgUrICA4tFsMF9w9pSRjBJQ==" };
            Button addBtn = new Button { Text = "Add Account" };
            addBtn.Clicked += AddBtnClicked;

            layout.Children.Add(accountLabel);
            layout.Children.Add(accountInput);
            layout.Children.Add(keyLabel);
            layout.Children.Add(keyInput);
            layout.Children.Add(addBtn);

            Content = layout;
        }

        private void AddBtnClicked(object sender, EventArgs e)
        {
            accountInput.IsEnabled = false;
            keyInput.IsEnabled = false;
            StorageAccounts.AddAccount(accountInput.Text, keyInput.Text);
        }
    }
}
