using CRUDAjax.UI; 
using CRUDAjax.UI.Models.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 

namespace CRUDAjax.Controllers
{
    public class AppController : Controller
    {
        // GET: Teste
        //ACTION do nosso APP
        public ActionResult Index()
        {
            return View();

        }

        //Informamos no Atributo HTTPPOST que será uma requisição deste tipo
        [HttpPost]
        public void Cadastrar(PessoaModel pessoa)
        {
            try
            {
                new PessoaNeg().Cadastrar(pessoa);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var pessoa = new PessoaNeg().GetById(id);
                //para retornar ao ajax, temos que enviar nosso objeto em formato JSON, e LIBERA-LO
                //Para a requisicao GET
                return Json(pessoa, JsonRequestBehavior.AllowGet);


            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public void Atualizar(PessoaModel pessoa)
        {
            try
            {
                new PessoaNeg().Atualizar(pessoa); 

            }
            catch (Exception)
            {

                throw;
            }

        }


        public void Deletar(int id)
        {
            try
            {
                new PessoaNeg().Deletar(id); 
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult Listar()
        {
            try
            {
                var listPessoas = new PessoaNeg().Listar();
                //para retornar ao ajax, temos que enviar nosso objeto em formato JSON, e LIBERA-LO
                //Para a requisicao GET
                return Json(listPessoas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}