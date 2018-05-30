using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)// Executa antes das actions
        {
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            // httpContext guardar os dados da requisição atual que o asp.net está tradando
            //Usa a mesma session que posso acessar do controler
            if(usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Login", action = "Index" }
                        )
                    );
                // Se não estiver logado devo redirecionar o usuario
                // instanciar o RedirectToRouteResult, que funciona igual ao redicretToResult dos controler, porém ele não herda da classe controle.
                // RouteVAlueDictory informa para qual controler quero enviar o usuario, system.web.Routing
                // Devo criar um obejto anomino controller + action.


                // Posso colocar um filtro em toda requisição, podemos deixa-la global. => Veja app_star filterConfig
            }
        }
    }
}