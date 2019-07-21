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
    public class CargosController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Cargos
        public ActionResult Index()
        {
            var tbCargos = db.tbCargos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbCargos.ToList());
        }

        // GET: Cargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargos tbCargos = db.tbCargos.Find(id);
            if (tbCargos == null)
            {
                return HttpNotFound();
            }
            return View(tbCargos);
        }

        // GET: Cargos/Create
        public ActionResult Create()
        {
            ViewBag.carg_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.carg_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carg_Id,carg_Descripcion,carg_UsuarioCrea,carg_FechaCrea,carg_UsuarioModifica,carg_FechaModifica")] tbCargos tbCargos)
        {
            tbCargos.carg_FechaCrea = DateTime.Now;
            tbCargos.carg_UsuarioCrea = 2;
            if(ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listcargos = null;
                    string MensajeError = "";
                    listcargos = db.UDP_Gral_tbCargos_Insert(tbCargos.carg_Descripcion,
                                                           tbCargos.carg_UsuarioCrea,
                                                           tbCargos.carg_FechaCrea);
                    foreach (UDP_Gral_tbCargos_Insert_Result RES in listcargos)
                    {
                        MensajeError = RES.MensajeError;
                    }
                    if(MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro ");
                        //return View(tbCargos);
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro");
                    return View(tbCargos);
                }
            }
            return View(tbCargos);
            //if (ModelState.IsValid)
            //{
            //    db.tbCargos.Add(tbCargos);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.carg_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbCargos.carg_UsuarioCrea);
            //ViewBag.carg_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbCargos.carg_UsuarioModifica);
            //return View(tbCargos);
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargos tbCargos = db.tbCargos.Find(id);
            if (tbCargos == null)
            {
                return HttpNotFound();
            }
            ViewBag.carg_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbCargos.carg_UsuarioCrea);
            ViewBag.carg_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbCargos.carg_UsuarioModifica);
            return View(tbCargos);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carg_Id,carg_Descripcion,carg_UsuarioCrea,carg_FechaCrea,carg_UsuarioModifica,carg_FechaModifica")] tbCargos tbCargos)
        {
            tbCargos.carg_FechaModifica = DateTime.Now;
            tbCargos.carg_UsuarioModifica = 2;
            if(ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listcargos = null;
                    string MensajeError = "";
                    listcargos = db.UDP_Gral_tbCargos_Update(tbCargos.carg_Id,
                                                           tbCargos.carg_Descripcion,
                                                           tbCargos.carg_UsuarioCrea,
                                                           tbCargos.carg_FechaCrea,
                                                           tbCargos.carg_UsuarioModifica,
                                                           tbCargos.carg_FechaModifica);
                    foreach(UDP_Gral_tbCargos_Update_Result RES in listcargos)
                    {
                        MensajeError = RES.MensajeError;
                    }
                    if (!string.IsNullOrEmpty(MensajeError))
                    {
                        if (MensajeError.StartsWith("-1"))
                        {
                            ModelState.AddModelError("", "1. No se pudo editar el registro");
                            return View(tbCargos);
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception EX)
                {
                    EX.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro");
                    return View(tbCargos);
                }

            }
            return View(tbCargos);
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tbCargos).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.carg_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbCargos.carg_UsuarioCrea);
            //ViewBag.carg_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbCargos.carg_UsuarioModifica);
            //return View(tbCargos);
        }

        // GET: Cargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargos tbCargos = db.tbCargos.Find(id);
            if (tbCargos == null)
            {
                return HttpNotFound();
            }
            return View(tbCargos);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCargos tbCargos = db.tbCargos.Find(id);
            db.tbCargos.Remove(tbCargos);
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
