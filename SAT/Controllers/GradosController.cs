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
    public class GradosController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Grados
        public ActionResult Index()
        {
            var tbGrados = db.tbGrados.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbGrados.ToList());
        }

        // GET: Grados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGrados tbGrados = db.tbGrados.Find(id);
            if (tbGrados == null)
            {
                return HttpNotFound();
            }
            return View(tbGrados);
        }

        // GET: Grados/Create
        public ActionResult Create()
        {
            ViewBag.grad_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.grad_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            return View();
        }

        // POST: Grados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "grad_Id,grad_Descripcion,grad_UsuarioCrea,grad_FechaCrea,grad_UsuarioModifica,grad_FechaModifica")] tbGrados tbGrados)
        {
            tbGrados.grad_UsuarioCrea = 2;
            tbGrados.grad_FechaCrea = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.tbGrados.Add(tbGrados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.grad_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbGrados.grad_UsuarioCrea);
            ViewBag.grad_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbGrados.grad_UsuarioModifica);
            return View(tbGrados);
        }

        // GET: Grados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGrados tbGrados = db.tbGrados.Find(id);
            if (tbGrados == null)
            {
                return HttpNotFound();
            }
            ViewBag.grad_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbGrados.grad_UsuarioCrea);
            ViewBag.grad_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbGrados.grad_UsuarioModifica);
            return View(tbGrados);
        }

        // POST: Grados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "grad_Id,grad_Descripcion,grad_UsuarioCrea,grad_FechaCrea,grad_UsuarioModifica,grad_FechaModifica")] tbGrados tbGrados)
        {
            tbGrados.grad_UsuarioModifica = 2;
            tbGrados.grad_FechaModifica = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(tbGrados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.grad_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbGrados.grad_UsuarioCrea);
            ViewBag.grad_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbGrados.grad_UsuarioModifica);
            return View(tbGrados);
        }

        // GET: Grados/Delete/5



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
