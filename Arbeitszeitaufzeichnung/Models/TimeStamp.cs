using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Models
{
    public class TimeStamp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }    
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public StatusCodes Status { get; set; }
        public DateTime Time { get; set; }
    }
}
