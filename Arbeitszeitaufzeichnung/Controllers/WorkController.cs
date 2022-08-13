using Arbeitszeitaufzeichnung.Models;
using Arbeitszeitaufzeichnung.Models.ViewModels;
using Arbeitszeitaufzeichnung.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Controllers
{

    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            WorkService.CalcWorkTimes(User.GetId());
            var works = WorkService.GetWorkTimes(User.GetId());

            var worksVM = Mapping(works);

            return View(worksVM);
            //return RedirectToAction("Index","Home");
        }

        private List<WorktimeVM> Mapping(List<Worktime> works)
        {
            List<WorktimeVM> worktimeVMs = new List<WorktimeVM>();

            foreach (Worktime worktime in works)
            {
                worktimeVMs.Add(Mapping(worktime));
            }

            return worktimeVMs;
        }

        private WorktimeVM Mapping(Worktime worktime)
        {
            WorktimeVM worktimeVM = new WorktimeVM();

            worktimeVM.Come = worktime.Come;
            worktimeVM.Go = worktime.Go;
            worktimeVM.Id = worktime.Id;
            worktimeVM.Employee = worktime.Employee;
            worktimeVM.EmployeeId = worktime.EmployeeId;
            worktimeVM.LongestBreak = worktime.LongestBreak;
            worktimeVM.MinimumBreak = worktime.MinimumBreak;
            worktimeVM.TotalBreakTime = worktime.TotalBreakTime;
            worktimeVM.WorkTime = worktime.WorkTime;

            return worktimeVM;

        }
    }
}
