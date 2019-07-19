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
    public class EscuelasController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Escuelas
        public ActionResult Index()
        {
            var tbEscuelas = db.tbEscuelas.Include(t => t.tbEmpleados).Include(t => t.tbEmpleados1);
            return View(tbEscuelas.ToList());
        }

        // GET: Escuelas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEscuelas tbEscuelas = db.tbEscuelas.Find(id);
            if (tbEscuelas == null)
            {
                return HttpNotFound();
            }
            return View(tbEscuelas);
        }

        // GET: Escuelas/Create
        public ActionResult Create()
        {
            ViewBag.esc_Contacto = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad");
            ViewBag.esc_Director = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad");
            return View();
        }

        // POST: Escuelas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "esc_Id,esc_Codigo,esc_NombreEscuela,esc_Director,esc_Contacto,esc_Telefono,esc_Correo,mun_Id,esc_UsuarioCrea,esc_FechaCrea,esc_UsuarioModifica,esc_FechaModifica")] tbEscuelas tbEscuelas)
        {
            if (ModelState.IsValid)
            {
                
                db.tbEscuelas.Add(tbEscuelas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.esc_Contacto = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbEscuelas.esc_Contacto);
            ViewBag.esc_Director = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbEscuelas.esc_Director);
            return View(tbEscuelas.esc_FechaCrea= DateTime.Now);
        }

        // GET: Escuelas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEscuelas tbEscuelas = db.tbEscuelas.Find(id);
            if (tbEscuelas == null)
            {
                return HttpNotFound();
            }
            ViewBag.esc_Contacto = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbEscuelas.esc_Contacto);
            ViewBag.esc_Director = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbEscuelas.esc_Director);
            return View(tbEscuelas);
        }

        // POST: Escuelas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "esc_Id,esc_Codigo,esc_NombreEscuela,esc_Director,esc_Contacto,esc_Telefono,esc_Correo,mun_Id,esc_UsuarioCrea,esc_FechaCrea,esc_UsuarioModifica,esc_FechaModifica")] tbEscuelas tbEscuelas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEscuelas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.esc_Contacto = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbEscuelas.esc_Contacto);
            ViewBag.esc_Director = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbEscuelas.esc_Director);
            return View(tbEscuelas);
        }

        // GET: Escuelas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEscuelas tbEscuelas = db.tbEscuelas.Find(id);
            if (tbEscuelas == null)
            {
                return HttpNotFound();
            }
            return View(tbEscuelas);
        }

        // POST: Escuelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEscuelas tbEscuelas = db.tbEscuelas.Find(id);
            db.tbEscuelas.Remove(tbEscuelas);
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
