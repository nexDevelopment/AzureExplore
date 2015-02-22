using AzureExplore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AzureExplore.Views
{
    public class AccountListPage : ContentPage
    {
        public AccountListPage()
        {
            AzureAccount[] test = { new AzureAccount("jimmygarrido"), new AzureAccount("xamarin"), new AzureAccount("shared") };
            Title = "AzureExplore";
            BackgroundColor = Color.FromHex("#1a1a1a");

            ListView accountList = new ListView { ItemsSource = test, ItemTemplate = new DataTemplate(typeof(AccountCell)) };

            Label header = new Label { Text = "Select Account", TextColor = Color.FromHex("#00abec") };

            //Set header size
            if(Device.OS == TargetPlatform.Android)
            {
                header.FontSize = 24;
            }
            else if (Device.OS == TargetPlatform.WinPhone)
            {
                header.FontSize = 36;
            }

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { header, accountList},
                Padding = new Thickness(15,5,0,0)
            };

            ToolbarItem tbi = null;

            if(Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                    {
                        Navigation.PushModalAsync(new AddAccountPage());
                    }, 0, 0);
            }
            if(Device.OS == TargetPlatform.Android)
            {
                tbi = new ToolbarItem("+", "", () =>
                    {
                        Navigation.PushModalAsync(new AddAccountPage());
                    }, 0, 0);
            }
            if(Device.OS == TargetPlatform.WinPhone)
            {
                tbi = new ToolbarItem("Add", "add.png", () =>
                    {
                        Navigation.PushModalAsync(new AddAccountPage());
                    }, 0, 0);
            }

            ToolbarItems.Add(tbi);
        }
    }
}
