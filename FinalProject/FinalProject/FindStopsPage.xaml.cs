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
	public partial class FindStopsPage : ContentPage
	{
		public FindStopsPage ()
		{
			InitializeComponent ();
            StopSearchButton.Clicked += async (sender, args) =>
            {
                switch (StopSearchCenter.SelectedIndex)
                {
                    case 0:
                        Globals.SearchLatitude = Globals.MyLocation.Latitude.ToString();
                        Globals.SearchLongitude = Globals.MyLocation.Longitude.ToString();
                        break;
                    case 1:
                        Globals.SearchLatitude = "Specified Lat";
                        Globals.SearchLongitude = "Specified Long";
                        break;
                    case 2:
                        Globals.SearchLatitude = Globals.LatitudeHarvardSquare;
                        Globals.SearchLongitude = Globals.LongitudeHarvardSquare;
                        break;
                    case 3:
                        Globals.SearchLatitude = Globals.LatitudeCopleySquare;
                        Globals.SearchLongitude = Globals.LongitudeCopleySquare;
                        break;
                    case 4:
                        Globals.SearchLatitude = Globals.LatitudeAlewife;
                        Globals.SearchLongitude = Globals.LongitudeAlewife;
                        break;
                    case 5:
                        Globals.SearchLatitude = Globals.LatitudeBraintree;
                        Globals.SearchLongitude = Globals.LongitudeBraintree;
                        break;
                    case 6:
                        Globals.SearchLatitude = Globals.LatitudeFramingham;
                        Globals.SearchLongitude = Globals.LongitudeFramingham;
                        break;
                }
                switch (StopSearchRadius.SelectedIndex)
                {
                    case 0:
                        Globals.SearchRadius = "1";
                        break;
                    case 1:
                        Globals.SearchRadius = "2";
                        break;
                    case 2:
                        Globals.SearchRadius = "5";
                        break;
                    case 3:
                        Globals.SearchRadius = "10";
                        break;
                }

                /*
                 * Retrieve stops within given latitude/longitude/radius.
                 */
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
                await Navigation.PushAsync(new SelectFacilityTypePage());
            };
        }
    }
}