using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplicacion_BDPeluqueria.BaseDatos;
using Aplicacion_BDPeluqueria.Models.Reservas;
using AutoMapper;

namespace Aplicacion_BDPeluqueria.Controllers
{
    public class ReservasController : Controller
    {
        private BDPeluqueriaEntities1 db = new BDPeluqueriaEntities1();

        // GET: Reservas
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.Cliente).Include(r => r.Peluquero);
            var modelos = Mapper.Map<IEnumerable<Reserva>, IEnumerable<InfoReserva>>(reservas);

            return View(modelos);
        }

        // GET: Reservas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }
      
        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.dni_Cli = new SelectList(db.Clientes, "dni_Cli", "nombre_Cli");
            ViewBag.dni_Pel = new SelectList(db.Peluqueros, "dni_Pel", "nombre_Pel");
            ViewBag.id_Prod = new SelectList(db.Productos, "id_Prod", "nombre_Prod");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "num_Res,dni_Cli,dni_Pel")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dni_Cli = new SelectList(db.Clientes, "dni_Cli", "nombre_Cli", reserva.dni_Cli);
            ViewBag.dni_Pel = new SelectList(db.Peluqueros, "dni_Pel", "nombre_Pel", reserva.dni_Pel);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.dni_Cli = new SelectList(db.Clientes, "dni_Cli", "nombre_Cli", reserva.dni_Cli);
            ViewBag.dni_Pel = new SelectList(db.Peluqueros, "dni_Pel", "nombre_Pel", reserva.dni_Pel);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "num_Res,dni_Cli,dni_Pel")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dni_Cli = new SelectList(db.Clientes, "dni_Cli", "nombre_Cli", reserva.dni_Cli);
            ViewBag.dni_Pel = new SelectList(db.Peluqueros, "dni_Pel", "nombre_Pel", reserva.dni_Pel);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
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
