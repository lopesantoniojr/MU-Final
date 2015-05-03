using MU.Entidade;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MU.Dados
{
    public class PessoaDAO : DAO<PessoaEntidade>
    {
        public PessoaEntidade ObterPorNome(string nome)
        {
            PessoaEntidade pRetorno = new PessoaEntidade();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    pRetorno = (from p in session.QueryOver<PessoaEntidade>()
                                where p.Nome == nome
                                select p).List().FirstOrDefault();
                }
            }

            return pRetorno;
        }

        public IList<PessoaEntidade> ObterPorFiltro(PessoaEntidade filtro)
        {
            IList<PessoaEntidade> pRetorno = new List<PessoaEntidade>();

            using (var session = NHibernateHelper.OpenSession())
            {
                ICriteria c = session.CreateCriteria<PessoaEntidade>();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (filtro.OID > 0)
                        c.Add(NHibernate.Criterion.Restrictions.Eq("OID", filtro.OID));

                    if (!string.IsNullOrWhiteSpace(filtro.Nome))
                        c.Add(NHibernate.Criterion.Restrictions.Eq("Nome", filtro.Nome));

                    pRetorno = c.List<PessoaEntidade>();
                }
            }

            return pRetorno;
        }
    }
}
