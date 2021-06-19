using System;
using System.Linq;
using System.Web.Mvc;
using Porfin2184595.Models;


namespace Porfin2184595.Controllers
{
    public class UsuarioRolController : Controller
    {
        // GET: UsuarioRol
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.usuariorol.ToList());
            }
        }

        public static string Nombreusuario(int idusuario)
        {
            using (var db = new inventario2021Entities())
            {
                return db.usuario.Find(idusuario).nombre;
            }
        }

        public ActionResult ListarNombreusuario()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }


        public static string Nombrerol(int idrol)
        {
            using (var db = new inventario2021Entities())
            {
                return db.roles.Find(idrol).descripcion;
            }
        }
        public ActionResult ListarNombrerol()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.roles.ToList());
            }
        }
        public ActionResult Create()

        {
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(usuariorol newUsuariorol)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.usuariorol.Add(newUsuariorol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                usuariorol productoDetalle = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                return View(productoDetalle);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var usariorolDelete = db.usuariorol.Find(id);
                db.usuariorol.Remove(usariorolDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    usuariorol usuariorol = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                    return View(usuariorol);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(usuariorol usuariorolEdit)
        {

            try
            {
                using (var db = new inventario2021Entities())
                {
                    var usuariorol = db.usuariorol.Find(usuariorolEdit.id);
                    usuariorol.usuario = usuariorolEdit.usuario;
                    usuariorol.roles = usuariorolEdit.roles;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
    }
}