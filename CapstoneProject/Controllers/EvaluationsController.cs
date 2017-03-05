﻿using System.Linq;
using System.Net;
using System.Web.Mvc;
using CapstoneProject.DAL;
using CapstoneProject.Models;

namespace CapstoneProject.Controllers
{
    [Authorize]
    public class EvaluationsController : Controller
    {
        private DataContext db = new DataContext();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Evaluations
        public ActionResult Index()
        {
            //var evaluations = db.Evaluations.Include(e => e.Employee);
            var evaluations = unitOfWork.EvaluationRepository.Get();
            return View("Index", evaluations.ToList());
        }

        // GET: Evaluations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var evaluation = db.Evaluations.Find(id);
            var evaluation = unitOfWork.EvaluationRepository.GetByID(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // GET: Evaluations/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            return View("Create");
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvaluationID,Stage,Type,EmployeeID")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                //db.Evaluations.Add(evaluation);
                //db.SaveChanges();
                this.unitOfWork.EvaluationRepository.Insert(evaluation);
                this.unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", evaluation.EmployeeID);
            return View("Create", evaluation);
        }

        // GET: Evaluations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var evaluation = db.Evaluations.Find(id);
            var evaluation = unitOfWork.EvaluationRepository.GetByID(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", evaluation.EmployeeID);
            return View("Edit", evaluation);
        }

        // POST: Evaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluationID,Stage,Type,EmployeeID")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(evaluation).State = EntityState.Modified;
                //db.SaveChanges();
                this.unitOfWork.EvaluationRepository.Update(evaluation);
                this.unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", evaluation.EmployeeID);
            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var evaluation = db.Evaluations.Find(id);
            var evaluation = this.unitOfWork.EvaluationRepository.GetByID(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //var evaluation = db.Evaluations.Find(id);
            //db.Evaluations.Remove(evaluation);
            //db.SaveChanges();
            var evaluation = unitOfWork.EvaluationRepository.GetByID(id);
            this.unitOfWork.EvaluationRepository.Delete(evaluation);
            this.unitOfWork.Save();
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
