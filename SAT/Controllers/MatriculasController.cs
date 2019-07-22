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
    public class MatriculasController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Matriculas
        public ActionResult Index()
        {
            var tbMatriculas = db.tbMatriculas.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbAlumnos).Include(t => t.tbCarreras).Include(t => t.tbEscuelas).Include(t => t.tbSecciones);
            return View(tbMatriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMatriculas tbMatriculas = db.tbMatriculas.Find(id);
            if (tbMatriculas == null)
            {
                return HttpNotFound();
            }
            return View(tbMatriculas);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.mat_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.mat_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.alu_Id = new SelectList(db.tbAlumnos, "alu_Id", "alu_Identidad");
            ViewBag.car_Id = new SelectList(db.tbCarreras, "car_Id", "car_Descripcion");
            ViewBag.esc_Id = new SelectList(db.tbEscuelas, "esc_Id", "esc_Codigo");
            ViewBag.sec_Id = new SelectList(db.tbSecciones, "sec_Id", "sec_Descripcion");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mat_Id,alu_Id,esc_Id,sec_Id,car_Id,mat_Anio,mat_UsuarioCrea,mat_FechaCrea,mat_UsuarioModifica,mat_FechaModifica")] tbMatriculas tbMatriculas)
        {
            tbMatriculas.mat_Anio = DateTime.Now.Year;
            tbMatriculas.mat_FechaCrea = DateTime.Now;
            tbMatriculas.mat_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> ListMatricula = null;
                    string MensajeError = "";

                    ListMatricula = db.UDP_Esc_tbMatriculas_Insert(tbMatriculas.alu_Id,
                                                                   tbMatriculas.esc_Id,
                                                                   tbMatriculas.sec_Id,
                                                                   tbMatriculas.car_Id,
                                                                   tbMatriculas.mat_Anio,
                                                                   tbMatriculas.mat_UsuarioCrea,
                                                                   tbMatriculas.mat_FechaCrea
                                                                   );
                    foreach (UDP_Esc_tbMatriculas_Insert_Result res in ListMatricula)
                    {
                        MensajeError = res.MensajeError;
                    }

                    if(MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo isertar el registro");
                        return View(tbMatriculas);
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro.");
                    return View(tbMatriculas);
                }
            }

            ViewBag.mat_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMatriculas.mat_UsuarioCrea);
            ViewBag.mat_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMatriculas.mat_UsuarioModifica);
            ViewBag.alu_Id = new SelectList(db.tbAlumnos, "alu_Id", "alu_Identidad", tbMatriculas.alu_Id);
            ViewBag.car_Id = new SelectList(db.tbCarreras, "car_Id", "car_Descripcion", tbMatriculas.car_Id);
            ViewBag.esc_Id = new SelectList(db.tbEscuelas, "esc_Id", "esc_Codigo", tbMatriculas.esc_Id);
            ViewBag.sec_Id = new SelectList(db.tbSecciones, "sec_Id", "sec_Descripcion", tbMatriculas.sec_Id);
            return View(tbMatriculas);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMatriculas tbMatriculas = db.tbMatriculas.Find(id);
            if (tbMatriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.mat_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMatriculas.mat_UsuarioCrea);
            ViewBag.mat_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMatriculas.mat_UsuarioModifica);
            ViewBag.alu_Id = new SelectList(db.tbAlumnos, "alu_Id", "alu_Identidad", tbMatriculas.alu_Id);
            ViewBag.car_Id = new SelectList(db.tbCarreras, "car_Id", "car_Descripcion", tbMatriculas.car_Id);
            ViewBag.esc_Id = new SelectList(db.tbEscuelas, "esc_Id", "esc_Codigo", tbMatriculas.esc_Id);
            ViewBag.sec_Id = new SelectList(db.tbSecciones, "sec_Id", "sec_Descripcion", tbMatriculas.sec_Id);
            return View(tbMatriculas);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mat_Id,alu_Id,esc_Id,sec_Id,car_Id,mat_Anio,mat_UsuarioCrea,mat_FechaCrea,mat_UsuarioModifica,mat_FechaModifica")] tbMatriculas tbMatriculas)
        {
            ViewBag.alu_Id = new SelectList(db.tbMatriculas, "alu_Id", "alu_Id");
            tbMatriculas.mat_Anio = DateTime.Now.Year;
            tbMatriculas.mat_FechaCrea = DateTime.Now;
            tbMatriculas.mat_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> ListMatricula = null;
                    string MensajeError = "";

                    ListMatricula = db.UDP_Esc_tbMatriculas_Update(tbMatriculas.mat_Id,
                                                                   tbMatriculas.esc_Id,
                                                                   tbMatriculas.alu_Id,
                                                                   tbMatriculas.sec_Id,
                                                                   tbMatriculas.car_Id,
                                                                   tbMatriculas.mat_Anio,
                                                                   tbMatriculas.mat_UsuarioCrea,
                                                                   tbMatriculas.mat_FechaCrea,
                                                                   tbMatriculas.mat_UsuarioModifica,
                                                                   tbMatriculas.mat_FechaModifica
                                                                   );
                    foreach (UDP_Esc_tbMatriculas_Update_Result res in ListMatricula)
                    {
                        MensajeError = res.MensajeError;
                    }

                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo isertar el registro");
                        return View(tbMatriculas);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro.");
                    return View(tbMatriculas);
                }
            }
            ViewBag.mat_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMatriculas.mat_UsuarioCrea);
            ViewBag.mat_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMatriculas.mat_UsuarioModifica);
            ViewBag.alu_Id = new SelectList(db.tbAlumnos, "alu_Id", "alu_Identidad", tbMatriculas.alu_Id);
            ViewBag.car_Id = new SelectList(db.tbCarreras, "car_Id", "car_Descripcion", tbMatriculas.car_Id);
            ViewBag.esc_Id = new SelectList(db.tbEscuelas, "esc_Id", "esc_Codigo", tbMatriculas.esc_Id);
            ViewBag.sec_Id = new SelectList(db.tbSecciones, "sec_Id", "sec_Descripcion", tbMatriculas.sec_Id);
            return View(tbMatriculas);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMatriculas tbMatriculas = db.tbMatriculas.Find(id);
            if (tbMatriculas == null)
            {
                return HttpNotFound();
            }
            return View(tbMatriculas);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbMatriculas tbMatriculas = db.tbMatriculas.Find(id);
            db.tbMatriculas.Remove(tbMatriculas);
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
