using SignUpApplication.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SignUpApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        List<Patient> lstSources = new List<Patient>();
        Patient saveData;

        public BlankPage1()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            lstSources = await Helper.Helper.getAllPatient();
            gridView.ItemsSource = lstSources;
        }

        private void updateView(List<Patient> patients)
        {
            gridView.ItemsSource = null;
            gridView.ItemsSource = patients;

        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Helper.Helper.insertNewPatient(nameTxtField.Text, ageTxtField.Text, sicknessTxtField.Text, allergiesTxtField.Text);
            updateView(await Helper.Helper.getAllPatient());

        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            saveData = e.ClickedItem as Patient;
            nameTxtField.Text = saveData.name;
            ageTxtField.Text = saveData.age;
            sicknessTxtField.Text = saveData.sickness;
            allergiesTxtField.Text = saveData.allergies;

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await Helper.Helper.deleteUser(saveData);
            updateView(await Helper.Helper.getAllPatient());

        }

        private void clearFields()
        {

        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
