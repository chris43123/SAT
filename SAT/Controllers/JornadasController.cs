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

        //Aquí iria el codigo de la instancia del index de grados

         //-----*******CUANDO TENGAMOS EL INDEX QUITAR EL COMENTARIO****
        //public ActionResult _IndexGrado(string dep_id)
        //{
        //    return PartialView(db.tbMunicipios.Where(x => x.dep_Id == dep_id));
        //}


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
            if (ModelState.IsValid)
            {
                var Sesion = (List<tbGrados>)Session["PollitoMunicipio"];
                db.tbJornadas.Add(tbJornadas);
                db.SaveChanges();
                foreach (tbGrados grad in Sesion)
                {
                    db.UDP_Gral_tbGrados_Insert(
                                                    grad.grad_Descripcion,
                                                    2,
                                                    DateTime.Now
                                                    );
                }
                return RedirectToAction("Index");
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
            tbJornadas tbjornada = db.tbJornadas.Find();
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
            if (ModelState.IsValid)
            {
                db.Entry(tbJornadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
                var itemToRemove = Sesion.Find(x => x.grad_Id == grad_id); //x es el nombre de la tabla o el alias que les damos
                Sesion.Remove(itemToRemove);
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
