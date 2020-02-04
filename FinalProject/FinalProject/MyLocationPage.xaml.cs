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
	public partial class MyLocationPage : ContentPage
	{
		public MyLocationPage ()
		{
			InitializeComponent ();
            MyLatitude.Text = Globals.MyLocation.Latitude.ToString();
            MyLongitude.Text = Globals.MyLocation.Longitude.ToString();
        }
    }
}