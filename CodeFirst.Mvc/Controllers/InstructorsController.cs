using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.ReverseEngineered.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using CodeFirst.Mvc.Models;

namespace CodeFirst.Mvc.Controllers
{
    public class InstructorsController : Controller
    {
        private SchoolContext db;

        internal InstructorsController(SchoolContext context)
        {
            db = context;
        }

        public InstructorsController() : 
            this(new SchoolContext())
        {
        }

        // GET: Instructors
        public ActionResult Index()
        {
            var people = db.People.OfType<Instructor>().Include(i => i.OfficeAssignment);
            return View(people.ToList());
        }

        // GET: Instructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.People.Find(id) as Instructor;
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "InstructorID", "Location");
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,LastName,FirstName,HireDate")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.PersonID);
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.People.Find(id) as Instructor;
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.PersonID);
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,LastName,FirstName,HireDate,Timestamp")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    string errors = string.Join(Environment.NewLine, ex.EntityValidationErrors.SelectMany(s => s.ValidationErrors).Select(s => string.Format("{0}: {1}", s.PropertyName, s.ErrorMessage)));
                    Debug.WriteLine(errors);

                    throw;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return View("Concurrency", new InstructorConcurrencyResolve { Current = instructor, Database = ex.Entries.First().GetDatabaseValues().ToObject() as Instructor });
                }
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.OfficeAssignments, "InstructorID", "Location", instructor.PersonID);
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.People.Find(id) as Instructor;
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.People.Find(id) as Instructor;
            db.People.Remove(instructor);
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
