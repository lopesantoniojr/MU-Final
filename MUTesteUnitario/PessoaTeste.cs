using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MU.Negocio;
using MU.MVVM;

namespace MUTesteUnitario
{
    [TestClass]
    public class PessoaTeste
    {
        [TestMethod]
        public void ObterPorCIDeNome()
        {
            PessoaNegocio pn = new PessoaNegocio();
            PessoaModel filtro = new PessoaModel();
            filtro.OID = 3;
            filtro.Nome = "Joao";
            var pessoas = pn.Listar(filtro);
            Assert.IsNotNull(pessoas);
        }
    }
}
