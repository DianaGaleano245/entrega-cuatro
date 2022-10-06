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

        void AltaProyecto(Proyecto proyecto);
        List<Proyecto> ObtenerProyectos();

        void AltaRequerimiento(Requerimineto requerimineto );
        List<Requerimineto> ObtenerRequerimiento();
    }
}
//void AltaRubro(Rubro rubro);
//        List<Rubro> ObtenerRubros();
