using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace BitSolutions.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Contato/

        public ActionResult Index()
        {
            return View();
        }

        private Boolean ValidaPreenchimento(string txtNome, string txtEmail, string txtMensagem)
        {
            if (txtNome.Equals(String.Empty))
            {
                return false;
            }
            if (txtEmail.Equals(String.Empty))
            {
                return false;
            }
            if (txtMensagem.Equals(String.Empty))
            {
                return false;
            }
            if (txtNome.Equals(String.Empty))
            {
                return false;
            }
            if (!txtEmail.Contains("@") || !txtEmail.Contains("."))
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public ActionResult Email(string txtNome, string txtEmail, string txtMensagem)
        {
            if (ValidaPreenchimento(txtNome, txtEmail, txtMensagem))
            {
                //Define os dados do e-mail
                string nomeRemetente = txtNome;
                string emailRemetente = "marcel.ogando@esolucoesdigitais.com";

                string emailDestinatario = "marcel.ogando@esolucoesdigitais.com";
                string emailComCopia = "marcelogando@gmail.com";
                string senha = "Twhccdc33f";

                string assuntoMensagem = "Uma nova mensagem de " + txtNome;
                string conteudoMensagem = txtMensagem.Replace(Environment.NewLine, "<br/>") + "<br/><br/> E-mail do remetente: " + txtEmail;

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

                    return Redirect("http://www.bitsolutions.net.br");
                }
                catch (Exception ex)
                {
                    // Mostra erro
                }
                finally
                {
                    objEmail.Dispose();
                }
            }
            else
            {
                // Instrui o usuário a preencher corretamente o formulário
            }

            return View();
        }

    }
}
