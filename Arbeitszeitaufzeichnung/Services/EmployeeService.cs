using Arbeitszeitaufzeichnung.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Services
{
    public static class EmployeeService
    {
        internal async static Task CreateEmployeeAsync(Employee employee)
        {
            using (var db = new DatabaseContext())
            {
                if (employee != null && !db.Employees.Any(x => x.Email == employee.Email))
                {
                    db.Add(employee);
                    await db.SaveChangesAsync();
                }
            }
        }

        internal static byte GetStatus(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.TimeStamps
                    .Include(t=> t.Status)
                    .OrderBy(o => o.Time)
                    .LastOrDefault(x => x.EmployeeId == id)?.Status.Number ?? 2;
            }
        }

        internal static Guid? GetGuid(string email)
        {
            using (var db = new DatabaseContext())
            {
                if (db.Employees.Any(x => x.Email == email))
                {
                    return db.Employees.SingleOrDefault(x => x.Email == email).Guid;
                }
                return null;
            }
        }

        internal static bool CompareEmployee(Employee employee)
        {
            using (var db = new DatabaseContext())
            {
                if (db.Employees.SingleOrDefault(
                    x => x.Email == employee.Email
                && x.Password == employee.Password) != null)
                {
                    return true;
                }
                return false;
            }
        }

        internal static Employee GetEmployeeByMail(string email)
        {
            using (var db = new DatabaseContext())
            {
                return db.Employees.SingleOrDefault(
                x => x.Email == email);
            }
        }
    }
}
