using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastra(Usuario usuario)
        {
            UsuariosDAO dao = new UsuariosDAO();
            dao.Adiciona(usuario);
            return RedirectToAction("index", "Login");
        }
    }
}