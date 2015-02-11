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
        ListView listView;

        public AccountListPage()
        {
            listView = new ListView();
            BackgroundColor = Color.FromHex("#1a1a1a");
            
            //Create layout and add listview
            var layout = new StackLayout();
            layout.Children.Add(listView);
            //Set content on layout to fill entire page
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
    
            Content = layout;

            ToolbarItem tbi = null;
            if(Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                    {
                        Navigation.PushAsync(new AddAccountPage());
                    }, 0, 0);
            }
            if(Device.OS == TargetPlatform.Android)
            {
                tbi = new ToolbarItem("+", "", () =>
                    {
                        Navigation.PushAsync(new AddAccountPage());
                    }, 0, 0);
            }
            if(Device.OS == TargetPlatform.WinPhone)
            {
                tbi = new ToolbarItem("Add", "add.png", () =>
                    {
                        Navigation.PushAsync(new AddAccountPage());
                    }, 0, 0);
            }

            ToolbarItems.Add(tbi);
        }
    }
}
