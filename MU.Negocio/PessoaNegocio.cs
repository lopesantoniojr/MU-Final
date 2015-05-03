using MU.Dados;
using MU.Entidade;
using MU.MVVM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MU.Negocio
{
    public class PessoaNegocio : ICrud<PessoaEntidade, PessoaModel>
    {
        PessoaDAO dao = new PessoaDAO();
        public PessoaModel Salvar(PessoaModel p)
        {
            PessoaEntidade entidade = new PessoaEntidade();
            entidade.Nome = p.Nome;
            entidade.OID = p.OID;
            if (p.OID > 0)
            {
                entidade.AtualizadoEm = DateTime.Now;
                entidade.CriadoEm = p.CriadoEm;
            }
            else
                entidade.CriadoEm = DateTime.Now;

            dao.Salvar(entidade);
            return p;
        }

        public List<PessoaModel> Listar()
        {
            List<PessoaModel> model = new List<PessoaModel>();
            var entidades = dao.ObterTodos();
            Parallel.ForEach(entidades, x =>
                                model.Add(new PessoaModel
                                {
                                    OID = x.OID,
                                    Nome = x.Nome
                                })
                            );

            return model;
        }

        public bool Deletar(long id)
        {
            return dao.Deletar(id);
        }

        public PessoaModel Listar(long id)
        {
            var entidade = dao.ObterPorId(id);
            PessoaModel model = new PessoaModel();
            model.OID = entidade.OID;
            model.Nome = entidade.Nome;
            model.CriadoEm = entidade.CriadoEm;

            return model;
        }

        public PessoaModel Listar(PessoaModel filtro)
        {
            PessoaModel pRetorno = new PessoaModel();
            IList<PessoaEntidade> p = new List<PessoaEntidade>();
            PessoaEntidade entidade = new PessoaEntidade();
            entidade.Nome = filtro.Nome;
            entidade.OID = filtro.OID;
            entidade.CID = filtro.CID;
            
            p = dao.ObterPorFiltro(entidade);
            
            if (p.Count > 0)
            {
                pRetorno.OID = p[0].OID;
                pRetorno.Nome = p[0].Nome;
                pRetorno.CID = p[0].CID;
            }
            return pRetorno;
        }
    }
}
