using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitSolutions.Models;

namespace BitSolutions.Controllers
{
    public class gamaController : Controller
    {
        UsuarioContext ctxUsuario = new UsuarioContext();

        public ActionResult Index()
        {
            UsuarioETT usuario = new UsuarioETT();
            usuario.Email = Request["tEmail"];
            usuario.Estado = Request["estados"];
            usuario.Genero = Request["hfGenero"];
            usuario.Nome = Request["tNome"];
            usuario.Sobrenome = Request["tSobrenome"];
            usuario.Idade = Request["hfIdade"];

            ctxUsuario.InsereUsuario(usuario);
            return Redirect("http://www.bitsolutions.net.br/GamaExp/final.html");
        }
    }
}
