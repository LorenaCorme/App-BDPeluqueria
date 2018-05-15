using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplicacion_BDPeluqueria.BaseDatos;
using Aplicacion_BDPeluqueria.Models.Peluqueros;
using AutoMapper;

namespace Aplicacion_BDPeluqueria.Controllers
{
    public class PeluquerosController : Controller
    {
        private BDPeluqueriaEntities1 db = new BDPeluqueriaEntities1();

        // GET: Peluqueroes
        public ActionResult Index()
        {
            var peluqueros = db.Peluqueros;
            var modelos = Mapper.Map<IEnumerable<Peluquero>, IEnumerable<InfoPeluquero>>(peluqueros);

            return View(modelos);
        }

        // GET: Peluqueroes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peluquero peluquero = db.Peluqueros.Find(id);
            if (peluquero == null)
            {
                return HttpNotFound();
            }
            return View(peluquero);
        }

        // GET: Peluqueroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peluqueroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dni_Pel,nombre_Pel,apell_Pel,dir_Pel")] Peluquero peluquero)
        {
            if (ModelState.IsValid)
            {
                db.Peluqueros.Add(peluquero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peluquero);
        }

        // GET: Peluqueroes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peluquero peluquero = db.Peluqueros.Find(id);
            if (peluquero == null)
            {
                return HttpNotFound();
            }
            return View(peluquero);
        }

        // POST: Peluqueroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dni_Pel,nombre_Pel,apell_Pel,dir_Pel")] Peluquero peluquero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peluquero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peluquero);
        }

        // GET: Peluqueroes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peluquero peluquero = db.Peluqueros.Find(id);
            if (peluquero == null)
            {
                return HttpNotFound();
            }
            return View(peluquero);
        }

        // POST: Peluqueroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Peluquero peluquero = db.Peluqueros.Find(id);
            db.Peluqueros.Remove(peluquero);
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
