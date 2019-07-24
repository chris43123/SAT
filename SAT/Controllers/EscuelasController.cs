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
    public class EscuelasController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Escuelas
        public ActionResult Index()
        {
            var tbEscuelas = db.tbEscuelas.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbEmpleados).Include(t => t.tbEmpleados1).Include(t => t.tbMunicipios);
            return View(tbEscuelas.ToList());
        }

        // GET: Escuelas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEscuelas tbEscuelas = db.tbEscuelas.Find(id);
            if (tbEscuelas == null)
            {
                return HttpNotFound();
            }
            return View(tbEscuelas);
        }

        // GET: Escuelas/Create
        public ActionResult Create()
        {
            ViewBag.esc_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.esc_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");

            ViewBag.esc_Director = new SelectList(db.tbEscuelas, "esc_Id", "esc_Codigo");
            ViewBag.esc_Contacto = new SelectList(db.tbEscuelas, "esc_Id", "esc_Contacto");
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion");
            return View();
        }

        // POST: Escuelas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "esc_Id,esc_Codigo,esc_NombreEscuela,esc_Director,esc_Contacto,esc_Telefono,esc_Correo,mun_Id,esc_UsuarioCrea,esc_FechaCrea,esc_UsuarioModifica,esc_FechaModifica")] tbEscuelas tbEscuelas)
        {

            ViewBag.esc_Director = new SelectList(db.tbEscuelas, "esc_Id", "esc_Codigo");
            ViewBag.esc_Contacto = new SelectList(db.tbEscuelas, "esc_Id", "esc_Contacto");
            tbEscuelas.esc_FechaCrea = DateTime.Now;
            tbEscuelas.esc_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listEscuelas = null;
                    string MensajeError = "";
                    listEscuelas = db.UDP_Gral_tbEscuelas_Insert(tbEscuelas.esc_Codigo,
                                                                 tbEscuelas.esc_NombreEscuela,
                                                                 tbEscuelas.esc_Director,
                                                                 tbEscuelas.esc_Contacto,
                                                                 tbEscuelas.esc_Telefono,
                                                                 tbEscuelas.esc_Correo,
                                                                 tbEscuelas.mun_Id,
                                                                 tbEscuelas.esc_UsuarioCrea,
                                                                 tbEscuelas.esc_FechaCrea
                                                                 );
                    foreach (UDP_Gral_tbEscuelas_Insert_Result Res in listEscuelas)
                        MensajeError = Res.MensajeError;

                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro.");
                        return View(tbEscuelas);
                    }
                    return RedirectToAction("Index");


                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar e registro");
                    return View(tbEscuelas);
                }
            }
            ViewBag.esc_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEscuelas.esc_UsuarioCrea);
            ViewBag.esc_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEscuelas.esc_UsuarioModifica);
            ViewBag.esc_Contacto = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbEscuelas.esc_Contacto);
            ViewBag.esc_Director = new SelectList(db.tbEmpleados, "emp_Id", "emp_Identidad", tbEscuelas.esc_Director);
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion", tbEscuelas.mun_Id);
            return View(tbEscuelas);
               
            }

    
   

        // GET: Escuelas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEscuelas tbEscuelas = db.tbEscuelas.Find(id);
            if (tbEscuelas == null)
            {
                return HttpNotFound();
            }
            ViewBag.esc_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEscuelas.esc_UsuarioCrea);
            ViewBag.esc_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEscuelas.esc_UsuarioModifica);

            ViewBag.esc_Director = new SelectList(db.tbEscuelas, "esc_Id", "esc_Codigo");
            ViewBag.esc_Contacto = new SelectList(db.tbEscuelas, "esc_Id", "esc_Contacto");
            ViewBag.mun_Id = new SelectList(db.tbMunicipios, "mun_Id", "mun_Descripcion", tbEscuelas.mun_Id);
            return View(tbEscuelas);
        }

        // POST: Escuelas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "esc_Id,esc_Codigo,esc_NombreEscuela,esc_Director,esc_Contacto,esc_Telefono,esc_Correo,mun_Id,esc_UsuarioCrea,esc_FechaCrea,esc_UsuarioModifica,esc_FechaModifica")] tbEscuelas tbEscuelas)
        {

            ViewBag.esc_Director = new SelectList(db.tbEscuelas, "esc_Id", "esc_Codigo");
            ViewBag.esc_Contacto = new SelectList(db.tbEscuelas, "esc_Id", "esc_Contacto");
            tbEscuelas.esc_FechaCrea = DateTime.Now;
            tbEscuelas.esc_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listEscuelas = null;
                    string MensajeError = "";
                    listEscuelas = db.UDP_Gral_tbEscuelas_Update(tbEscuelas.esc_Id,
                                                                 tbEscuelas.esc_Codigo,
                                                                 tbEscuelas.esc_NombreEscuela,
                                                                 tbEscuelas.esc_Director,
                                                                 tbEscuelas.esc_Contacto,
                                                                 tbEscuelas.esc_Telefono,
                                                                 tbEscuelas.esc_Correo,
                                                                 tbEscuelas.mun_Id,
                                                                 tbEscuelas.esc_UsuarioCrea,
                                                                 tbEscuelas.esc_FechaCrea,
                                                                 tbEscuelas.esc_UsuarioModifica,
                                                                 tbEscuelas.esc_FechaModifica
                                                                 );

                    foreach (UDP_Gral_tbEscuelas_Update_Result Res in listEscuelas)
                        MensajeError = Res.MensajeError;

                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro.");
                        return View(tbEscuelas);
                    }
                    return RedirectToAction("Index");


                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar e registro");
                    return View(tbEscuelas);
                }
            }


            ViewBag.esc_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEscuelas.esc_UsuarioCrea);
            ViewBag.esc_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEscuelas.esc_UsuarioModifica);
          
            return View(tbEscuelas);
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
