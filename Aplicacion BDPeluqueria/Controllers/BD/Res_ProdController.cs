using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplicacion_BDPeluqueria.BaseDatos;

namespace Aplicacion_BDPeluqueria.Controllers
{
    public class Res_ProdController : Controller
    {
        private BDPeluqueriaEntities1 db = new BDPeluqueriaEntities1();

        // GET: Res_Prod
        public ActionResult Index()
        {
            var res_Prod = db.Res_Prod.Include(r => r.Producto).Include(r => r.Reserva);
            return View(res_Prod.ToList());
        }

        // GET: Res_Prod/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Prod res_Prod = db.Res_Prod.Find(id);
            if (res_Prod == null)
            {
                return HttpNotFound();
            }
            return View(res_Prod);
        }

        // GET: Res_Prod/Create
        public ActionResult Create()
        {
            ViewBag.id_Prod = new SelectList(db.Productos, "id_Prod", "nombre_Prod");
            ViewBag.num_Res = new SelectList(db.Reservas, "num_Res", "dni_Cli");
            return View();
        }

        // POST: Res_Prod/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "num_Res,id_Prod,cantidad")] Res_Prod res_Prod)
        {
            if (ModelState.IsValid)
            {
                db.Res_Prod.Add(res_Prod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Prod = new SelectList(db.Productos, "id_Prod", "nombre_Prod", res_Prod.id_Prod);
            ViewBag.num_Res = new SelectList(db.Reservas, "num_Res", "dni_Cli", res_Prod.num_Res);
            return View(res_Prod);
        }

        // GET: Res_Prod/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Prod res_Prod = db.Res_Prod.Find(id);
            if (res_Prod == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Prod = new SelectList(db.Productos, "id_Prod", "nombre_Prod", res_Prod.id_Prod);
            ViewBag.num_Res = new SelectList(db.Reservas, "num_Res", "dni_Cli", res_Prod.num_Res);
            return View(res_Prod);
        }

        // POST: Res_Prod/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "num_Res,id_Prod,cantidad")] Res_Prod res_Prod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(res_Prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Prod = new SelectList(db.Productos, "id_Prod", "nombre_Prod", res_Prod.id_Prod);
            ViewBag.num_Res = new SelectList(db.Reservas, "num_Res", "dni_Cli", res_Prod.num_Res);
            return View(res_Prod);
        }

        // GET: Res_Prod/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Prod res_Prod = db.Res_Prod.Find(id);
            if (res_Prod == null)
            {
                return HttpNotFound();
            }
            return View(res_Prod);
        }

        // POST: Res_Prod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Res_Prod res_Prod = db.Res_Prod.Find(id);
            db.Res_Prod.Remove(res_Prod);
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
