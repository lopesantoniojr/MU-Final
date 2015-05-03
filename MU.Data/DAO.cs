using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MU.Dados
{
    public abstract class DAO<T> where T : class
    {
        public T Salvar(T entidade)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entidade);
                    transaction.Commit();
                }
            }

            return entidade;
        }

        public bool Deletar(long id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    T entidade = session.Get<T>(id);
                    session.Delete(entidade);
                    transaction.Commit();
                }
            }
            return true;
        }

        public T ObterPorId(long id)
        {
            T entidade;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                    entidade = session.Get<T>(id);
            }

            return entidade;
        }

        public IList<T> ObterTodos()
        {
            IList<T> entidades;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                    entidades = session.QueryOver<T>().List();
            }

            return entidades;
        }

        public IList<T> ObterPorFiltro(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IList<T> pRetorno = new List<T>();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    pRetorno = session.QueryOver<T>().Where(predicate).List();
                }
            }

            return pRetorno;
        }
                
        //T Obter(Expression<Func<T, bool>> selectQuery)
        //{
        //    using (var session = NHibernateHelper.OpenSession())
        //    {
        //        return (from x in session.QueryOver<T>() where selectQuery(x) select x).FirstOrDefault();
        //    }
        //}
    }
}
