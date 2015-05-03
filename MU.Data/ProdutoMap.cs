using FluentNHibernate.Mapping;
using MU.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.Dados
{
    public class ProdutoMap : ClassMap<ProdutoEntidade>
    {
        public ProdutoMap()
        {
            Table("TB_PRODUTO");
            LazyLoad();
            Id(x => x.IdProduto).GeneratedBy.Identity().Column("ID_PRODUTO");
            Map(entidade => entidade.Descricao).Column("DESC_PRODUTO").Not.Nullable();
            Map(entidade => entidade.Unidade).Column("UNIDADE").Not.Nullable();
            Map(entidade => entidade.Preco).Column("PRECO").Not.Nullable();
            Map(entidade => entidade.DataValidade).Column("DATA_VALIDADE");
        }
    }
}
