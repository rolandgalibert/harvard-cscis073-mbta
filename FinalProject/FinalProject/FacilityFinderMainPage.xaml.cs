
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MBTADataFeeds;

namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FacilityFinderMainPage : ContentPage
	{
		public FacilityFinderMainPage ()
		{
			InitializeComponent ();
            CarParkingButton.Clicked += async (sender, args) =>
            {
                await runQueries();
                await Navigation.PushAsync(new CarParkingResultsPage());
            };
            ElectricCarChargingButton.Clicked += async (sender, args) =>
            {
                await runQueries();
                await Navigation.PushAsync(new ElectricCarChargingResultsPage());
            };
            BikeParkingButton.Clicked += async (sender, args) =>
            {
                await runQueries();
                await Navigation.PushAsync(new BikeParkingResultsPage());
                // await Navigation.PushAsync(new BikeParkingResultsPage2());
            };
            FarePurchaseButton.Clicked += async (sender, args) =>
            {
                await runQueries();
                await Navigation.PushAsync(new FarePurchasingResultsPage());
            };
        }

        private async Task runQueries()
        {
            /*
             * Retrieve stops within given latitude/longitude/radius.
             */
             if (UseMyLocationSwitch.IsToggled)
            {
                Globals.SearchLatitude = Globals.LatitudeAlewife;
                Globals.SearchLongitude = Globals.LongitudeAlewife;
                Globals.SearchRadius = "1.5";
            } else
            {
                Globals.SearchLatitude = Globals.LatitudeFramingham;
                Globals.SearchLongitude = Globals.LongitudeFramingham;
                Globals.SearchRadius = "10";
            }
            MBTADataFeeds.StopsQuery.clearQueryFilter();
            MBTADataFeeds.StopsQuery.addLatitudeFilter(Globals.SearchLatitude);
            MBTADataFeeds.StopsQuery.addLongitudeFilter(Globals.SearchLongitude);
            MBTADataFeeds.StopsQuery.addRadiusFilter(Globals.SearchRadius);
            MBTADataFeeds.StopsJSON.Rootobject ro = new MBTADataFeeds.StopsJSON.Rootobject();
            ro = await MBTADataFeeds.StopsQuery.ExecuteQuery();
            Globals.stops = MBTADataFeeds.StopsQuery.convertJSONToList(ro);

            /*
             * Retrieve all facilities associated with these stops.
             */
            FacilitiesQuery.clearStopsFilter();
            foreach (var stop in Globals.stops)
            {
                FacilitiesQuery.addStopToFilter(stop.id);
            }
            MBTADataFeeds.FacilitiesJSON.Rootobject facilitiesRO = new MBTADataFeeds.FacilitiesJSON.Rootobject();
            facilitiesRO = await MBTADataFeeds.FacilitiesQuery.ExecuteQuery();
            Globals.facilities = MBTADataFeeds.FacilitiesQuery.convertJSONToList(facilitiesRO);
            /*
             * Show results on new page.
             */

        }
    }
}