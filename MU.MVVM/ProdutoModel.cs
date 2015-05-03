using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MU.MVVM
{
    public class ProdutoModel
    {
        [Display(Name="Código:")]
        public long? IdProduto { get; set; }
        
        [Display(Name="Descrição:")]
        [Required(ErrorMessage="Favor informar a Descrição")]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }

        [Display(Name = "Unidade:")]
        [Required(ErrorMessage = "Favor informar a Unidade")]
        [DataType(DataType.Text)]
        [StringLength(10)]
        public string Unidade { get; set; }

        [Display(Name = "Preço:")]
        [Required(ErrorMessage = "Favor informar o Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Display(Name = "Data de Validade:")]
        public DateTime? DataValidade { get; set; }
    }
}
