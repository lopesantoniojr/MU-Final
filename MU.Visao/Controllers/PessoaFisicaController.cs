using MU.MVVM;
using MU.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MU.Visao.Controllers
{
    public class PessoaFisicaController : Controller
    {
        PessoaFisicaNegocio pfn = new PessoaFisicaNegocio();
        //
        // GET: /PessoaFisica/

        public ActionResult Index()
        {
            return View(pfn.Listar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(PessoaFisicaModel model)
        {
            pfn.Salvar(model);
            return View();
        }

    }
}
