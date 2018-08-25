using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public MainPageViewModel()
        {
            Test = "This is a Test";
        }

        public string Test { get; set; }


    }
}
