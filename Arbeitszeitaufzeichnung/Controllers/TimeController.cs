using Arbeitszeitaufzeichnung.Models;
using Arbeitszeitaufzeichnung.Models.ViewModels;
using Arbeitszeitaufzeichnung.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Controllers
{
    [Authorize]
    public class TimeController : Controller
    {
        public const int come = 1;
        public const int go = 2;

        public IActionResult Index()
        {
            byte status = EmployeeService.GetStatus(User.GetId());

            ViewBag.Status = status;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(TimeStampVM timeStampVM)
        {
            TimeStamp timeStamp = new TimeStamp();
            timeStamp.EmployeeId = User.GetId();
            timeStamp.Time = timeStampVM.Time;

            TimeService.CreateTime(timeStamp);

            return RedirectToAction(nameof(ListTimes));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var timestamp = TimeService.GetTimeStamp(id);
            var additionalTimeStamps = TimeService.GetSurroundingTimeStamps(id);

            TimeStampEditVM timeStampEditVM = Mapping(additionalTimeStamps);

            return View(timeStampEditVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(TimeStampEditVM timeStampEditVM)
        {
            if (timeStampEditVM.TimeCurrent >= timeStampEditVM.TimePrevious &&
                (timeStampEditVM.TimeCurrent <= timeStampEditVM.TimeFollowing ||
                timeStampEditVM.TimeFollowing == default))
            {
                TimeService.ChangeTime(timeStampEditVM.Id, timeStampEditVM.TimeCurrent); 
            }

            return RedirectToAction(nameof(ListTimes));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var timestamp = TimeService.GetTimeStamp(id);
            var additionalTimeStamp = TimeService.GetAdditionalTimeStamp(id);

            var timestampVM = Mapping(timestamp);
            TimeStampVM additionalTimestampVM = null;
            if (additionalTimeStamp != null)
                additionalTimestampVM = Mapping(additionalTimeStamp);

            List<TimeStampVM> list = new List<TimeStampVM>();
            list.Add(timestampVM);
            if (additionalTimestampVM != null)
                list.Add(additionalTimestampVM); 

            return View(list);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(TimeStampVM timeStampVM)
        {
            var temp = TimeService.GetAdditionalTimeStamp(timeStampVM.Id);
            if (temp != null)
                TimeService.DeleteTimeStamp(temp.Id); 
            TimeService.DeleteTimeStamp(timeStampVM.Id);

            return RedirectToAction(nameof(ListTimes));
        }

        public IActionResult ListTimes()
        {
            List<TimeStamp> timeList = TimeService.GetTimes(User.GetId());

            List<TimeStampVM> timeStampsVM = new List<TimeStampVM>();

            timeStampsVM = Mapping(timeList);

            timeStampsVM = timeStampsVM.OrderBy(t => t.Time).ToList();

            return View(timeStampsVM);
        }

        public IActionResult Come()
        {
            TimeStamp timeStamp = new TimeStamp();

            timeStamp.EmployeeId = User.GetId();
            timeStamp.Status = new StatusCodes() { Number = come };
            timeStamp.Time = DateTime.Now;

            TimeService.AddTimeStamp(timeStamp);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Go()
        {
            TimeStamp timeStamp = new TimeStamp();

            timeStamp.EmployeeId = User.GetId();
            timeStamp.Status = new StatusCodes() { Number = go };
            timeStamp.Time = DateTime.Now;

            TimeService.AddTimeStamp(timeStamp);

            return RedirectToAction(nameof(Index));
        }

        private List<TimeStampVM> Mapping(List<TimeStamp> timeList)
        {
            List<TimeStampVM> timeStampsVM = new List<TimeStampVM>();

            for (int i = 0; i < timeList.Count; i++)
            {
                timeStampsVM.Add(Mapping(timeList[i]));
            }

            return timeStampsVM;
        }

        private TimeStampVM Mapping(TimeStamp timeStamp)
        {
            TimeStampVM timeStampVM = new TimeStampVM();

            timeStampVM.Id = timeStamp.Id;
            timeStampVM.EmployeeId = timeStamp.EmployeeId;
            timeStampVM.Employee = timeStamp.Employee;
            timeStampVM.Status = timeStamp.Status;
            timeStampVM.Time = timeStamp.Time;

            return timeStampVM;
        }

        private TimeStampEditVM Mapping(TimeStamp[] additionalTimeStamps)
        {
            TimeStampEditVM timeStampEditVM = new TimeStampEditVM();
            timeStampEditVM.Id = additionalTimeStamps[1].Id;
            if (additionalTimeStamps[0] != null)
                timeStampEditVM.TimePrevious = additionalTimeStamps[0].Time;
            timeStampEditVM.TimeCurrent = additionalTimeStamps[1].Time;
            if (additionalTimeStamps[2] != null)
                timeStampEditVM.TimeFollowing = additionalTimeStamps[2].Time;
            return timeStampEditVM;
        }
    }
}
