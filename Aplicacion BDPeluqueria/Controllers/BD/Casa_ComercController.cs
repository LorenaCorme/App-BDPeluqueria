using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplicacion_BDPeluqueria.BaseDatos;
using Aplicacion_BDPeluqueria.Models.CasasComerciales;
using AutoMapper;

namespace Aplicacion_BDPeluqueria.Controllers
{
    public class Casa_ComercController : Controller
    {
        private BDPeluqueriaEntities1 db = new BDPeluqueriaEntities1();

        // GET: Casa_Comerc
        public ActionResult Index()
        {
            var casas = db.Casa_Comerc;
            var modelos = Mapper.Map<IEnumerable<Casa_Comerc>, IEnumerable<InfoCasa>>(casas);

            return View(modelos);
        }

        // GET: Casa_Comerc/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casa_Comerc casa_Comerc = db.Casa_Comerc.Find(id);
            if (casa_Comerc == null)
            {
                return HttpNotFound();
            }
            return View(casa_Comerc);
        }

        // GET: Casa_Comerc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Casa_Comerc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre_Casa,local_Casa")] Casa_Comerc casa_Comerc)
        {
            if (ModelState.IsValid)
            {
                db.Casa_Comerc.Add(casa_Comerc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(casa_Comerc);
        }

        // GET: Casa_Comerc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casa_Comerc casa_Comerc = db.Casa_Comerc.Find(id);
            if (casa_Comerc == null)
            {
                return HttpNotFound();
            }
            return View(casa_Comerc);
        }

        // POST: Casa_Comerc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre_Casa,local_Casa")] Casa_Comerc casa_Comerc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casa_Comerc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(casa_Comerc);
        }

        // GET: Casa_Comerc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casa_Comerc casa_Comerc = db.Casa_Comerc.Find(id);
            if (casa_Comerc == null)
            {
                return HttpNotFound();
            }
            return View(casa_Comerc);
        }

        // POST: Casa_Comerc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Casa_Comerc casa_Comerc = db.Casa_Comerc.Find(id);
            db.Casa_Comerc.Remove(casa_Comerc);
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
