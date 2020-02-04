using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace FinalProject
{
//	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BikeParkingResultsPage2 : ContentPage
	{
        public BikeParkingResultsPage2()
        {

            InitializeComponent();
            List<FacilitySearchResult> facilities = new List<FacilitySearchResult>();
            foreach (var f in Globals.facilities)
            {
                if (f.isBikeStorage())
                {
                    facilities.Add(new FacilitySearchResult(f.stop_id, f.name));
                }
            }
        }
    }
}