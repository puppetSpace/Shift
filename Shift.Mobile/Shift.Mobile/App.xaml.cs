using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Shift.Mobile
{
    public partial class App : Application
    {
        private static ViewModelLocator _viewModelLocator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _viewModelLocator ?? (_viewModelLocator = new ViewModelLocator());
            }
        }

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTc2MzVAMzEzNjJlMzIyZTMwbHRRV09kVmRMdEZkeWY0OG1jLzdBRUNOSEdqaGFUSWovK1M2MGVueHF5OD0=");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

}
