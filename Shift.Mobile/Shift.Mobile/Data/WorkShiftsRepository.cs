using Newtonsoft.Json;
using Shift.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shift.Mobile.Data
{
    public class WorkShiftsRepository
    {
        private readonly string _dataFilePath;
        private List<WorkShift> _workShifts = new List<WorkShift>();

        public WorkShiftsRepository()
        {
            _dataFilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "shifts.json");
            if (!System.IO.File.Exists(_dataFilePath))
                System.IO.File.Create(_dataFilePath).Dispose();
        }


        public IReadOnlyCollection<WorkShift> Get()
        {
            return _workShifts;
        }

        public IReadOnlyCollection<WorkShift> Get(DateTime date)
        {
            return _workShifts.Where(x => x.Date.Date == date.Date).ToList();
        }

        public WorkShift Get(DateTime date, ShiftType shiftType)
        {
            return _workShifts.FirstOrDefault(x => x.Date.Date == date.Date && x.ShiftType == shiftType);
        }

        public void Insert(WorkShift workShift)
        {
            _workShifts.Add(workShift);
        }

        public void Delete(WorkShift workShift)
        {
            _workShifts.Remove(workShift);
        }

        public void Load()
        {
            var content = System.IO.File.ReadAllText(_dataFilePath);
            if (content == null || String.IsNullOrWhiteSpace(content))
                return;

            _workShifts = JsonConvert.DeserializeObject<List<WorkShift>>(content) ?? new List<WorkShift>();

        }

        internal void Save()
        {
            var content = JsonConvert.SerializeObject(_workShifts);
            System.IO.File.WriteAllText(_dataFilePath, content);
        }
    }
}
