using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ScheduleIt2._0.Models;

namespace ScheduleIt2._0.Controllers
{
    public class WorkTimeEventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkTimeEventModel
        public ActionResult Index(string sortOrder, string beginPeriod, string endPeriod)
        {
            //ViewBag variables used so that the view can configure the column heading hyperlinks with appropriate query string values
            //  Using ternary statements
            ViewBag.StartDateSortParm = String.IsNullOrEmpty(sortOrder) ? "start_desc" : "";
            ViewBag.EndDateSortParm = sortOrder == "EndDate" ? "end_desc" : "EndDate";
            ViewBag.TotalHoursSortParm = sortOrder == "TotalHours" ? "hours_desc" : "TotalHours";
           //ApplicationUser user = new ApplicationUser();
            


            // Grabs the current user ID
            var userId = User.Identity.GetUserId();
            // Grabs all events in Db that have the same user ID as the one logging in
            ApplicationUser user = db.Users.Find(userId);
            //Checking for clocked in status
            bool ClockedInStatus = db.WorkTimeEventModels.Any(x => x.User.Id == userId && !x.EndTime.HasValue);
            if (ClockedInStatus == true)
            {
                ViewBag.Status = "Currently Clocked In";
            }
            else
            {
                ViewBag.Status = "Not Clocked In";
            }
            var result = (from t in db.WorkTimeEventModels
                          where t.EventId == t.EventId

                          select new
                          {
                              t.TotalHours

                          }).ToList();
            double sum = 0;
            foreach (var item in result)
            {
                //if (item.TotalHours.HasValue)
                //{
                //    TimeSpan timespan = item.TotalHours.Value;
                //    sum += item.TotalHours.HasValue ? item.TotalHours.Value.TotalMinutes : 0;
                //}
                //else
                //{
                //    return null;
                //}

                //sum += Convert.ToDouble(item.TotalHours);
               // sum += item.TotalHours.HasValue ? item.TotalHours.Value.TotalMinutes : 0;

                ViewBag.ShowSum = sum;
                var projectedpay = Convert.ToDecimal(sum / 60) * user.HourlyRate;
                ViewBag.Pay = projectedpay;
            }
            //var result = (from t in db.WorkTimeEventModels
            //              where t.EventId == t.EventId
            //              group t by t.TotalHours into d
            //              select d).Sum();

            //Using LINQ to Entities method: specify the column to sort by
            //create an IQueryable<T> variable
            var workTimeEvent = from w in db.WorkTimeEventModels
                                select w;


            //pass the sortOrder query string parameter into the switch statement 
            switch (sortOrder)
            {
                case "start_desc":
                    workTimeEvent = workTimeEvent.OrderByDescending(w => w.StartTime);
                    break;
                case "EndDate":
                    workTimeEvent = workTimeEvent.OrderBy(w => w.EndTime);
                    break;
                case "end_desc":
                    workTimeEvent = workTimeEvent.OrderByDescending(w => w.EndTime);
                    break;
                case "TotalHours":
                    workTimeEvent = workTimeEvent.OrderBy(w => w.TotalHours);
                    break;
                case "hours_desc":
                    workTimeEvent = workTimeEvent.OrderByDescending(w => w.TotalHours);
                    break;
                default:
                    workTimeEvent = workTimeEvent.OrderBy(w => w.StartTime);
                    break;
            }
            //note: the query is not executed until the workTimeEvent queryable object is converted into a collection
            //      Therefore, calling ToList is critical
            return View(workTimeEvent.ToList());
        }

        // GET: WorkTimeEventModel/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEventModel workTimeEventModel = db.WorkTimeEventModels.Find(id);
            if (workTimeEventModel == null)
            {
                return HttpNotFound();
            }
            return View(workTimeEventModel);
        }

        // GET: WorkTimeEventModel/Create
        public ActionResult Create()
        {
            return View();
        }


       
        // POST: WorkTimeEventModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClockIn(WorkTimeEventModel workTimeEventModel, LoginViewModel lvm)
        {

             var user = db.Users.SingleOrDefault(x => x.Id == lvm.UserId);

            //maps user from db to current user
            var ClockInTimeEvent = db.EventModels.FirstOrDefault(x => x.User.Id == user.Id);
            // Checks if user is clocked in by checking if any events exist without a endtime
            var WorkTimeEvent = db.EventModels.FirstOrDefault(x => x.User.Id == user.Id && !x.EndTime.HasValue);

            //if user is already clocked in but has no endtime value
            if (ClockInTimeEvent != null && WorkTimeEvent != null)
            {
                //displays message to user *currently using to keep track of methods
                TempData["message"] = "Already clocked in";
                //return RedirectToAction("Login", "Account");
                return RedirectToAction("ClockInPage", "WorkTimeEvent");
            }
            //if a user is not already clocked in, create a new worktimeevent and save to db
            //clock in 
            else
            {
                DateTime start = DateTime.Now;
                var message = "clock in: " +lvm.Message;
                WorkTimeEventModel clockIn = new WorkTimeEventModel(user, message, start);
                db.EventModels.Add(clockIn);
                db.SaveChanges();
                //displays message to user *currently using to keep track of methods
                TempData["message"] = "Clock in: " + DateTime.Now.ToString("h:mm tt") + " Have a great shift " + user.Fname;
                return RedirectToAction("ClockInPage", "WorkTimeEvent");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClockOut(WorkTimeEventModel workTimeEventModel, LoginViewModel lvm)
        {
           
            var user = db.Users.SingleOrDefault(x => x.Id == lvm.UserId);
            var worktime = db.EventModels.FirstOrDefault(x => x.User.Id == user.Id && !x.EndTime.HasValue);
            if (worktime != null)
            {  //Update the current open event with an end datetime.
                //Updates message column in db Event
                worktime.Message += "clock out: " +lvm.Message;
                DateTime endTime = DateTime.Now;
                worktime.EndTime = endTime;
                workTimeEventModel.Clockout();
                db.SaveChanges();
                db.SaveChanges();
                //displays message to user *currently using to keep track of methods
                TempData["message"] = "Clock out: " + DateTime.Now.ToString("h:mm tt") + " Have a great day!";
                return RedirectToAction("ClockInPage", "WorkTimeEvent");
            }
            //displays message to user *currently using to keep track of methods
            else
                TempData["message"] = "Unable to clock out, please clock in to clock out";
            return RedirectToAction("ClockInPage", "WorkTimeEvent");
        }

        public ActionResult ClockInPage()
        {
            var userId = User.Identity.GetUserId();

            LoginViewModel lvm = new LoginViewModel();
            lvm.UserId = userId;
            // Grabs the current user ID

            return View(lvm);
        }

        // GET: WorkTimeEventModel/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEventModel workTimeEventModel = db.WorkTimeEventModels.Find(id);
            if (workTimeEventModel == null)
            {
                return HttpNotFound();
            }
            return View(workTimeEventModel);
        }

        // POST: WorkTimeEventModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,StartTime,EndTime,Message,Title,AdminId")] WorkTimeEventModel workTimeEventModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTimeEventModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workTimeEventModel);
        }

        // GET: WorkTimeEventModel/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEventModel workTimeEventModel = db.WorkTimeEventModels.Find(id);
            if (workTimeEventModel == null)
            {
                return HttpNotFound();
            }
            return View(workTimeEventModel);
        }

        // POST: WorkTimeEventModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WorkTimeEventModel workTimeEventModel = db.WorkTimeEventModels.Find(id);
            db.EventModels.Remove(workTimeEventModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
