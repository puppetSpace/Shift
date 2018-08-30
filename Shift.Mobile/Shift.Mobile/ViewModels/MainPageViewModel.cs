using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shift.Mobile.Data;
using Shift.Mobile.Models;
using Shift.Mobile.Utils;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Shift.Mobile.ViewModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class MainPageViewModel : ViewModelBase
    {
        private WorkShiftsRepository _workShiftsRepository = new WorkShiftsRepository();
        private Dictionary<WorkShift, CalendarInlineEvent> _workshiftCalendar = new Dictionary<WorkShift, CalendarInlineEvent>();
        private bool _isAlreadyLoaded;

        public MainPageViewModel()
        {
            Loaded = new RelayCommand(OnLoaded);
            UnLoaded = new RelayCommand(OnUnLoaded);
            DateChanged = new RelayCommand(OnDateChanged);
        }

        public ICommand Loaded { get; set; }

        public ICommand UnLoaded { get; set; }

        public ICommand DateChanged { get; set; }


        private bool _isEarlyShiftToggled;
        [PropertyChanged.DoNotNotify]
        public bool IsEarlyShiftToggled
        {
            get { return _isEarlyShiftToggled; }
            set
            {
                _isEarlyShiftToggled = value;
                AddOrRemoveShift(ShiftType.Early, isToggled: value);
            }
        }


        private bool _isLateShiftToggled;
        [PropertyChanged.DoNotNotify]
        public bool IsLateShiftToggled
        {
            get { return _isLateShiftToggled; }
            set
            {
                _isLateShiftToggled = value;
                AddOrRemoveShift(ShiftType.Late, isToggled: value);
            }
        }


        public DateTime SelectedDate { get; set; }

        public CalendarEventCollection WorkShifts { get; set; } = new CalendarEventCollection();

        private void OnLoaded()
        {
            if (_isAlreadyLoaded)
                return;

            _workShiftsRepository.Load();

            foreach (var workshift in _workShiftsRepository.Get())
            {
                var inlineCalendarEvent = WorkShiftConverter.ToCalendarInlineEvent(workshift);
                WorkShifts.Add(inlineCalendarEvent);
                _workshiftCalendar.Add(workshift, inlineCalendarEvent);
            }

            OnDateChanged();
            _isAlreadyLoaded = true;
        }

        private void OnUnLoaded()
        {
            _workShiftsRepository.Save();
        }

        private void OnDateChanged()
        {
            var earlyWorkshift = _workShiftsRepository.Get(SelectedDate, ShiftType.Early);
            Set(nameof(IsEarlyShiftToggled), ref _isEarlyShiftToggled, earlyWorkshift != null);

            var lateWorkshift = _workShiftsRepository.Get(SelectedDate, ShiftType.Late);
            Set(nameof(IsLateShiftToggled), ref _isLateShiftToggled, lateWorkshift != null);
        }

        private void AddOrRemoveShift(ShiftType shiftType, bool isToggled)
        {
            var workShift = _workShiftsRepository.Get(SelectedDate, shiftType);
            if (isToggled)
            {
                if (workShift == null)
                {
                    var newWorkShift = new WorkShift { Date = SelectedDate, ShiftType = shiftType };
                    var inlineCalendarEvent = WorkShiftConverter.ToCalendarInlineEvent(newWorkShift);
                    _workShiftsRepository.Insert(newWorkShift);
                    WorkShifts.Add(inlineCalendarEvent);
                    _workshiftCalendar.Add(newWorkShift, inlineCalendarEvent);

                }
            }
            else
            {
                if (workShift != null)
                {
                    var foundCalendarItem = _workshiftCalendar[workShift];
                    _workShiftsRepository.Delete(workShift);
                    WorkShifts.Remove(foundCalendarItem);
                    _workshiftCalendar.Remove(workShift);
                }
            }
        }

    }
}
