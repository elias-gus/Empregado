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
    public class EmpregadosController : Controller
    {
        private db_230579Entities db = new db_230579Entities();

        // GET: Empregadoes
        public ActionResult Index()
        {
            var empregado = db.Empregado.Include(e => e.Dependente);
            return View(empregado.ToList());
        }

        // GET: Empregadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = db.Empregado.Find(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            return View(empregado);
        }

        // GET: Empregadoes/Create
        public ActionResult Create()
        {
            ViewBag.id_dependente = new SelectList(db.Dependente, "id_dependente", "nome");
            return View();
        }

        // POST: Empregadoes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_empregado,nome,matrícula,cpf,endereço,id_dependente")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                db.Empregado.Add(empregado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_dependente = new SelectList(db.Dependente, "id_dependente", "nome", empregado.id_dependente);
            return View(empregado);
        }

        // GET: Empregadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = db.Empregado.Find(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dependente = new SelectList(db.Dependente, "id_dependente", "nome", empregado.id_dependente);
            return View(empregado);
        }

        // POST: Empregadoes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_empregado,nome,matrícula,cpf,endereço,id_dependente")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empregado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_dependente = new SelectList(db.Dependente, "id_dependente", "nome", empregado.id_dependente);
            return View(empregado);
        }

        // GET: Empregadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = db.Empregado.Find(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            return View(empregado);
        }

        // POST: Empregadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empregado empregado = db.Empregado.Find(id);
            db.Empregado.Remove(empregado);
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
