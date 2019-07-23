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
    public class JornadasController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Jornadas
        public ActionResult Index()
        {
            return View(db.tbJornadas.ToList());
        }

        // GET: Jornadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbJornadas tbJornadas = db.tbJornadas.Find(id);
            if (tbJornadas == null)
            {
                return HttpNotFound();
            }
            return View(tbJornadas);
        }

        // GET: Jornadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jornadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jor_Id,jor_Descripcion,jor_UsuarioCrea,jor_FechaCrea,jor_UsuarioModifica,jor_FechaModifica")] tbJornadas tbJornadas)
        {
            tbJornadas.jor_FechaCrea = DateTime.Now;
            tbJornadas.jor_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    //Lista para poder recorrer el tipo complejo
                    IEnumerable<object> listJornadas = null;
                    string MensajeError = "";
                    //almacenamos la ejecución del SP
                    listJornadas = db.UDP_Gral_tbJornadas_Insert(tbJornadas.jor_Descripcion,
                                                                 tbJornadas.jor_UsuarioCrea,
                                                                 tbJornadas.jor_FechaCrea);
                    //Recuperamos el valor que trae nuestro retorno
                    foreach (UDP_Gral_tbJornadas_Insert_Result Res in listJornadas)
                        MensajeError = Res.MensajeError;
                    //Validamos
                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro.");
                        return View(tbJornadas);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro.");
                    return View(tbJornadas);
                }
            }

            return View(tbJornadas);
        }

        // GET: Jornadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbJornadas tbJornadas = db.tbJornadas.Find(id);
            if (tbJornadas == null)
            {
                return HttpNotFound();
            }
            return View(tbJornadas);
        }

        // POST: Jornadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jor_Id,jor_Descripcion,jor_UsuarioCrea,jor_FechaCrea,jor_UsuarioModifica,jor_FechaModifica")] tbJornadas tbJornadas)
        {
            tbJornadas.jor_FechaModifica = DateTime.Now;
            tbJornadas.jor_UsuarioModifica = 2;
            if (ModelState.IsValid)
            {
                db.Entry(tbJornadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbJornadas);
        }

        // GET: Jornadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbJornadas tbJornadas = db.tbJornadas.Find(id);
            if (tbJornadas == null)
            {
                return HttpNotFound();
            }
            return View(tbJornadas);
        }

        // POST: Jornadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbJornadas tbJornadas = db.tbJornadas.Find(id);
            db.tbJornadas.Remove(tbJornadas);
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
