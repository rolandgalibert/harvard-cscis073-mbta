using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace FinalProject
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            FindStopsButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new FindStopsPage());
                // await Navigation.PushAsync(new SelectFacilityTypePage());
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Globals.MyLocation = Utilities.GetMyLocation().Result;
            if (Globals.MyLocation == null)
            {
                Globals.MyLocation = new Location();
                Globals.MyLocation.Latitude = Globals.LatitudeDefault;
                Globals.MyLocation.Longitude = Globals.LongitudeDefault;
            }
        }
    }
}
