using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AeiMobile
{
    public partial class StorePage : PhoneApplicationPage
    {
        bool menuAbierto = false;
        public StorePage()
        {
            InitializeComponent();
            Menu.Children.Add(new MenuControl());
        }

        private void prueba_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (menuAbierto)
            {
                StoryMenuCerrar.Begin();
                menuAbierto = false;
            }
            else
            {
                StoryMenuAbrir.Begin();
                menuAbierto = true;
            }
        }
    }
}