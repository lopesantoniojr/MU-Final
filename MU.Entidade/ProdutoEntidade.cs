using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU.Entidade
{
    public class ProdutoEntidade
    {
        public virtual long IdProduto { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Unidade { get; set; }
        public virtual decimal Preco { get; set; }
        public virtual DateTime? DataValidade { get; set; }
    }
}
