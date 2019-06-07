using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleIt2._0.Models;

namespace ScheduleIt2._0.Controllers
{
    public class MessageSystemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MessageSystem
        public ActionResult Index()
        {
            return View(db.MessageSystems.ToList());
        }

        // GET: MessageSystem/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageSystem messageSystem = db.MessageSystems.Find(id);
            if (messageSystem == null)
            {
                return HttpNotFound();
            }
            return View(messageSystem);
        }

        // GET: MessageSystem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageSystem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,StartTime,EndTime,Message,Title,AdminId,MessageID,DateSent,DateRead,MessageTitle,Content,UnreadMessage")] MessageSystem messageSystem)
        {
            if (ModelState.IsValid)
            {
                messageSystem.EventId = Guid.NewGuid();
                db.EventModels.Add(messageSystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageSystem);
        }

        // GET: MessageSystem/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageSystem messageSystem = db.MessageSystems.Find(id);
            if (messageSystem == null)
            {
                return HttpNotFound();
            }
            return View(messageSystem);
        }

        // POST: MessageSystem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,StartTime,EndTime,Message,Title,AdminId,MessageID,DateSent,DateRead,MessageTitle,Content,UnreadMessage")] MessageSystem messageSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageSystem);
        }

        // GET: MessageSystem/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageSystem messageSystem = db.MessageSystems.Find(id);
            if (messageSystem == null)
            {
                return HttpNotFound();
            }
            return View(messageSystem);
        }

        // POST: MessageSystem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MessageSystem messageSystem = db.MessageSystems.Find(id);
            db.EventModels.Remove(messageSystem);
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
