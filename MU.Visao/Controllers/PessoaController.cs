using MU.Entidade;
using MU.MVVM;
using MU.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MU.Visao.Controllers
{
    public class PessoaController : Controller
    {
        PessoaNegocio pn = new PessoaNegocio();
        //
        // GET: /Pessoa/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel model)
        {
            if (ModelState.IsValid)
            {
                pn.Salvar(model);
                model.Salvou = true;
            }

            return View("Index", model);
        }

        public ActionResult ListarTodos()
        {
            return View(pn.Listar());
        }

        public ActionResult Apagar(long id)
        {
            pn.Deletar(id);
            return RedirectToAction("ListarTodos");
        }

        public ActionResult Editar(long id)
        {
            return View("Index", pn.Listar(id));
        }

        public PartialViewResult Detalhe(long id)
        {
            return PartialView("_Detalhe", pn.Listar(id));
        }
    }
}
