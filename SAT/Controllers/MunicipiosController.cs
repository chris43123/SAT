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
    public class MunicipiosController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Municipios
        public ActionResult Index()
        {
            var tbMunicipios = db.tbMunicipios.Include(t => t.tbDepartamentos);
            return View(tbMunicipios.ToList());
        }

        // GET: Municipios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipios);
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_Descripcion");
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mun_Id,mun_Descripcion,mun_UsuarioCrea,mun_FechaCrea,mun_UsuarioModifica,mun_FechaModifica,dep_Id")] tbMunicipios tbMunicipios)
        {
            if (ModelState.IsValid)
            {
                tbMunicipios.mun_FechaCrea = DateTime.Now;
                db.tbMunicipios.Add(tbMunicipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_Descripcion", tbMunicipios.dep_Id);
            return View(tbMunicipios);
        }

        // GET: Municipios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_Descripcion", tbMunicipios.dep_Id);
            return View(tbMunicipios);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mun_Id,mun_Descripcion,mun_UsuarioCrea,mun_FechaCrea,mun_UsuarioModifica,mun_FechaModifica,dep_Id")] tbMunicipios tbMunicipios)
        {
            if (ModelState.IsValid)
            {
                tbMunicipios.mun_UsuarioCrea = 1;
                tbMunicipios.mun_FechaCrea = DateTime.Now;
                tbMunicipios.mun_FechaModifica = DateTime.Now;
                db.Entry(tbMunicipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_Descripcion", tbMunicipios.dep_Id);
            return View(tbMunicipios);
        }

        // GET: Municipios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipios);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            db.tbMunicipios.Remove(tbMunicipios);
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
