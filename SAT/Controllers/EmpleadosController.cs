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

        // GET: Empleados
        public ActionResult Index()
        {
            var tbEmpleados = db.tbEmpleados.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbCargos).Include(t => t.tbMunicipios);
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
            ViewBag.emp_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.emp_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.carg_Id = new SelectList(db.tbCargos, "carg_Id", "carg_Descripcion");
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_Id,emp_Identidad,emp_Nombres,emp_Apellidos,emp_FechaNacimiento,emp_Sexo,emp_Direccion,mun_Id,emp_CorreoElectronico,emp_Telefono,carg_Id,emp_FechaIngreso,emp_FechadeSalida,emp_RazonSalida,emp_UsuarioCrea,emp_FechaCrea,emp_UsuarioModifica,emp_FechaModifica")] tbEmpleados tbEmpleados)
        {
            tbEmpleados.emp_FechaCrea = DateTime.Now;
            tbEmpleados.emp_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listEmpleados = null;
                    string MensajeError = "";
                    listEmpleados = db.UDP_Gral_tbEmpleados_Insert(tbEmpleados.emp_Identidad,
                                                                    tbEmpleados.emp_Nombres,
                                                                    tbEmpleados.emp_Apellidos,
                                                                    tbEmpleados.emp_FechaNacimiento,
                                                                    tbEmpleados.emp_Sexo,
                                                                    tbEmpleados.emp_Direccion,
                                                                    tbEmpleados.mun_Id,
                                                                    tbEmpleados.emp_CorreoElectronico,
                                                                    tbEmpleados.emp_Telefono,
                                                                    tbEmpleados.carg_Id,
                                                                    tbEmpleados.emp_FechaIngreso,
                                                                    tbEmpleados.emp_FechadeSalida,
                                                                    tbEmpleados.emp_RazonSalida,
                                                                    tbEmpleados.emp_UsuarioCrea,
                                                                    tbEmpleados.emp_FechaCrea );

                    foreach (UDP_Gral_tbEmpleados_Insert_Result Res in listEmpleados)
                        MensajeError = Res.MensajeError;

                    if(MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro");
                        return View(tbEmpleados);
                    }

                    return RedirectToAction("Index");
                }

                catch(Exception ex)
                {
                    ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro");

                }

                ////db.tbEmpleados.Add(tbEmpleados);
                ////db.SaveChanges();
                ////return RedirectToAction("Index");
            }

            //ViewBag.emp_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEmpleados.emp_UsuarioCrea);
            //ViewBag.emp_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEmpleados.emp_UsuarioModifica);
            //ViewBag.carg_Id = new SelectList(db.tbCargos, "carg_Id", "carg_Descripcion", tbEmpleados.carg_Id);
            //ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion", tbEmpleados.mun_Id);
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
            ViewBag.emp_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEmpleados.emp_UsuarioCrea);
            ViewBag.emp_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEmpleados.emp_UsuarioModifica);
            ViewBag.carg_Id = new SelectList(db.tbCargos, "carg_Id", "carg_Descripcion", tbEmpleados.carg_Id);
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion", tbEmpleados.mun_Id);
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
            ViewBag.emp_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEmpleados.emp_UsuarioCrea);
            ViewBag.emp_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEmpleados.emp_UsuarioModifica);
            ViewBag.carg_Id = new SelectList(db.tbCargos, "carg_Id", "carg_Descripcion", tbEmpleados.carg_Id);
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion", tbEmpleados.mun_Id);
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
