using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GestionScolarite;
using GestionScolarite.Models;

namespace GestionScolarite.Controllers
{
    public class AffectationsController : Controller
    {
        private ScolariteDbContext db = new ScolariteDbContext();

        // GET: Affectations
        public ActionResult Index()
        {
            return View(db.Enseignants.Include(m=>m.Matieres).ToList());
        }

        // GET: Affectations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseignant ens = db.Enseignants.Include(e => e.Matieres).FirstOrDefault(e => e.EnseignantId == id);
            if (ens == null)
            {
                return HttpNotFound();
            }
            return View(ens);
        }

        // GET: Affectations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Affectation affectation = db.Affectations.Find(id);
            if (affectation == null)
            {
                return HttpNotFound();
            }
            return View(affectation);
        }

        // POST: Affectations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MatiereId,EnseignantId")] Affectation affectation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(affectation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(affectation);
        }

        // GET: Affectations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enseignant enseignant = db.Enseignants.Find(id);
            if (enseignant == null)
            {
                return HttpNotFound();
            }
            return View(enseignant);
        }

        // POST: Affectations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var enseignant = db.Enseignants.Include(e => e.Matieres).FirstOrDefault(e => e.EnseignantId == id);

            enseignant.Matieres.Clear();
            
                  db.SaveChanges();
           
            
            
            return RedirectToAction("Index");
        }
        // GET: Enseignant/AddMatiereToEnseignant/5
        public ActionResult AddMatiereToEnseignant()
        {

            
            var matieres = db.Matieres.ToList();
            var enseignants = db.Enseignants.ToList();

            ViewBag.Matieres = new SelectList(matieres, "MatiereId", "Name");
            ViewBag.Enseignants = new SelectList(enseignants, "EnseignantId", "Name");
            List<String> list = db.Etudiants.Select(e => e.Section).Distinct().ToList();
            ViewBag.Sections = new SelectList(list, "Section", "Name");


            return View();
        }

        // POST: Enseignant/AddMatiereToEnseignant/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMatiereToEnseignant(int enseignantid, int matiereId)
        {
            var enseignant = db.Enseignants.Include(e => e.Matieres).FirstOrDefault(e => e.EnseignantId == enseignantid);
            var matiere = db.Matieres.FirstOrDefault(m => m.MatiereId == matiereId);

            if (enseignant == null || matiere == null)
            {
                return HttpNotFound();
            }

            enseignant.Matieres.Add(matiere);
           //enseignant.Sections.Add(section);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
     
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
