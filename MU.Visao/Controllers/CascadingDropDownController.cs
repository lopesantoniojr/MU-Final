using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MU.Visao.Controllers
{
    public class CascadingDropDownController : Controller
    {
        //
        // GET: /CascadingDropDown/

        public ActionResult Index()
        {
            BindPaises();
            return View();
        }

        public JsonResult GetEstados(string id)
        {
            List<SelectListItem> estados = new List<SelectListItem>();
            estados.Add(new SelectListItem { Text = "Selecione", Value = "0" });
            switch (id)
            {
                case "2":
                    estados.Add(new SelectListItem { Text = "Minas Gerais", Value = "1" });
                    estados.Add(new SelectListItem { Text = "São Paulo", Value = "2" });
                    estados.Add(new SelectListItem { Text = "Rio de Janeiro", Value = "3" });
                    break;
            }
            return Json(new SelectList(estados, "Value", "Text"));
        }

        public JsonResult GetCidades(string id)
        {
            List<SelectListItem> cidades = new List<SelectListItem>();
            cidades.Add(new SelectListItem { Text = "Selecione", Value = "0" });
            switch (id)
            {
                case "1":
                    cidades.Add(new SelectListItem { Text = "Belo Horizonte", Value = "1" });
                    cidades.Add(new SelectListItem { Text = "Contagem", Value = "2" });
                    cidades.Add(new SelectListItem { Text = "Betim", Value = "3" });
                    cidades.Add(new SelectListItem { Text = "Ibirité", Value = "4" });
                    break;
                case "2":
                    cidades.Add(new SelectListItem { Text = "São Paulo", Value = "1" });
                    cidades.Add(new SelectListItem { Text = "São José dos Campos", Value = "2" });
                    cidades.Add(new SelectListItem { Text = "Campinas", Value = "3" });
                    break;
                case "3":
                    cidades.Add(new SelectListItem { Text = "Rio de Janeiro", Value = "1" });
                    cidades.Add(new SelectListItem { Text = "Niterói", Value = "2" });
                    cidades.Add(new SelectListItem { Text = "Cabo Frio", Value = "3" });
                    break;
            }

            return Json(new SelectList(cidades, "Value", "Text"));
        }

        [HttpPost]
        public ActionResult ClickBotao(FormCollection FC)
        {
            string pais = FC["ddlPais"].ToString();
            string estado = FC["ddlEstado"].ToString();
            string cidade = FC["ddlCidade"].ToString();

            BindPaises();
            return View();
        }

        private void BindPaises()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Selecione", Value = "0" });
            li.Add(new SelectListItem { Text = "Afeganistão", Value = "1" });
            li.Add(new SelectListItem { Text = "Brasil", Value = "2" });
            li.Add(new SelectListItem { Text = "Bolívia", Value = "3" });
            li.Add(new SelectListItem { Text = "Camarões", Value = "4" });
            li.Add(new SelectListItem { Text = "Colombia", Value = "5" });
            
            ViewData["pais"] = li;
        }
    }
}
