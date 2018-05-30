using CaelumEstoque.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AutorizacaoFilterAttribute()); // Adicionei filtro global para todas requisições
            // Mas para isso funcionar devo adionar o FIlterCOnfig no arquivo Global.asax

            //Marquei o filters.add pois senão teria problema até pra validar o Login
        }
    }
}