using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitSolutions.Models;

namespace BitSolutions.Controllers
{
    public class EMTUController : Controller
    {
        UsuarioContext ctxUsuario = new UsuarioContext();

        public ActionResult Index()
        {
            List<TwitterETT> lstTwitter = ctxUsuario.RetornaUsuario();
            return View(lstTwitter);
        }
    }
}
