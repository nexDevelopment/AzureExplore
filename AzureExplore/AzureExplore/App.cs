﻿using AzureExplore.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AzureExplore
{
    public class App : Application
    {
        private string account, key; 

        public App ()
        {
            MainPage = new NavigationPage(new AccountListPage());
        }
    }
}
