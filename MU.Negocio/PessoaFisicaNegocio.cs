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
    public class PessoaFisicaNegocio : ICrud<PessoaFisicaEntidade, 
                                                PessoaFisicaModel>
    {
        PessoaFisicaDAO dao = new PessoaFisicaDAO();
        public PessoaFisicaModel Salvar(PessoaFisicaModel pf)
        {
            PessoaFisicaEntidade entidade = new PessoaFisicaEntidade();
            entidade.Nome = pf.Nome;
            entidade.OID = pf.OID;
            entidade.CPF = pf.CPF;
            entidade.DataNascimento = pf.DataNascimento;
            if (pf.OID > 0)
            {
                entidade.AtualizadoEm = DateTime.Now;
                entidade.CriadoEm = pf.CriadoEm;
            }
            else
                entidade.CriadoEm = DateTime.Now;

            dao.Salvar(entidade);
            return pf;
        }

        public List<PessoaFisicaModel> Listar()
        {
            List<PessoaFisicaModel> model = new List<PessoaFisicaModel>();
            var entidades = dao.ObterTodos();
            Parallel.ForEach(entidades, x =>
                                model.Add(new PessoaFisicaModel
                                {
                                    OID = x.OID,
                                    Nome = x.Nome,
                                    CPF = x.CPF,
                                    DataNascimento = x.DataNascimento
                                })
                            );

            return model;
        }

        public bool Deletar(long id)
        {
            return dao.Deletar(id);
        }

        public PessoaFisicaModel Listar(long id)
        {
            var entidade = dao.ObterPorId(id);
            PessoaFisicaModel model = new PessoaFisicaModel();
            model.OID = entidade.OID;
            model.Nome = entidade.Nome;
            model.CriadoEm = entidade.CriadoEm;

            return model;
        }
    }
}
