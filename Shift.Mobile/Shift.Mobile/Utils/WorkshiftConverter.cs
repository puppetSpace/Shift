using Shift.Mobile.Models;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shift.Mobile.Utils
{
    public static class WorkShiftConverter
    {
        public static CalendarInlineEvent ToCalendarInlineEvent(WorkShift workShift)
        {
            return new CalendarInlineEvent
            {
                StartTime = workShift.Date,
                EndTime = workShift.Date,
                IsAllDay = true,
                Subject = $"Working the {Enum.GetName(typeof(ShiftType), workShift.ShiftType)} shift",
                ClassId = Enum.GetName(typeof(ShiftType), workShift.ShiftType),
                Color = workShift.ShiftType == ShiftType.Early ? Color.FromHex("FEB048") : Color.FromHex("233157")
            };
        }

        public static CalendarEventCollection ToCalendarInlineEvent(IEnumerable<WorkShift> workShifts)
        {
            var collection = new CalendarEventCollection();
            if (workShifts != null && workShifts.Any())
            {
                foreach (var workshift in workShifts)
                    collection.Add(ToCalendarInlineEvent(workshift));
            }

            return collection;
        }
    }
}
