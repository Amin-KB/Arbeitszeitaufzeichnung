using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Models
{
    public class Worktime
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public DateTime Come { get; set; }
        public DateTime Go { get; set; }
        public byte MinimumBreak { get; set; }
        public short LongestBreak { get; set; }
        public short WorkTime { get; set; }
        public short TotalBreakTime { get; set; }
    }
}
