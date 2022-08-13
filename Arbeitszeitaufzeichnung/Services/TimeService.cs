using Arbeitszeitaufzeichnung.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Services
{
    public static class TimeService
    {
        public static void AddTimeStamp(TimeStamp timeStamp)
        {
            using (var db = new DatabaseContext())
            {
                timeStamp.Status = db.StatusCodes.FirstOrDefault(s => s.Number == timeStamp.Status.Number);
                //timeStamp.StatusId = timeStamp.Status.Id;

                db.TimeStamps.Add(timeStamp);
                db.SaveChanges();
            }
        }

        internal static List<TimeStamp> GetTimes(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.TimeStamps.Where(t => t.EmployeeId == id)
                    .Include(t => t.Employee)
                    .Include(t => t.Status)
                    .ToList();
            }
        }

        internal static TimeStamp GetTimeStamp(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.TimeStamps.Where(t => t.Id == id)
                    .Include(t => t.Employee)
                    .Include(t => t.Status)
                    .SingleOrDefault();
            }
        }

        internal static void CreateTime(TimeStamp timeStamp)
        {
            using (var db = new DatabaseContext())
            {
                var col = db.TimeStamps.Where(t => t.EmployeeId == timeStamp.EmployeeId)
                    .Include(t => t.Employee)
                    .Include(t => t.Status);

                if (timeStamp.Time > col.OrderBy(c => c.Time).LastOrDefault().Time)
                    return;

                if (!col.Any(
                    c => c.EmployeeId == timeStamp.EmployeeId
                        && (c.Time == timeStamp.Time
                        || c.Time == timeStamp.Time.AddMilliseconds(1))
                        )
                    )
                {
                    TimeStamp timeStampTempFrist = new TimeStamp();
                    TimeStamp timeStampTempSecond = new TimeStamp();

                    int userLastTimeStatus = 0;

                    timeStampTempFrist.EmployeeId = timeStamp.EmployeeId;
                    timeStampTempSecond.EmployeeId = timeStamp.EmployeeId;

                    if (col
                                        .OrderBy(c => c.Time)
                                        .Any(c => c.Time < timeStamp.Time)
                        )
                    {
                        userLastTimeStatus = col
                                        .OrderBy(c => c.Time)
                                        .Where(c => c.Time < timeStamp.Time)
                                        .LastOrDefault().StatusId; 
                    }

                    var statusCodeNumberKommen = db.StatusCodes
                        .Where(s => s.Name == "Kommen")
                        .FirstOrDefault().Number;

                    var statusCodeNumberGehen = db.StatusCodes
                        .Where(s => s.Name == "Gehen")
                        .FirstOrDefault().Number;

                    if (userLastTimeStatus == statusCodeNumberKommen)
                    {
                        timeStampTempFrist.StatusId = db.StatusCodes
                            .Where(s => s.Name == "Gehen")
                            .FirstOrDefault().Number;
                        timeStampTempSecond.StatusId = db.StatusCodes
                            .Where(s => s.Name == "Kommen")
                            .FirstOrDefault().Number;
                    }
                    else
                    {
                        timeStampTempFrist.StatusId = db.StatusCodes
                            .Where(s => s.Name == "Kommen")
                            .FirstOrDefault().Number;
                        timeStampTempSecond.StatusId = db.StatusCodes
                            .Where(s => s.Name == "Gehen")
                            .FirstOrDefault().Number;
                    }

                    timeStampTempFrist.Time = timeStamp.Time;
                    timeStampTempSecond.Time = timeStamp.Time.AddMilliseconds(1);

                    db.TimeStamps.Add(timeStampTempFrist);
                    db.TimeStamps.Add(timeStampTempSecond);
                    db.SaveChanges();
                }
            }
        }

        internal static void ChangeTime(int id, DateTime timeCurrent)
        {
            using (var db = new DatabaseContext())
            {
                var ts = db.TimeStamps.Where(t => t.Id == id)
                    .Include(t => t.Employee)
                    .Include(t => t.Status)
                    .SingleOrDefault();

                ts.Time = timeCurrent;
                db.SaveChanges();
            }
        }

        internal static void DeleteTimeStamp(int id)
        {
            using (var db = new DatabaseContext())
            {
                var timeStamp = db.TimeStamps.Where(t => t.Id == id)
                    .Include(t => t.Employee)
                    .Include(t => t.Status)
                    .SingleOrDefault();

                db.TimeStamps.Remove(timeStamp);
                db.SaveChanges();
            }
        }

        public static TimeStamp GetAdditionalTimeStamp(int id)
        {
            TimeStamp additionalTimestamp = null;

            using (var db = new DatabaseContext())
            {

                var timeStamp = db.TimeStamps.Where(t => t.Id == id)
                    .Include(t => t.Employee)
                    .Include(t => t.Status)
                    .SingleOrDefault();
                List<TimeStamp> allTimes = db.TimeStamps
                    .Include(t => t.Employee)
                    .Include(t => t.Status)
                    .Where(t => t.EmployeeId == timeStamp.EmployeeId)
                    .ToList();

                allTimes = allTimes.OrderBy(o => o.Time).ToList();

                //if(timeStamp.Status == )
                for (int i = 0; i < allTimes.Count; i++)
                {
                    int index = 0;

                    if (allTimes[i].Id == timeStamp.Id)
                    {
                        if (timeStamp.Status.Number == 1)// Status == Kommen
                        {
                            index = i + 1;
                        }
                        else if (timeStamp.Status.Number == 2)// Status == Gehen
                        {
                            index = i - 1;
                        }

                        if (index >= 0 && index < allTimes.Count)
                        {
                            additionalTimestamp = allTimes[index];
                            return additionalTimestamp;
                        }
                    }
                }

                return null;
            }
        }

        public static TimeStamp[] GetSurroundingTimeStamps(int id)
        {
            TimeStamp[] additionalTimestampArray = new TimeStamp[3];

            using (var db = new DatabaseContext())
            {

                var timeStamp = db.TimeStamps.Where(t => t.Id == id)
                    .Include(t => t.Employee)
                    .Include(t => t.Status)
                    .SingleOrDefault();
                List<TimeStamp> allTimes = db.TimeStamps
                    .Include(t => t.Employee)
                    .Include(t => t.Status)
                    .Where(t => t.EmployeeId == timeStamp.EmployeeId)
                    .ToList();

                allTimes = allTimes.OrderBy(o => o.Time).ToList();

                //if(timeStamp.Status == )
                for (int i = 0; i < allTimes.Count; i++)
                {
                    int index = 0;

                    if (allTimes[i].Id == timeStamp.Id)
                    {
                        index = i;

                        if (index >= 0 && index < allTimes.Count)
                        {
                            if (index - 1 >= 0)
                            {
                                additionalTimestampArray[0] = allTimes[index - 1]; 
                            }

                            additionalTimestampArray[1] = allTimes[index];

                            if (index + 1 < allTimes.Count)
                            {
                                additionalTimestampArray[2] = allTimes[index + 1]; 
                            }

                            return additionalTimestampArray;
                        }
                    }
                }

                return null;
            }
        }
    }
}
