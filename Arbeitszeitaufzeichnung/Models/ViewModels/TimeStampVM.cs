using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Models.ViewModels
{
    public class TimeStampVM
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
        public StatusCodes Status { get; set; }
        public DateTime Time { get; set; }
    }
}
