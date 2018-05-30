using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Filtros;
using CaelumEstoque.Models;
using Microsoft.Web.Infrastructure;




namespace CaelumEstoque.Controllers
{
    [AutorizacaoFilter] //Busca a autorização que criei na classe autorização, colocando antes da classe, irá servir para todas as actions
    // Posso colocar um filtro em toda requisição, podemos deixa-la global. => Veja app_star filterConfig
    public class ProdutoController : Controller
    {
        // GET: Produto

        [Route("produtos", Name = "ListaProdutos")] // Customiza a rota. No appStar veja a configuração na RoutConfig. Depois dei o nome para a rota.
        
        public ActionResult Index()

        {
            
            ProdutosDAO dao = new ProdutosDAO(); // Instacia as classes que usam o EntityFramework Core
            IList<Produto> produtos /*Busca uma lista de produtod*/ = dao.Lista(); // Faz um select em todos os produtos cadsatrados 

            return View(produtos);//Envia os dados para a view, Posso mandar os dados para a camada de visualização com "ViewBag" tambem.
            

           

        }

        public ActionResult Form()
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();// Busca a lista das categorias e envia para a camada de visualização
            IList<CategoriaDoProduto> categorias = categoriasDAO.Lista();
            ViewBag.Categorias = categorias;

            ViewBag.Produto = new Produto(); // Quando der o erro, o formulario tem que enviar dentro da viewBag preenchido.


            return View();
        }

        [HttpPost] // Só quero aceitar requisões do tipo "post".
        [ValidateAntiForgeryToken]// Se o token for valido adiona o produto, validando token.
        //Protegido contra o Cross Site Request Forgey

        public ActionResult Adiciona(Produto produto)// Recebe todas as informções do tipo produto, para funcionar o "name" do cshtml tem que ter as propriedade do "Produto".
        { 
            // Model Binder pega as requisições e transfoma no obejto que foi passado para a action.

            //Minhas próprias validações personalizadas. 
            int idInformatica = 1; // Regra customizada para informatica
            if(produto.CategoriaId.Equals(idInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.Invalido", "Informatica com o preço abaixo de R$100,00");
                // ModelState, contem todos erros de validação. Para adionar o novo erro usa o AddModelError. 
                //Dentro dos ("qual o nome do erro para recuperar a mensagem","Mensagem para o usuario")
            }
            

            if (ModelState.IsValid) // ModelState.IsValid verifica se obdece as regras de validação.
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);

                return RedirectToAction("Index", "Produto"); // Informar para action deve ser redirecinada. Action Index do ProdutoControler
            }
            else // Mesmo assim a lista de categorias deve ser mostrada no formulario.
            {
                ViewBag.Produto = produto; // Caso de errado, o formulario deve mostrar os dados preenchidos pelo o usuario.
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                return View("Form"); // Retorna o fomularios, no formulario irei colocar as regras de validação que foram violadas.
            }
           
        }

        [Route("produtos/{id}", Name = "VisualizaProduto")] // Customiza a rota. No appStar veja a configuração na RoutConfig. Depois dei o nome da rota
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;
            return View();
        }

        public ActionResult DecrementaQtd(int id)// Captura o Id.
        {
            ProdutosDAO dao = new ProdutosDAO(); // BUsca o produto no banco de dados
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--; // decrementa a quantidade
            dao.Atualiza(produto); // Atualiza o banco de dados
            return Json(produto);
            // Antes o servidor estava devolvendo um Redirect, para o javaScrip reconhecer deve devolver o um JSON
            // Json = JavaScript Objetc notecion
            // Ao inves devolver um obejto do c#, devolve um obejto do javaScript

            // Requisição Sincrona dentro a Web. Ao clicar espera a resposta do servidor.
            // Requisição Assincrina não espera a resposta. Tem que progrmar por javaScript pelo Ajax.
        }
    }
}