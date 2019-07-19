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
    public class SeccionesController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Secciones
        public ActionResult Index()
        {
            var tbSecciones = db.tbSecciones.Include(t => t.tbJornadaGrados);
            return View(tbSecciones.ToList());
        }

        // GET: Secciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSecciones tbSecciones = db.tbSecciones.Find(id);
            if (tbSecciones == null)
            {
                return HttpNotFound();
            }
            return View(tbSecciones);
        }

        // GET: Secciones/Create
        public ActionResult Create()
        {
            ViewBag.jgra_Id = new SelectList(db.tbJornadaGrados, "jgra_Id", "jgra_Id");
            return View();
        }

        // POST: Secciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sec_Id,sec_Descripcion,sec_UsuarioCrea,sec_FechaCrea,sec_UsuarioModifica,sec_FechaModifica,jgra_Id")] tbSecciones tbSecciones)
        {
            if (ModelState.IsValid)
            {
                //tbSecciones.sec_FechaCrea = DateTime.Now;             
                db.tbSecciones.Add(tbSecciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jgra_Id = new SelectList(db.tbJornadaGrados, "jgra_Id", "jgra_Id", tbSecciones.jgra_Id);
            return View(tbSecciones);
        }

        // GET: Secciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSecciones tbSecciones = db.tbSecciones.Find(id);
            if (tbSecciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.jgra_Id = new SelectList(db.tbJornadaGrados, "jgra_Id", "jgra_Id", tbSecciones.jgra_Id);
            return View(tbSecciones);
        }

        // POST: Secciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sec_Id,sec_Descripcion,sec_UsuarioCrea,sec_FechaCrea,sec_UsuarioModifica,sec_FechaModifica,jgra_Id")] tbSecciones tbSecciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbSecciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jgra_Id = new SelectList(db.tbJornadaGrados, "jgra_Id", "jgra_Id", tbSecciones.jgra_Id);
            return View(tbSecciones);
        }

        // GET: Secciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSecciones tbSecciones = db.tbSecciones.Find(id);
            if (tbSecciones == null)
            {
                return HttpNotFound();
            }
            return View(tbSecciones);
        }

        // POST: Secciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbSecciones tbSecciones = db.tbSecciones.Find(id);
            db.tbSecciones.Remove(tbSecciones);
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
