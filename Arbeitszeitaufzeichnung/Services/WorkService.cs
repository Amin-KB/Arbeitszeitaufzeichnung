using Arbeitszeitaufzeichnung.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Services
{
    // problem bei 6h - 6h30min

    public static class WorkService
    {
        public static List<Worktime> GetWorkTimes(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Worktimes
                    .Include(wt=>wt.Employee)
                    .Where(wt => wt.EmployeeId == id)
                    .OrderBy(wt=> wt.Come)
                    .ToList();
            }
        }

        public static void CalcWorkTimes(int id)
        {
            List<TimeStamp> timeStamps = TimeService.GetTimes(id);

            timeStamps = timeStamps.OrderBy(t => t.Time).ToList();

            while (timeStamps.Count > 0)
            {
                TimeStamp firstTimeStamp = timeStamps.First();
                List<TimeStamp> dayTimeStamps = timeStamps
                    .Where(ts => ts.Time.Date == firstTimeStamp.Time.Date)
                    .ToList();

                Worktime worktime = new Worktime();
                DateTime lastComming = new DateTime();
                DateTime lastGoing = new DateTime();
                short timeInMinWork = 0;
                short timeInMinBreak = 0;
                short maxSingleBreak = 0;

                // Ausgehend davon dass der erste Eintrag ein Kommen und der letzte ein Gehen ist!
                worktime.EmployeeId = id;
                worktime.Come = dayTimeStamps.FirstOrDefault().Time;
                worktime.Go = dayTimeStamps.LastOrDefault().Time;
                // Die Pausenzeit wurde vorerst mal nur mit fixen 30min angenommen
                worktime.MinimumBreak = 30;

                using (var db = new DatabaseContext())
                {
                    for (int i = 0; i < dayTimeStamps.Count; i++)
                    {
                        if (timeStamps[i].Status.Number
                            == db.StatusCodes.SingleOrDefault(sc => sc.Name == "Kommen").Number)
                        {
                            short temp;
                            lastComming = timeStamps[i].Time;
                            if (i == 0)
                                continue;
                            temp = (short)((timeStamps[i].Time - lastGoing).TotalMinutes);
                            timeInMinBreak += temp;

                            if (maxSingleBreak < temp)
                            {
                                maxSingleBreak = temp;
                            }
                        }
                        else
                        {
                            lastGoing = timeStamps[i].Time;
                            timeInMinWork += (short)((timeStamps[i].Time - lastComming).TotalMinutes);
                        }
                    }


                    worktime.WorkTime = timeInMinWork;
                    worktime.TotalBreakTime = timeInMinBreak;
                    worktime.LongestBreak = maxSingleBreak;

                    if(worktime.LongestBreak < worktime.MinimumBreak && worktime.WorkTime > 360)
                    {
                        short diff = (short)(worktime.MinimumBreak - worktime.LongestBreak);
                        worktime.WorkTime -= diff;
                        worktime.TotalBreakTime += diff;
                        worktime.LongestBreak += diff;
                    }

                    if (!db.Worktimes.Any(wt => wt.Come.Date == worktime.Come.Date))
                    {// Add to DB weil noch nicht in der DB
                        db.Worktimes.Add(worktime);
                    }
                    else
                    {// Change in DB weil bereits in der DB
                        var wt = db.Worktimes
                            .SingleOrDefault(wt => wt.Come.Date == worktime.Come.Date && wt.EmployeeId == id);

                        wt.Come = worktime.Come;
                        wt.Go = worktime.Go;
                        wt.WorkTime = worktime.WorkTime;
                        wt.TotalBreakTime = worktime.TotalBreakTime;
                        wt.MinimumBreak = worktime.MinimumBreak;
                        wt.LongestBreak = worktime.LongestBreak;
                    }
                    db.SaveChanges();
                }

                // entferne alle einträge von diesem Tag

                timeStamps.RemoveAll(ts=> ts.Time.Date == worktime.Come.Date);
            }
        }
    }
}
