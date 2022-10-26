using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP4.Core;

namespace TP4
{
    public interface IAdo
    {
        void altacliente(Cliente cliente);
        List<Cliente> ObtenerClientes();

        /* void AltaProyecto(Proyecto proyecto);
         List<Proyecto> ObtenerProyectos();

         void AltaRequerimiento(Requerimiento requerimiento);
         List<Requerimiento> ObtenerRequerimiento();*/
    }
}
//void AltaRubro(Rubro rubro);
//        List<Rubro> ObtenerRubros();
