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
    public class CarrerasController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Carreras
        public ActionResult Index()
        {
            var tbCarreras = db.tbCarreras.Include(t => t.tbEmpleados);
            return View(tbCarreras.ToList());
        }

        // GET: Carreras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarreras tbCarreras = db.tbCarreras.Find(id);
            if (tbCarreras == null)
            {
                return HttpNotFound();
            }
            return View(tbCarreras);
        }

        // GET: Carreras/Create
        public ActionResult Create()
        {
            ViewBag.car_Encargado = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad");
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "car_Id,car_Descripcion,car_Encargado,car_UsuarioCrea,car_FechaCrea,car_UsuarioModifica,car_FechaModifica")] tbCarreras tbCarreras)
        {
            if (ModelState.IsValid)
            {
                db.tbCarreras.Add(tbCarreras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.car_Encargado = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbCarreras.car_Encargado);
            return View(tbCarreras);
        }

        // GET: Carreras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarreras tbCarreras = db.tbCarreras.Find(id);
            if (tbCarreras == null)
            {
                return HttpNotFound();
            }
            ViewBag.car_Encargado = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbCarreras.car_Encargado);
            return View(tbCarreras);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "car_Id,car_Descripcion,car_Encargado,car_UsuarioCrea,car_FechaCrea,car_UsuarioModifica,car_FechaModifica")] tbCarreras tbCarreras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCarreras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.car_Encargado = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbCarreras.car_Encargado);
            return View(tbCarreras);
        }

        // GET: Carreras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarreras tbCarreras = db.tbCarreras.Find(id);
            if (tbCarreras == null)
            {
                return HttpNotFound();
            }
            return View(tbCarreras);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCarreras tbCarreras = db.tbCarreras.Find(id);
            db.tbCarreras.Remove(tbCarreras);
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
