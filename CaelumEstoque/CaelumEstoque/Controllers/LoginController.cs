using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()// Mostra o login do usuario
        {
            return View();
        }

        public ActionResult Autentica(String login, String senha)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuario usuario = dao.Busca(login, senha); // Busca o login e senha no bd



            if (usuario !=null) //Se for diferente de nulo, ele existe no banco de dados
            {
                Session["usuarioLogado"] = usuario; // Quardar dentro de uma seção
                return RedirectToAction("index", "Produto"); // Manda para a lista dos produtos
            }
            else
            {
                
                return RedirectToAction("index");// manda de volta para a pagina de login.
                
            }
        }
    }

}