using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MU.MVVM
{
    public class PessoaFisicaModel : PessoaModel
    {
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        public string CPF { get; set; }
    }
}
