using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MBTADataFeeds;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FinalProject
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            Globals.stopIDToNameDictionary = StopIDToNameDictionary.stopIDToNameDictionary();
            MainPage = new NavigationPage(new MTicketMainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
