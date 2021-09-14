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
    public class UserController : Controller
    {
        private UsuariosEntities db = new UsuariosEntities();

        // GET: User
        public async Task<ActionResult> Index()
        {
            var tb_user = db.tb_user.Include(t => t.tb_ciudad).Include(t => t.tb_departamento);
            return View(await tb_user.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_user tb_user = await db.tb_user.FindAsync(id);
            if (tb_user == null)
            {
                return HttpNotFound();
            }
            return View(tb_user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.ciudad = new SelectList(db.tb_ciudad, "id", "ciudad");
            ViewBag.departamento = new SelectList(db.tb_departamento, "id", "departamento");
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,documento,celular,correo,ciudad,departamento")] tb_user tb_user)
        {
            if (ModelState.IsValid)
            {
                db.tb_user.Add(tb_user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ciudad = new SelectList(db.tb_ciudad, "id", "ciudad", tb_user.ciudad);
            ViewBag.departamento = new SelectList(db.tb_departamento, "id", "departamento", tb_user.departamento);
            return View(tb_user);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_user tb_user = await db.tb_user.FindAsync(id);
            if (tb_user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ciudad = new SelectList(db.tb_ciudad, "id", "ciudad", tb_user.ciudad);
            ViewBag.departamento = new SelectList(db.tb_departamento, "id", "departamento", tb_user.departamento);
            return View(tb_user);
        }

        // POST: User/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,documento,celular,correo,ciudad,departamento")] tb_user tb_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ciudad = new SelectList(db.tb_ciudad, "id", "ciudad", tb_user.ciudad);
            ViewBag.departamento = new SelectList(db.tb_departamento, "id", "departamento", tb_user.departamento);
            return View(tb_user);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_user tb_user = await db.tb_user.FindAsync(id);
            if (tb_user == null)
            {
                return HttpNotFound();
            }
            return View(tb_user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_user tb_user = await db.tb_user.FindAsync(id);
            db.tb_user.Remove(tb_user);
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
