using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MU.MVVM
{
    public class PessoaModel
    {
        [Display(Name="Código:")]
        public long? OID { get; set; }
        
        [Display(Name="Nome Completo:")]
        [Required(ErrorMessage="Favor informar o Nome Completo")]
        [DataType(DataType.Text)]
        [StringLength(300)]
        public string Nome { get; set; }

        public DateTime? CriadoEm { get; set; }
        public bool Salvou { get; set; }
        public long CID { get; set; }
    }
}
