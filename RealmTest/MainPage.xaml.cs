using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RealmTest
{
    public partial class MainPage : ContentPage
    {
        string info;
        bool isRefreshing;

        public MainPage()
        {
            InitializeComponent();

            Artists = Realm.GetInstance().All<Artist>();
            BindingContext = this;
        }

        public ICommand RefreshCommand => new Command(async () => await UpdateData());
        public IEnumerable<Artist> Artists { get; }
        public string Info { get => info; set { info = value; OnPropertyChanged(); } }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(!Artists.Any()) await UpdateData();
        }

        async Task UpdateData()
        {
            var artists = new Repository().GetData();
            await Realm.GetInstance().WriteAsync(realm =>
            {
                artists.ForEach(artist => realm.Add(artist, true));
            });
            Info = $"Updated: {DateTime.Now:T}";
            IsRefreshing = false;
        }
    }
}
