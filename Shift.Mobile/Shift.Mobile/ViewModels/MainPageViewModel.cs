using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shift.Mobile.Data;
using Shift.Mobile.Models;
using Shift.Mobile.Utils;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shift.Mobile.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class MainPageViewModel : ViewModelBase
    {
        private WorkShiftsRepository _workShiftsRepository = new WorkShiftsRepository();

        public MainPageViewModel()
        {
            Loaded = new RelayCommand(OnLoaded);
            DateChanged = new RelayCommand(OnDateChanged);
        }

        public ICommand Loaded { get; set; }

        public ICommand DateChanged { get; set; }


        private bool _isEarlyShiftToggled;
        [PropertyChanged.DoNotNotify]
        public bool IsEarlyShiftToggled
        {
            get { return _isEarlyShiftToggled; }
            set
            {
                //todo
            }
        }


        private bool _isLateShiftToggled;
        [PropertyChanged.DoNotNotify]
        public bool IsLateShiftToggled
        {
            get { return _isLateShiftToggled; }
            set
            {
                //todo
            }
        }


        public DateTime SelectedDate { get; set; }

        public CalendarEventCollection WorkShifts { get; set; }

        private void OnLoaded()
        {
            _workShiftsRepository.Load();
            WorkShifts = WorkShiftConverter.ToCalendarInlineEvent(_workShiftsRepository.Get());
        }

        private void OnDateChanged()
        {
            Debug.WriteLine(SelectedDate);
        }

    }
}
