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

        List<Proyecto> ProyectosDelCliente(int Cuit);
        // proyecto
        void AltaProyecto(Proyecto proyecto);
        List<Proyecto> ObtenerProyectos();
        Proyecto ProyectoPorId(short IdProyecto);

        void AltaRequerimiento(Requerimiento requerimiento);
        List<Requerimiento> ObtenerRequerimiento();
        Requerimiento RequerimientoPorId(int IdRequerimiento);

        void AltaTecnologia(Tecnologia tecnologia);
        List<Tecnologia> ObtenerTecnologia();
        Tecnologia TecnologiaPorId(byte idTecnologia);


    }
}

