using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP4
{
    public interface IAdo
    {
        void altacliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
    }
}
//void AltaRubro(Rubro rubro);
//        List<Rubro> ObtenerRubros();
