using FluentNHibernate.Mapping;
using MU.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU.Dados
{
    public class PessoaFisicaMap : SubclassMap<PessoaFisicaEntidade>
    {
        public PessoaFisicaMap()
        {
            Table("TB_PESSOA_FISICA");

            Map(p => p.DataNascimento)
                .Column("DT_NASCIMENTO")
                .Not.Nullable();

            Map(p => p.CPF)
                .Column("CPF")
                .Length(11).
                Not.Nullable();

            //Irá gerar a coluna na sub-classe com o nome que for informado
            KeyColumn("ID_PESSOA");
        }
    }
}
