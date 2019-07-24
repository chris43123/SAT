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
    public class NotaDetallesController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: NotaDetalles
        public ActionResult Index()
        {
            var tbNotaDetalles = db.tbNotaDetalles.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbNotas);
            return View(tbNotaDetalles.ToList());
        }

        // GET: NotaDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNotaDetalles tbNotaDetalles = db.tbNotaDetalles.Find(id);
            if (tbNotaDetalles == null)
            {
                return HttpNotFound();
            }
            return View(tbNotaDetalles);
        }

        // GET: NotaDetalles/Create
        public ActionResult Create()
        {
            ViewBag.notd_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.notd_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.not_Id = new SelectList(db.tbNotas, "not_Id", "not_Id");
            return View();
        }

        // POST: NotaDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "notd_Id,not_Id,notd_Acumulado1,notd_Examen1,notd_Acumulado2,notd_Examen2,notd_Acumulado3,notd_Examen3,notd_Acumulado4,notd_Examen4,notd_UsuarioCrea,notd_FechaCrea,notd_UsuarioModifica,notd_FechaModifica")] tbNotaDetalles tbNotaDetalles)
        {
            tbNotaDetalles.notd_UsuarioCrea = 2;
            tbNotaDetalles.notd_FechaCrea = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    //Lista para poder recorrer el tipo complejo
                    IEnumerable<object> listnotas = null;
                    string MensajeError = "";
                    //almacenamos la ejecución del SP
                    listnotas = db.UDP_Esc_tbNotaDetalles_Insert(tbNotaDetalles.notd_Id,
                                                                 tbNotaDetalles.notd_Acumulado1,
                                                                 tbNotaDetalles.notd_Examen1,
                                                                 tbNotaDetalles.notd_Acumulado2,
                                                                 tbNotaDetalles.notd_Examen2,
                                                                 tbNotaDetalles.notd_Acumulado3,
                                                                 tbNotaDetalles.notd_Examen3,
                                                                 tbNotaDetalles.notd_Acumulado4,
                                                                 tbNotaDetalles.notd_Examen4,
                                                                 tbNotaDetalles.notd_UsuarioCrea,
                                                                 tbNotaDetalles.notd_FechaCrea);
                    //Recuperamos el valor que trae nuestro retorno
                    foreach (UDP_Esc_tbNotaDetalles_Insert_Result Res in listnotas)
                        MensajeError = Res.MensajeError;
                    //Validamos
                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro.");
                        return View(tbNotaDetalles);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro.");
                    return View(tbNotaDetalles);
                }
            }
            return View(tbNotaDetalles);
        }

        // GET: NotaDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNotaDetalles tbNotaDetalles = db.tbNotaDetalles.Find(id);
            if (tbNotaDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.notd_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbNotaDetalles.notd_UsuarioCrea);
            ViewBag.notd_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbNotaDetalles.notd_UsuarioModifica);
            ViewBag.not_Id = new SelectList(db.tbNotas, "not_Id", "not_Id", tbNotaDetalles.not_Id);
            return View(tbNotaDetalles);
        }

        // POST: NotaDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "notd_Id,not_Id,notd_Acumulado1,notd_Examen1,notd_Acumulado2,notd_Examen2,notd_Acumulado3,notd_Examen3,notd_Acumulado4,notd_Examen4,notd_UsuarioCrea,notd_FechaCrea,notd_UsuarioModifica,notd_FechaModifica")] tbNotaDetalles tbNotaDetalles)
        {
            tbNotaDetalles.notd_UsuarioCrea = 2;
            tbNotaDetalles.notd_FechaCrea = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    //Lista para poder recorrer el tipo complejo
                    IEnumerable<object> listnotas = null;
                    string MensajeError = "";
                    //almacenamos la ejecución del SP
                    listnotas = db.UDP_Esc_tbNotaDetalles_Update(tbNotaDetalles.notd_Id,
                                                                 tbNotaDetalles.not_Id,
                                                                 tbNotaDetalles.notd_Examen1,
                                                                 tbNotaDetalles.notd_Examen2,
                                                                 tbNotaDetalles.notd_Examen3,
                                                                 tbNotaDetalles.notd_Examen4,
                                                                    tbNotaDetalles.notd_Acumulado1,
                                                                 tbNotaDetalles.notd_Acumulado2,
                                                                 tbNotaDetalles.notd_Acumulado3,
                                                                 tbNotaDetalles.notd_Acumulado4,
                                                                 tbNotaDetalles.notd_UsuarioCrea,
                                                                 tbNotaDetalles.notd_FechaCrea,
                                                                 tbNotaDetalles.notd_UsuarioModifica,
                                                                 tbNotaDetalles.notd_FechaModifica);
                    //Recuperamos el valor que trae nuestro retorno
                    foreach (UDP_Esc_tbNotaDetalles_Update_Result Res in listnotas)
                        MensajeError = Res.MensajeError;
                    //Validamos
                    if (!string.IsNullOrEmpty(MensajeError))
                    {
                        if (MensajeError.StartsWith("-1"))
                        {
                            ModelState.AddModelError("", "1. No se pudo editar el registro");
                            return View(tbNotaDetalles);
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro.");
                    return View(tbNotaDetalles);
                }
            }
            return View(tbNotaDetalles);
        }

        // GET: NotaDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNotaDetalles tbNotaDetalles = db.tbNotaDetalles.Find(id);
            if (tbNotaDetalles == null)
            {
                return HttpNotFound();
            }
            return View(tbNotaDetalles);
        }

        // POST: NotaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbNotaDetalles tbNotaDetalles = db.tbNotaDetalles.Find(id);
            db.tbNotaDetalles.Remove(tbNotaDetalles);
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
