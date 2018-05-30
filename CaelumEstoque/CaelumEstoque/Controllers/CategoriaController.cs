using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Filtros;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{   [AutorizacaoFilter]
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categoria = dao.Lista();
            ViewBag.Categorias = categoria;

            return View();
        }
        public ActionResult Form()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// Se o token for valido adiona o produto, validando token.
        public ActionResult Adiciona(CategoriaDoProduto categorias)
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            categoriasDAO.Adiciona(categorias);

            return RedirectToAction("Index", "Categoria");
        }
    }
}