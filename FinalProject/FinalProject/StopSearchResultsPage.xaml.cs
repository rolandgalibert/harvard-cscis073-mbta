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
	public partial class StopSearchResultsPage : ContentPage
	{
		public StopSearchResultsPage ()
		{
			InitializeComponent ();
            RecordCount.Text = Globals.facilities.Count.ToString();
            SearchQuery.Text = MBTADataFeeds.FacilitiesQuery.baseURL + MBTADataFeeds.FacilitiesQuery.stopsFilter;
            Stop1.Text = Globals.facilities[0].name;
            Stop2.Text = Globals.facilities[1].name;
        }
    }
}