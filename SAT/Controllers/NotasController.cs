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
    public class NotasController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Notas
        public ActionResult Index()
        {
            var tbNotas = db.tbNotas.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbMatriculas).Include(t => t.tbAsignaturas);
            return View(tbNotas.ToList());
        }

        // GET: Notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNotas tbNotas = db.tbNotas.Find(id);
            if (tbNotas == null)
            {
                return HttpNotFound();
            }
            return View(tbNotas);
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            ViewBag.not_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.not_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.mat_Id = new SelectList(db.tbMatriculas, "mat_Id", "mat_Id");
            ViewBag.asig_Id = new SelectList(db.tbAsignaturas, "asig_Id", "asig_Descripcion");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "not_Id,asig_Id,mat_Id,not_UsuarioCrea,not_FechaCrea,not_UsuarioModifica,not_FechaModifica")] tbNotas tbNotas)
        {
            tbNotas.not_UsuarioCrea = 2;
            tbNotas.not_FechaCrea = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listnotas = null;
                    string mensajeerror = "";
                    listnotas = db.UDP_Esc_tbNotas_Insert(tbNotas.asig_Id, tbNotas.mat_Id, tbNotas.not_UsuarioCrea, tbNotas.not_FechaCrea);

                    foreach (UDP_Esc_tbNotas_Insert_Result not in listnotas)
                        mensajeerror = not.MensajeError;
                    if (mensajeerror.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro");
                        return View(tbNotas);
                    }
                }

                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo ingresar el registro");
                }

                
            }
            return View(tbNotas);
        }

        // GET: Notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNotas tbNotas = db.tbNotas.Find(id);
            if (tbNotas == null)
            {
                return HttpNotFound();
            }
            ViewBag.not_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbNotas.not_UsuarioCrea);
            ViewBag.not_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbNotas.not_UsuarioModifica);
            ViewBag.mat_Id = new SelectList(db.tbMatriculas, "mat_Id", "mat_Id", tbNotas.mat_Id);
            ViewBag.asig_Id = new SelectList(db.tbAsignaturas, "asig_Id", "asig_Descripcion", tbNotas.asig_Id);
            return View(tbNotas);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "not_Id,asig_Id,mat_Id,not_UsuarioCrea,not_FechaCrea,not_UsuarioModifica,not_FechaModifica")] tbNotas tbNotas)
        {
            tbNotas.not_UsuarioModifica = 2;
            tbNotas.not_FechaModifica = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(tbNotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.not_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbNotas.not_UsuarioCrea);
            ViewBag.not_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbNotas.not_UsuarioModifica);
            ViewBag.mat_Id = new SelectList(db.tbMatriculas, "mat_Id", "mat_Id", tbNotas.mat_Id);
            ViewBag.asig_Id = new SelectList(db.tbAsignaturas, "asig_Id", "asig_Descripcion", tbNotas.asig_Id);
            return View(tbNotas);
        }

        // GET: Notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNotas tbNotas = db.tbNotas.Find(id);
            if (tbNotas == null)
            {
                return HttpNotFound();
            }
            return View(tbNotas);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbNotas tbNotas = db.tbNotas.Find(id);
            db.tbNotas.Remove(tbNotas);
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
