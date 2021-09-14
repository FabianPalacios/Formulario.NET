using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Formulario.ModeloBD;

namespace Formulario.Controllers.Parameters
{
    public class DepartamentoController : Controller
    {
        private UsuariosEntities db = new UsuariosEntities();

        // GET: Departamento
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_departamento.ToListAsync());
        }

        // GET: Departamento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamento tb_departamento = await db.tb_departamento.FindAsync(id);
            if (tb_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamento);
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,departamento")] tb_departamento tb_departamento)
        {
            if (ModelState.IsValid)
            {
                db.tb_departamento.Add(tb_departamento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_departamento);
        }

        // GET: Departamento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamento tb_departamento = await db.tb_departamento.FindAsync(id);
            if (tb_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamento);
        }

        // POST: Departamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,departamento")] tb_departamento tb_departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_departamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_departamento);
        }

        // GET: Departamento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamento tb_departamento = await db.tb_departamento.FindAsync(id);
            if (tb_departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_departamento tb_departamento = await db.tb_departamento.FindAsync(id);
            db.tb_departamento.Remove(tb_departamento);
            await db.SaveChangesAsync();
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
