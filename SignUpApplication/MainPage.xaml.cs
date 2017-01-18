using SignUpApplication.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SignUpApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Database db;
        public MainPage()
        {
            this.InitializeComponent();
            db = new Database();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(db.login(textUser.Text, textPassword.Password))
            {
                var message = new MessageDialog("Login Successful");
                await message.ShowAsync();
                Frame.Navigate(typeof(BlankPage1));
            }else
            {
                var message = new MessageDialog("Login failed");
                await message.ShowAsync();
            }
        }
    }
}
