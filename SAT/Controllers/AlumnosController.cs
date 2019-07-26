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
    public class AlumnosController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Alumnos
        public ActionResult Index()
        {
            var tbAlumnos = db.tbAlumnos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbAlumnos.ToList());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(tbAlumnos);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion");
            ViewBag.alu_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.alu_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "alu_Id,alu_Identidad,alu_Nombres,alu_Apellidos,alu_Sexo,alu_FechaNacimiento,alu_direccion,mun_Id,alu_NombresEncargado,alu_ApellidosEncargado,alu_TelefonoEncargado,alu_EsActivo,alu_RazonInactivo,alu_UsuarioCrea,alu_FechaCrea,alu_UsuarioModifica,alu_FechaModifica")] tbAlumnos tbAlumnos)
        {

            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion");
            tbAlumnos.alu_FechaCrea = DateTime.Now;
            tbAlumnos.alu_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listAlumnos = null;
                    string MensajeError = "";
                    listAlumnos = db.UDP_Esc_tbAlumnos_Insert(tbAlumnos.alu_Identidad,
                                                             tbAlumnos.alu_Nombres,
                                                             tbAlumnos.alu_Apellidos,
                                                             tbAlumnos.alu_Sexo,
                                                             tbAlumnos.alu_FechaNacimiento,
                                                             tbAlumnos.alu_direccion,
                                                             tbAlumnos.mun_Id,
                                                             tbAlumnos.alu_NombresEncargado,
                                                             tbAlumnos.alu_ApellidosEncargado,
                                                             tbAlumnos.alu_TelefonoEncargado,
                                                             tbAlumnos.alu_EsActivo,
                                                             tbAlumnos.alu_RazonInactivo,
                                                             tbAlumnos.alu_UsuarioCrea,
                                                             tbAlumnos.alu_FechaCrea,
                                                             tbAlumnos.alu_UsuarioModifica,
                                                             tbAlumnos.alu_FechaModifica);

                    foreach (UDP_Esc_tbAlumnos_Insert_Result Res in listAlumnos)
                        MensajeError = Res.MENSAJEERROR;
                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro.");
                        return View(tbAlumnos);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro.");
                    return View(tbAlumnos);
                }
            }

                ViewBag.alu_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAlumnos.alu_UsuarioCrea);
                ViewBag.alu_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAlumnos.alu_UsuarioModifica);

                return View(tbAlumnos);
            
        }


        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.alu_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAlumnos.alu_UsuarioCrea);
            ViewBag.alu_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAlumnos.alu_UsuarioModifica);
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion", tbAlumnos.mun_Id);
            return View(tbAlumnos);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "alu_Id,alu_Identidad,alu_Nombres,alu_Apellidos,alu_Sexo,alu_FechaNacimiento,alu_direccion,mun_Id,alu_NombresEncargado,alu_ApellidosEncargado,alu_TelefonoEncargado,alu_EsActivo,alu_RazonInactivo,alu_UsuarioCrea,alu_FechaCrea,alu_UsuarioModifica,alu_FechaModifica")] tbAlumnos tbAlumnos)
        {
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion");

            tbAlumnos.alu_UsuarioModifica = 2;
            tbAlumnos.alu_FechaModifica = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listAlumnos = null;
                    string MensajeError = "";
                    listAlumnos = db.UDP_Esc_tbAlumnos_Update(
                                                             tbAlumnos.alu_Id,
                                                             tbAlumnos.alu_Identidad,
                                                             tbAlumnos.alu_Nombres,
                                                             tbAlumnos.alu_Apellidos,
                                                             tbAlumnos.alu_Sexo,
                                                             tbAlumnos.alu_FechaNacimiento,
                                                             tbAlumnos.alu_direccion,
                                                             tbAlumnos.mun_Id,
                                                             tbAlumnos.alu_NombresEncargado,
                                                             tbAlumnos.alu_ApellidosEncargado,
                                                             tbAlumnos.alu_TelefonoEncargado,
                                                             tbAlumnos.alu_EsActivo,
                                                             tbAlumnos.alu_RazonInactivo,
                                                             tbAlumnos.alu_UsuarioCrea,
                                                             tbAlumnos.alu_FechaCrea,
                                                             tbAlumnos.alu_UsuarioModifica,
                                                             tbAlumnos.alu_FechaModifica);

                    foreach (UDP_Esc_tbAlumnos_Update_Result Res in listAlumnos)
                        MensajeError = Res.MensajeError;
                    //Validamos
                    if (!string.IsNullOrEmpty(MensajeError))
                    {
                        if (MensajeError.StartsWith("-1"))
                        {
                            ModelState.AddModelError("", "1. No se pudo editar el registro");
                            return View(tbAlumnos);
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro.");
                    return View(tbAlumnos);
                }
            }

        
        ViewBag.alu_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAlumnos.alu_UsuarioCrea);
            ViewBag.alu_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbAlumnos.alu_UsuarioModifica);
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion", tbAlumnos.mun_Id);
            return View(tbAlumnos);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(tbAlumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            db.tbAlumnos.Remove(tbAlumnos);
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
