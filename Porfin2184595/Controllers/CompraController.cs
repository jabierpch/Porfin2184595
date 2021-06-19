using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using Porfin2184595.Models;

namespace WebApplication1.Controllers
{
    public class CompraController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {

                return View(db.compra.ToList());
            }
        }
        public static string NombreUsuario(int idcliente)
        {
            using (var db = new inventario2021Entities())
            {
                return db.compra.Find(idcliente).nombre;
            }
        }
        public ActionResult ListarUsuarios()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }
        public static string NombreCliente(int idCliente)
        {
            using (var db = new inventario2021Entities())
            {
                return db.cliente.Find(idCliente).nombre;
            }
        }
        public ActionResult ListarClientes()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.cliente.ToList());
            }
        }
        public ActionResult Create()

        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra newCompra)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.compra.Add(newCompra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError("", "error" + Ex);
                return View();
            }
        }
        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public ActionResult Edit(int id)
        {

            try
            {
                using (var db = new inventario2021Entities())
                {
                    compra findUser = db.compra.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);
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
        public ActionResult Edit(compra compraEdit)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    compra user = db.compra.Find(compraEdit.id);
                    user.fecha = compraEdit.fecha;
                    user.total = compraEdit.total;



                    db.SaveChanges();
                    return RedirectToAction("index");
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
                compra user = db.compra.Find(id);
                return View(user);
            }
        }
        public ActionResult Delete(int id)
        {
            using (inventario2021Entities db = new inventario2021Entities())
            {
                var Usuario = db.compra.Find(id);
                db.compra.Remove(Usuario);
                db.SaveChanges();
                return RedirectToAction("index");
            }
        }
    }
}