using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shift.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.MainPageViewModel;
        }

        //protected override void OnAppearing()
        //{
        //    App.Locator.MainPageViewModel.Loaded.Execute(null);
        //}
    }
}
