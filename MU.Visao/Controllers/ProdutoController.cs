using MU.MVVM;
using MU.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MU.Visao.Controllers
{
    public class ProdutoController : Controller
    {
        //
        // GET: /Produto/
        ProdutoNegocio pn = new ProdutoNegocio();
        public ActionResult Index()
        {
            return View(pn.Listar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                pn.Salvar(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(long id)
        {
            pn.Deletar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(long id)
        {
            return View("Create", pn.Listar(id));
        }
    }
}
