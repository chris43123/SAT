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

        //Instancia del index de grados

        public ActionResult _IndexGrado(int jor_Id)
        {
            return PartialView(db.tbJornadas.Where(x => x.jor_Id == jor_Id));
        }


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
            var Sesion = (List<tbGrados>)Session["PollitoGrados"];
            tbJornadas.jor_FechaCrea = DateTime.Now;
            tbJornadas.jor_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listjornadas = null;
                    string MensajeError = "";
                    listjornadas = db.UDP_Gral_tbJornadas_Insert(tbJornadas.jor_Descripcion,
                                                                tbJornadas.jor_UsuarioCrea,
                                                                tbJornadas.jor_FechaCrea);

                    foreach (UDP_Gral_tbJornadas_Insert_Result jor in listjornadas)
                    MensajeError = jor.MensajeError;

                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1. No se pudo insertar el registro.");
                        return View(tbJornadas);
                    }
                    else
                    {
                        foreach (tbGrados grad in Sesion)
                        {

                            db.UDP_Gral_tbGrados_Insert(grad.grad_Descripcion, 2, DateTime.Now);
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception EX)
                {
                    EX.Message.ToString();
                    ModelState.AddModelError("", "2.No se pudo insertar el registro");
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
            tbJornadas tbjornada = db.tbJornadas.Find(id);
            if (tbjornada == null)
            {
                return HttpNotFound();
            }
            return View(tbjornada);
        }

        // POST: Jornadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jor_Id,jor_Descripcion,jor_UsuarioCrea,jor_FechaCrea,jor_UsuarioModifica,jor_FechaModifica")] tbJornadas tbJornadas)
        {
            var Sesion = (List<tbGrados>)Session["PollitoGrados"];
            tbJornadas.jor_FechaModifica = DateTime.Now;
            tbJornadas.jor_UsuarioModifica = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listjornadas = null;
                    string MensajeError = "";
                    listjornadas = db.UDP_Gral_tbJornadas_Update(tbJornadas.jor_Id,
                                                                tbJornadas.jor_Descripcion,
                                                                tbJornadas.jor_UsuarioCrea,
                                                                tbJornadas.jor_FechaCrea,
                                                                tbJornadas.jor_UsuarioModifica,
                                                                tbJornadas.jor_FechaModifica);

                    foreach (UDP_Gral_tbJornadas_Update_Result jor in listjornadas)
                        MensajeError = jor.MensajeError;
                    if (!string.IsNullOrEmpty(MensajeError))
                    {
                        if (MensajeError.StartsWith("-1"))
                        {
                            ModelState.AddModelError("", "1. No se pudo editar el registro");
                            return View(tbJornadas);
                        }
                    }
                    else
                    {
                        foreach (tbGrados grad in Sesion)
                        {

                            db.UDP_Gral_tbGrados_Update(grad.grad_Id,grad.grad_Descripcion,grad.grad_UsuarioCrea,grad.grad_FechaCrea,grad.grad_UsuarioModifica,grad.grad_FechaModifica);
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception EX)
                {
                    EX.Message.ToString();
                    ModelState.AddModelError("", "2.No se pudo insertar el registro");
                    return View(tbJornadas);
                }
            }

            return View(tbJornadas);
        }

        public JsonResult AgregarGrados(tbGrados tbGrado)
        {
            List<tbGrados> List = new List<tbGrados>();
            var Sesion = (List<tbGrados>)Session["PollitoGrados"];
            if (Sesion != null)
            {
                List = Sesion;
            }
            //Añadimos la lista, cuando demos guardar vamos a recorrer esa lista
            List.Add(tbGrado);
            Session["PollitoGrados"] = List;
            return Json("Exito", JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveGrados(int grad_id)
        {
            var Sesion = (List<tbGrados>)Session["PollitoGrados"];
            if (Sesion != null)
            {
                var itemremove = Sesion.Find(x => x.grad_Id == grad_id); //x es el nombre de la tabla o el alias que les damos
                Sesion.Remove(itemremove);
            }
            return Json("Exito", JsonRequestBehavior.AllowGet);
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
