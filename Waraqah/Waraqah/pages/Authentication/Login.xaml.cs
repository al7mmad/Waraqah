using System;
using System.Collections.Generic;
using System.IO;
using Waraqah.pages;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waraqah.pages.Authentication;
using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.Xaml;
using WaraqahApp.Tables;
using WaraqahApp.Pages.Authentication;
using WaraqahApp.Pages;




namespace Waraqah.pages.Authentication
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            btnLogin.Clicked += btnLogin_Clicked;
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            myWebService.WebServiceDBSoapClient ws = new myWebService.WebServiceDBSoapClient();

        }

        async void Btn1_Clicked(Object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }

            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Failed Username or Password", "OK", "Cancel");

                    if (result)
                        await Navigation.PopModalAsync(new Login());
                    else
                    {
                        await Navigation.PopModalAsync(new Login());
                    }
                });
            }
        }
        async void Btn2(Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync(new Signup());

            
        }
    }
}