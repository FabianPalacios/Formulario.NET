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
    public class CiudadController : Controller
    {
        private UsuariosEntities db = new UsuariosEntities();

        // GET: Ciudad
        public async Task<ActionResult> Index()
        {
            var tb_ciudad = db.tb_ciudad.Include(t => t.tb_departamento);
            return View(await tb_ciudad.ToListAsync());
        }

        // GET: Ciudad/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = await db.tb_ciudad.FindAsync(id);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudad);
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            ViewBag.departamento = new SelectList(db.tb_departamento, "id", "departamento");
            return View();
        }

        // POST: Ciudad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ciudad,departamento")] tb_ciudad tb_ciudad)
        {
            if (ModelState.IsValid)
            {
                db.tb_ciudad.Add(tb_ciudad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.departamento = new SelectList(db.tb_departamento, "id", "departamento", tb_ciudad.departamento);
            return View(tb_ciudad);
        }

        // GET: Ciudad/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = await db.tb_ciudad.FindAsync(id);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.departamento = new SelectList(db.tb_departamento, "id", "departamento", tb_ciudad.departamento);
            return View(tb_ciudad);
        }

        // POST: Ciudad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ciudad,departamento")] tb_ciudad tb_ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ciudad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.departamento = new SelectList(db.tb_departamento, "id", "departamento", tb_ciudad.departamento);
            return View(tb_ciudad);
        }

        // GET: Ciudad/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = await db.tb_ciudad.FindAsync(id);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_ciudad tb_ciudad = await db.tb_ciudad.FindAsync(id);
            db.tb_ciudad.Remove(tb_ciudad);
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
