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

        // GET: tbAsignaturas
        public ActionResult Index()
        {
            var tbAsignaturas = db.tbAsignaturas.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbAsignaturas.ToList());
        }

        // GET: tbAsignaturas/Details/5
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

        // GET: tbAsignaturas/Create
        public ActionResult Create() 
        {
            ViewBag.asig_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.asig_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            return View();
        }

        // POST: tbAsignaturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "asig_Id,asig_Descripcion,asig_Semestral,asig_UsuarioCrea,asig_FechaCrea,asig_UsuarioModifica,asig_FechaModifica")] tbAsignaturas tbAsignaturas)
        {
            tbAsignaturas.asig_UsuarioCrea = 2;
            tbAsignaturas.asig_FechaCrea = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<Object> ListAsignaturas = null;
                    string MensajeError = "";
                    ListAsignaturas = db.UDP_Gral_tbAsignaturas_Insert(tbAsignaturas.asig_Descripcion,
                                                                        tbAsignaturas.asig_Semestral,
                                                                        tbAsignaturas.asig_UsuarioCrea,
                                                                        tbAsignaturas.asig_FechaCrea);
                    foreach (UDP_Gral_tbAsignaturas_Insert_Result Res in ListAsignaturas)
                        MensajeError = Res.MensajeError;
                    if(MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("asig_Descripcion", "1. No se pudo ingresar el registro.");
                        return View(tbAsignaturas);
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("asig_Descripcion","2. No se pudo ingresar el registro");
                    return View(tbAsignaturas);
                }
            }

            ViewBag.asig_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAsignaturas.asig_UsuarioCrea);
            ViewBag.asig_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAsignaturas.asig_UsuarioModifica);
            return View(tbAsignaturas);
        }

        // GET: tbAsignaturas/Edit/5
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
            ViewBag.asig_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAsignaturas.asig_UsuarioCrea);
            ViewBag.asig_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAsignaturas.asig_UsuarioModifica);
            return View(tbAsignaturas);
        }

        // POST: tbAsignaturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "asig_Id,asig_Descripcion,asig_Semestral,asig_UsuarioCrea,asig_FechaCrea,asig_UsuarioModifica,asig_FechaModifica")] tbAsignaturas tbAsignaturas)
        {
            tbAsignaturas.asig_FechaModifica = DateTime.Now;
            tbAsignaturas.asig_UsuarioModifica = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<Object> ListAsignaturas = null;
                    string MensajeError = "";
                    ListAsignaturas = db.UDP_Gral_tbAsignaturas_Update(tbAsignaturas.asig_Id,
                                                                        tbAsignaturas.asig_Descripcion,
                                                                        tbAsignaturas.asig_Semestral,
                                                                        tbAsignaturas.asig_UsuarioCrea,
                                                                        tbAsignaturas.asig_FechaCrea,
                                                                        tbAsignaturas.asig_UsuarioModifica,
                                                                        tbAsignaturas.asig_FechaModifica);
                    foreach (UDP_Gral_tbAsignaturas_Update_Result Res in ListAsignaturas)
                        MensajeError = Res.MensajeError;
                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("asig_Descripcion", "1. No se pudo actualizar el registro.");
                        return View(tbAsignaturas);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("asig_Descripcion", "2. No se pudo actualizar el registro");
                    return View(tbAsignaturas);
                }
            }
            ViewBag.asig_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAsignaturas.asig_UsuarioCrea);
            ViewBag.asig_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAsignaturas.asig_UsuarioModifica);
            return View(tbAsignaturas);
        }

        // GET: tbAsignaturas/Delete/5
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

        // POST: tbAsignaturas/Delete/5
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
