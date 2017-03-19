using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitSolutions.Models;

namespace BitSolutions.Controllers
{
    public class TwitterController : Controller
    {
        UsuarioContext ctxUsuario = new UsuarioContext();

        public ActionResult Index(String msg)
        {
            ctxUsuario.InsereTwitter(msg);
            return RedirectToAction("Index", "Home");
        }

    }
}
