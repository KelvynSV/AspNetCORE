using AspNetCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AspNetCORE.Library.Mail
{
    public class EnviarEmail
    {
        public static void EnviarMensagemContato(Contato contato)
        {
            string conteudo = String.Format("Nome: {0}<br /> E-mail: {1}<br /> Assunto: {2}<br /> Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);

            SmtpClient smtp = new SmtpClient(Constants.ServidorSMTP,Constants.PortaSMTP);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Constants.Usuario,Constants.Senha);

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("kelvynsilva37@gmail.com");
            mensagem.To.Add("kelvynsilva37@gmail.com");
            mensagem.Subject = "Formulário de contato";

            mensagem.IsBodyHtml = true;
            mensagem.Body = "<h1>Formulário de contato</h1>" + conteudo;

            smtp.Send(mensagem);
        }
    }
}
