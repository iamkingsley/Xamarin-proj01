using myApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace myApp
{
    public class Region
    {
        public int id { get; set; }
        public String Name { get; set; }
    }

    public partial class RegisterPage : ContentPage
    {
        private SQLite.SQLiteAsyncConnection _connection;
        public RegisterPage()
        {
            InitializeComponent();

            _regions = GetRegions();
            foreach (var region in _regions)
                regionPicker.Items.Add(region.Name);

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection(); //returns  the connection to our SQLite database

        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<User>(); //gets or creates the table 'Users'

            //await _connection.Table<User>().ToListAsync(); //get the list of users from the database
            base.OnAppearing();
        }
        private IList<Region> _regions;
        private IList<Region> GetRegions()
        {
            return new List<Region>
            {
                new Region { id=1, Name="Central Region" },
                new Region { id=2, Name="Greater Accra" },
                new Region { id=3, Name="Ashanti Region" },
                new Region { id=4, Name="Eastern Region" },
                new Region { id=5, Name="Western Region" },
                new Region { id=6, Name="Brong Ahafo Region" },
                new Region { id=7, Name="Northen Region" },
                new Region { id=8, Name="Upper East Region" },
                new Region { id=9, Name="Upper West Region" },
                new Region { id=10, Name="Volta Region" }
            };
        }

        void OnSelect(object sender, System.EventArgs e)
        {
            var regionName = regionPicker.Items[regionPicker.SelectedIndex];
            var region = _regions.Single(r => r.Name == regionName);

            DisplayAlert("Selection", region.Name, "OK");
        }

        async void Handle_GoToLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new myApp.LoginPage());
        }

        private void ValidateForm()
        {
            if (UserName.Text == "")
            {
                UserName.TextColor = Color.Red;
                UserName.Text = "value cannot be null";
                return;
            }
            if (FirstName.Text == "")
            {
                FirstName.TextColor = Color.Red;
                FirstName.Text = "value cannot be null";
                return;
            }
            if (LastName.Text == "")
            {
                LastName.TextColor = Color.Red;
                LastName.Text = "value cannot be null";
                return;
            }
            if (Password.Text == "")
            {
                Password.TextColor = Color.Red;
                Password.Text = "value cannot be null";
                return;
            }
            if (Phone.Text == "")
            {
                Phone.TextColor = Color.Red;
                Phone.Text = "value cannot be null";
                return;
            }
            if (regionPicker.SelectedIndex == -1)
            {
                regionPicker.BackgroundColor = Color.Red;
                return;
            }

        }

        void Register(object sender, EventArgs e)
        {
            ValidateForm();

            var user = new User
            {
                username = UserName.Text,
                firstName = FirstName.Text,
                lastName = LastName.Text,
                password = Password.Text,
                phone = Phone.Text,
                region = regionPicker.SelectedIndex
            };

            _connection.InsertAsync(user);
        }
    }
}
