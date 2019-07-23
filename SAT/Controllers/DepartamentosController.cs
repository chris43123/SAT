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

            if (ModelState.IsValid)
            {
                db.tbDepartamentos.Add(tbDepartamentos);
                db.SaveChanges();
                foreach(tbMunicipios Mun in Sesion)
                {
                    db.UDP_Gral_tbMunicipios_Insert(Mun.dep_Id,
                                                       Mun.mun_Descripcion,                                                       
                                                       2,
                                                       DateTime.Now,
                                                       tbDepartamentos.dep_Id
                                                       );
                }
                return RedirectToAction("Index");
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
