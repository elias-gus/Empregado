using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DependentesController : Controller
    {
        private db_230579Entities db = new db_230579Entities();

        // GET: Dependentes
        public ActionResult Index()
        {
            return View(db.Dependente.ToList());
        }

        // GET: Dependentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependente dependente = db.Dependente.Find(id);
            if (dependente == null)
            {
                return HttpNotFound();
            }
            return View(dependente);
        }

        // GET: Dependentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dependentes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dependente,nome,cpf,endereço,data_nasc")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                db.Dependente.Add(dependente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dependente);
        }

        // GET: Dependentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependente dependente = db.Dependente.Find(id);
            if (dependente == null)
            {
                return HttpNotFound();
            }
            return View(dependente);
        }

        // POST: Dependentes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dependente,nome,cpf,endereço,data_nasc")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dependente);
        }

        // GET: Dependentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependente dependente = db.Dependente.Find(id);
            if (dependente == null)
            {
                return HttpNotFound();
            }
            return View(dependente);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dependente dependente = db.Dependente.Find(id);
            db.Dependente.Remove(dependente);
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
