using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU.Entidade
{
    public class PessoaFisicaEntidade : PessoaEntidade
    {
        public virtual DateTime DataNascimento { get; set; }
        public virtual string CPF { get; set; }
    }
}
