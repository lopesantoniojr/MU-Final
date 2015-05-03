using FluentNHibernate.Mapping;
using MU.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU.Dados
{
    public class PessoaMap : ClassMap<PessoaEntidade>
    {
        public PessoaMap()
        {
            Table("TB_PESSOA");

            Id(p => p.OID)
                .Column("ID_PESSOA")
                .GeneratedBy.Identity();

            Map(p => p.CID)
                .Column("CID")
                .Not.Nullable();

            Map(p => p.Nome)
                .Column("NOME_PESSOA")
                .Length(300).
                Not.Nullable();

            Map(p => p.CriadoEm)
                .Column("DT_CRIACAO")
                .CustomType<DateTime>()
                .Not.Nullable();

            Map(p => p.AtualizadoEm)
                .Column("DT_ALTERACAO")
                .CustomType<DateTime>();
        }
    }
}
