using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorialMVC.Models;

namespace TutorialMVC.Controllers
{
    [Authorize]
    public class StudiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Studies
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userStudies = db.Studies.Where(p => p.UserId == currentUserId).ToList();
            return View(userStudies);
            //return View(db.Studies.ToList());
        }

        // GET: Studies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study study = db.Studies.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((study.UserId != currentUserId) || (study == null))
            {
                return HttpNotFound();
            }
            return View(study);
        }

        // GET: Studies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudyID,FirstName,Type,Address,GoogleMap,UserId")] Study study)
        {
            string currentUserId = User.Identity.GetUserId();
            study.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Studies.Add(study);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(study);
        }

        // GET: Studies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study study = db.Studies.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((study.UserId != currentUserId) || (study == null))
            {
                return HttpNotFound();
            }
            return View(study);
        }

        // POST: Studies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudyID,FirstName,Type,Address,GoogleMap,UserId")] Study study)
        {
            string currentUserId = User.Identity.GetUserId();
            study.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(study).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(study);
        }

        // GET: Studies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study study = db.Studies.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((study.UserId != currentUserId) || (study == null))
            {
                return HttpNotFound();
            }
            return View(study);
        }

        // POST: Studies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Study study = db.Studies.Find(id);
            db.Studies.Remove(study);
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
