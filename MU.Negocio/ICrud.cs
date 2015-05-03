using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU.Negocio
{
    interface ICrud<E, M>
    {
        M Salvar(M model);
        bool Deletar(long id);
        List<M> Listar();
        M Listar(long id);
    }
}
