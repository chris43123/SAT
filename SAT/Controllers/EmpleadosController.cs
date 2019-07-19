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
    public class EmpleadosController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET:Empleado
        public ActionResult Index()
        {
            var tbEmpleados = db.tbEmpleados.Include(t => t.tbCargos);
            return View(tbEmpleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.carg_Id = new SelectList(db.tbCargos, "carg_Id", "carg_Descripcion");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_Id,emp_Identidad,emp_Nombres,emp_Apellidos,emp_FechaNacimiento,emp_Sexo,emp_Direccion,mun_Id,emp_CorreoElectronico,emp_Telefono,carg_Id,emp_FechaIngreso,emp_FechadeSalida,emp_RazonSalida,emp_UsuarioCrea,emp_FechaCrea,emp_UsuarioModifica,emp_FechaModifica")] tbEmpleados tbEmpleados)
        {
            if (ModelState.IsValid)
            {
                
                db.tbEmpleados.Add(tbEmpleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.carg_Id = new SelectList(db.tbCargos, "carg_Id", "carg_Descripcion", tbEmpleados.carg_Id);
            return View(tbEmpleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.carg_Id = new SelectList(db.tbCargos, "carg_Id", "carg_Descripcion", tbEmpleados.carg_Id);
            return View(tbEmpleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_Id,emp_Identidad,emp_Nombres,emp_Apellidos,emp_FechaNacimiento,emp_Sexo,emp_Direccion,mun_Id,emp_CorreoElectronico,emp_Telefono,carg_Id,emp_FechaIngreso,emp_FechadeSalida,emp_RazonSalida,emp_UsuarioCrea,emp_FechaCrea,emp_UsuarioModifica,emp_FechaModifica")] tbEmpleados tbEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.carg_Id = new SelectList(db.tbCargos, "carg_Id", "carg_Descripcion", tbEmpleados.carg_Id);
            return View(tbEmpleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            db.tbEmpleados.Remove(tbEmpleados);
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
