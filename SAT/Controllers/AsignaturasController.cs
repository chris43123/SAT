using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.Models;

namespace SAT.Controllers
{
    public class AsignaturasController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Asignaturas
        public ActionResult Index()
        {
            return View(db.tbAsignaturas.ToList());
        }

        // GET: Asignaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAsignaturas tbAsignaturas = db.tbAsignaturas.Find(id);
            if (tbAsignaturas == null)
            {
                return HttpNotFound();
            }
            return View(tbAsignaturas);
        }

        // GET: Asignaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asignaturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "asig_Id,asig_Descripcion,asig_Semestral,asig_UsuarioCrea,asig_FechaCrea,asig_UsuarioModifica,asig_FechaModifica")] tbAsignaturas tbAsignaturas)
        {
            if (ModelState.IsValid)
            {
                db.tbAsignaturas.Add(tbAsignaturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbAsignaturas);
        }

        // GET: Asignaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAsignaturas tbAsignaturas = db.tbAsignaturas.Find(id);
            if (tbAsignaturas == null)
            {
                return HttpNotFound();
            }
            return View(tbAsignaturas);
        }

        // POST: Asignaturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "asig_Id,asig_Descripcion,asig_Semestral,asig_UsuarioCrea,asig_FechaCrea,asig_UsuarioModifica,asig_FechaModifica")] tbAsignaturas tbAsignaturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbAsignaturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbAsignaturas);
        }

        // GET: Asignaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAsignaturas tbAsignaturas = db.tbAsignaturas.Find(id);
            if (tbAsignaturas == null)
            {
                return HttpNotFound();
            }
            return View(tbAsignaturas);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbAsignaturas tbAsignaturas = db.tbAsignaturas.Find(id);
            db.tbAsignaturas.Remove(tbAsignaturas);
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
