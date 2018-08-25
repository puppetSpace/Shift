using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Mobile.Models
{
    [AddINotifyPropertyChangedInterface]
    public class WorkShift
    {
        public ShiftType ShiftType { get; set; }

        public DateTime Date { get; set; }

    }

    public enum ShiftType
    {
        None = 0,
        Early = 1,
        Late = 3
    }
}
