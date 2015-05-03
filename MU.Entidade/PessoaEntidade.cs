using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU.Entidade
{
    public class PessoaEntidade
    {
        public virtual long? OID { get; set; }
        public virtual long CID { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime? CriadoEm { get; set; }
        public virtual Nullable<DateTime> AtualizadoEm { get; set; }
    }
}
