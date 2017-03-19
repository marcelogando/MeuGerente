using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace BitSolutions.Controllers
{
    public class EmailCaixaController : Controller
    {
        //
        // GET: /EmailCaixa/

        public ActionResult Index(String valor)
        {
            //Define os dados do e-mail
            string nomeRemetente = "Nova passagem barata!";
            string emailRemetente = "marcel.ogando@esolucoesdigitais.com";

            string emailDestinatario = "marcelogando@gmail.com";
            string emailComCopia = "marinacrepaldi93@gmail.com";
            string senha = "Twhccdc33f";

            string assuntoMensagem = "Uma nova passagem barata! R$ " + valor;
            string conteudoMensagem = "Ueba! Mais uma passagem barata no Decolar.com. Dessa vez, vai de São Paulo pra Roma. Sai dia 29 de maio e volta dia 15 de junho. Valor: R$ " + valor;

            //Host da porta SMTP
            string SMTP = "smtp.esolucoesdigitais.com";

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            objEmail.To.Add(emailDestinatario);

            //Enviar cópia para.
            objEmail.CC.Add(emailComCopia);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = assuntoMensagem;

            //Define o corpo do e-mail.
            objEmail.Body = conteudoMensagem;


            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails  
            objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, senha);
            objSmtp.Host = SMTP;
            objSmtp.Port = 587;
            //Caso utilize conta de email do exchange da locaweb deve habilitar o SSL
            //objEmail.EnableSsl = true;

            //Enviamos o e-mail através do método .send()
            try
            {
                objSmtp.Send(objEmail);
                // Foi!

                return View();
            }
            catch (Exception ex)
            {
                // Mostra erro
            }
            finally
            {
                objEmail.Dispose();
            }
            return View();
        }

    }
}
