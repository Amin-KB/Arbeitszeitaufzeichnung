using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Models.ViewModels
{
    public class WorktimeVM
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeName
        {
            get
            {
                return Employee.FirstName + " " + Employee.LastName;
            }
        }
        public DateTime Come { get; set; }
        public DateTime Go { get; set; }
        public byte MinimumBreak { get; set; }
        public short LongestBreak { get; set; }
        public short WorkTime { get; set; }
        public short TotalBreakTime { get; set; }
    }
}
