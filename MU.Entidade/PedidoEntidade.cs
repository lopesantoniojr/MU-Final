using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU.Entidade
{
    public class PedidoEntidade
    {
        public long OID { get; set; }
        public DateTime DataPedido { get; set; }
        public List<Item> Itens { get; set; }
        public PessoaEntidade Pessoa { get; set; }
    }
}
