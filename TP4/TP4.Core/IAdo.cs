using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP4.Core;

namespace TP4.Core
{
    public interface IAdo
    {
        //Cliente
        void Altacliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
        Cliente ClientePorCuit(int Cuit);
        // proyecto
        void AltaProyecto(Proyecto proyecto);
        List<Cliente> ObtenerProyectos();
        Cliente ProyectoPorId(short IdProyecto);



        /* void AltaProyecto(Proyecto proyecto);
        List<Proyecto> ObtenerProyectos();

        void AltaRequerimiento(Requerimiento requerimiento);
        List<Requerimiento> ObtenerRequerimiento();*/
    }
}
//void AltaRubro(Rubro rubro);
//        List<Rubro> ObtenerRubros();
