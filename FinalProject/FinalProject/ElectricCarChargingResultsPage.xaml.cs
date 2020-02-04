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
	public partial class ElectricCarChargingResultsPage : ContentPage
	{
		public ElectricCarChargingResultsPage ()
		{
            // InitializeComponent();
            List<FacilitySearchResult> facilities = new List<FacilitySearchResult>();
            foreach (var f in Globals.facilities)
            {
                if (f.isElectricCarChargingFacility())
                {
                    facilities.Add(new FacilitySearchResult(f.stop_id, f.name));
                }
            }
            string result;
            foreach (var f in Globals.facilities)
            {
                if (Globals.stopIDToNameDictionary.TryGetValue(f.stop_id, out result))
                {
                    f.stop_id = result;
                }
            }
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = facilities,
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label stationLabel = new Label();
                    stationLabel.SetBinding(Label.TextProperty, "stop_id");
                    stationLabel.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
                    stationLabel.FontAttributes = FontAttributes.Bold;
                    stationLabel.BackgroundColor = Color.White;
                    Label facilityLabel = new Label();
                    facilityLabel.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
                    stationLabel.BackgroundColor = Color.White;
                    facilityLabel.SetBinding(Label.TextProperty, "name");

                    BoxView boxView = new BoxView();

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            stationLabel,
                                            facilityLabel
                                        }
                                        }
                                }
                        }
                    };
                })
            };
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    listView
                }
            };
        }
    }
}