using Arbeitszeitaufzeichnung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Services
{
    public static class StatusCodeService
    {

        public static StatusCodes GetStatus(byte number)
        {
            using (var db = new DatabaseContext())
            {
                return db.StatusCodes.FirstOrDefault(s => s.Number == number);
            }
        }
    }
}
