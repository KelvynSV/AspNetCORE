using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCORE.Models;
using AspNetCORE.Library.Mail;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCORE.Controllers
{
    public class ContatoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Contato = new Contato();
            return View();
        }

        public IActionResult ReceberContato([FromForm]Contato contato)
        {
            if (ModelState.IsValid)
            {
                //string conteudo = String.Format("Nome: {0}, E-mail: {1}, Assunto: {2}, Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);
                // return new ContentResult() { Content = conteudo };

                ViewBag.Contato = new Contato();
                EnviarEmail.EnviarMensagemContato(contato);
                ViewBag.Mensagem = "Mensagem ennviada com sucesso!";
                return View("Index");
                //Teste GitHub123456

            }
            else
            {
                ViewBag.Contato = contato;

                return View("Index");
            }
        }

        /*
        public IActionResult ReceberContato()
        {
            Contato contato = new Contato();

            contato.Nome = Request.Form["nome"];
            contato.Email = Request.Form["email"];
            contato.Assunto = Request.Form["assunto"];
            contato.Mensagem = Request.Form["mensagem"];

            string conteudo = String.Format("Nome: {0}, E-mail: {1}, Assunto: {2}, Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);

            return new ContentResult() { Content = conteudo };
        }
        */

    }
}
