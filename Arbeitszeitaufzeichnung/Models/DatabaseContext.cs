using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arbeitszeitaufzeichnung.Models.ViewModels;

namespace Arbeitszeitaufzeichnung.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeStamp> TimeStamps { get; set; }
        public DbSet<StatusCodes> StatusCodes { get; set; }
        public DbSet<Worktime> Worktimes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PC00D861E8AE1B;Initial Catalog=TimeDB;User Id=sa;Password=Admin2019$;");
        }
        public DbSet<Arbeitszeitaufzeichnung.Models.ViewModels.WorktimeVM> WorktimeVM { get; set; }
        
    }
}
