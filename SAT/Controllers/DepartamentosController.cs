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
    public class DepartamentosController : Controller
    {
        private SATEntities db = new SATEntities();

        public ActionResult _IndexMunicipio(string dep_id)
        {
            return PartialView(db.tbMunicipios.Where(x => x.dep_Id == dep_id));
        }
        // GET: Departamentos
        public ActionResult Index()
        {
            return View(db.tbDepartamentos.ToList());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dep_Id,dep_Descripcion,dep_UsuarioCrea,dep_FechaCrea,dep_UsuarioModifica,dep_FechaModifica")] tbDepartamentos tbDepartamentos)
        {
            var Sesion = (List<tbMunicipios>)Session["PollitoMunicipio"];
            tbDepartamentos.dep_FechaCrea = DateTime.Now;
            tbDepartamentos.dep_UsuarioCrea = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<object> listdepartamentos = null;
                    string MensajeError = "";
                    listdepartamentos = db.UDP_Gral_tbDepartamentos_Insert(tbDepartamentos.dep_Id,
                                                                            tbDepartamentos.dep_Descripcion,
                                                                         tbDepartamentos.dep_UsuarioCrea,
                                                                         tbDepartamentos.dep_FechaCrea);
                    foreach (UDP_Gral_tbDepartamentos_Insert_Result res in listdepartamentos)
                        MensajeError = res.MensajeError;

                    if (MensajeError.StartsWith("-1"))
                    {
                        ModelState.AddModelError("", "1.no se pudo insertar el registro");
                        return View(tbDepartamentos);
                    }
                    else
                    {
                        foreach (tbMunicipios Mun in Sesion)
                        {
                            db.UDP_Gral_tbMunicipios_Insert(Mun.dep_Id,
                                                               Mun.mun_Descripcion,
                                                               2,
                                                               DateTime.Now,
                                                               tbDepartamentos.dep_Id
                                                               );
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception EX)
                {
                    EX.Message.ToString();
                    ModelState.AddModelError("", "2. No se pudo insertar el registro");
                    return View(tbDepartamentos);
                }
            }

            return View(tbDepartamentos);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dep_Id,dep_Descripcion,dep_UsuarioCrea,dep_FechaCrea,dep_UsuarioModifica,dep_FechaModifica")] tbDepartamentos tbDepartamentos)
        {
            //var Sesion = (List<tbMunicipios>)Session["PollitoMunicipio"];
            //if (ModelState.IsValid)
            //{
            //    db.tbDepartamentos.
            //}

            if (ModelState.IsValid)
            {
                db.Entry(tbDepartamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbDepartamentos);
        }

        public JsonResult AgregarMunicipio(tbMunicipios tbMunicipios)
        {
            List<tbMunicipios> List = new List<tbMunicipios>();
            var Sesion = (List<tbMunicipios>)Session["PollitoMunicipio"];
            if (Sesion != null)
            {
                List = Sesion;            

            }
             List.Add(tbMunicipios);
            Session["PollitoMunicipio"] = List;
            return Json("Exito", JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveMunicipio(string mun_Id)
        {
            var Sesion = (List<tbMunicipios>)Session["PollitoMunicipio"];
            if (Sesion != null)
            {
                var itemremove = Sesion.Find(x => x.mun_Id == mun_Id);
                Sesion.Remove(itemremove);
            }
            return Json("Exito", JsonRequestBehavior.AllowGet);
        }

        public JsonResult _EditarMunicipio(string mun_Id)
        {
            var List = db.UDP_Gral_tbMunicipios_Select(mun_Id).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateMun(tbMunicipios Municipio)
        {
            //Aqui va el update Municipio
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
