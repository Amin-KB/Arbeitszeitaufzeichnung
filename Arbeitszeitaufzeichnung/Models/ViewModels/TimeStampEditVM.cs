using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Models.ViewModels
{
    public class TimeStampEditVM
    {
        public int Id { get; set; }
        public DateTime TimePrevious { get; set; }
        public DateTime TimeCurrent { get; set; }
        public DateTime TimeFollowing { get; set; }
    }
}
