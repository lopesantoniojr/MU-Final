using MU.Dados;
using MU.Entidade;
using MU.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.Negocio
{
    public class ProdutoNegocio : ICrud<ProdutoEntidade, ProdutoModel>
    {
        ProdutoDAO dao = new ProdutoDAO();
        public ProdutoModel Salvar(ProdutoModel model)
        {
            ProdutoEntidade pe = new ProdutoEntidade();
            pe.DataValidade = model.DataValidade;
            pe.Descricao = model.Descricao;
            pe.IdProduto = model.IdProduto.HasValue ? model.IdProduto.Value : 0;
            pe.Preco = model.Preco;
            pe.Unidade = model.Unidade;

            dao.Salvar(pe);
            return model;
        }

        public bool Deletar(long id)
        {
            return dao.Deletar(id);
        }

        public List<ProdutoModel> Listar()
        {
            List<ProdutoModel> model = new List<ProdutoModel>();
            var entidades = dao.ObterTodos().OrderBy(x => x.IdProduto);
            Parallel.ForEach(entidades, x =>
                                model.Add(new ProdutoModel
                                {
                                    DataValidade = x.DataValidade,
                                    Descricao = x.Descricao,
                                    IdProduto = x.IdProduto,
                                    Preco = x.Preco,
                                    Unidade = x.Unidade
                                })
                            );

            return model;
        }

        public ProdutoModel Listar(long id)
        {
            ProdutoModel retorno = new ProdutoModel();
            var entidade = dao.ObterPorId(id);
            retorno.IdProduto = entidade.IdProduto;
            retorno.Preco = entidade.Preco;
            retorno.DataValidade = entidade.DataValidade;
            retorno.Descricao = entidade.Descricao;
            retorno.Unidade = entidade.Unidade;

            return retorno;
        }
    }
}
