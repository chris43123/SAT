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
    public class DepartamentosController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Departamentos
        public ActionResult Index()
        {
            return View(db.tbDepartamentos.ToList());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dep_Id,dep_Descripcion,dep_UsuarioCrea,dep_FechaCrea,dep_UsuarioModifica,dep_FechaModifica")] tbDepartamentos tbDepartamentos)
        {
            tbDepartamentos.dep_FechaCrea = DateTime.Now;
            tbDepartamentos.dep_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    //Listado para recorrer el tipo complejo
                    IEnumerable<object> Listadepartamentos = null;
                    string MensajeError = "";
                    //Almacenamos la ejecucion del sp
                    Listadepartamentos = db.UDP_Gral_tbDepartamentos_Insert(
                        tbDepartamentos.dep_Id,
                        tbDepartamentos.dep_Descripcion,
                        tbDepartamentos.dep_UsuarioCrea,
                        tbDepartamentos.dep_FechaCrea);
                    //Recuperacion del valor que traemos con nuestro retorno
                    foreach (UDP_Gral_tbDepartamentos_Insert_Result res in Listadepartamentos)
                        MensajeError = res.MensajeError;
                    //Validacion
                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("","1. Ha ocurrido un error durante la inserción del departamento");
                        return View(tbDepartamentos);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    ModelState.AddModelError("", "2. Ha ocurrido un error durante la inserción del departamento");
                    return View(tbDepartamentos);
                }
                //db.tbDepartamentos.Add(tbDepartamentos);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(tbDepartamentos);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dep_Id,dep_Descripcion,dep_UsuarioCrea,dep_FechaCrea,dep_UsuarioModifica,dep_FechaModifica")] tbDepartamentos tbDepartamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbDepartamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbDepartamentos);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            db.tbDepartamentos.Remove(tbDepartamentos);
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
