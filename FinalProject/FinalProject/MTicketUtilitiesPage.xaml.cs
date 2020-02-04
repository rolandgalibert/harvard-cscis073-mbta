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
	public partial class MTicketUtilitiesPage : ContentPage
	{
		public MTicketUtilitiesPage ()
		{
			InitializeComponent ();
            FacilityFinderButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new FacilityFinderMainPage());
            };
        }
    }
}