using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectFacilityTypePage : ContentPage
	{
		public SelectFacilityTypePage ()
		{
			InitializeComponent ();
            FindCarParkingButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new CarParkingResultsPage());
            };
            FindBikeParkingButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new BikeParkingResultsPage());
                // await Navigation.PushAsync(new BikeParkingResultsPage2());
            };
            FindElectricCarChargingButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new ElectricCarChargingResultsPage());
            };
            FindFarePurchasingButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new FarePurchasingResultsPage());
            };
        }
    }
}