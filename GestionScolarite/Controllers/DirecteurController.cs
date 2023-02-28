using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionScolarite.Models;

namespace GestionScolarite.Controllers
{
    public class DirecteurController : Controller
    {
        private ScolariteDbContext db = new ScolariteDbContext();

        // GET: Directeur
        public ActionResult Index()
        {
            return View(db.Etudiants);
        }

        // GET: Directeur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Directeur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directeur/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Directeur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Directeur/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,AccoutId,Name,Section")] Etudiant etudiant)
        {
            Etudiant e = db.Etudiants.Find(etudiant.Id);
            e.Section = etudiant.Section;
            if (ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etudiant);
        }        

        // GET: Directeur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Directeur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
