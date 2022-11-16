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
        Task AltaclienteAsync(Cliente cliente);
        Task<List<Cliente>> ObtenerClientesAsync();
        Cliente ClientePorCuit(int Cuit);

        Task<List<Proyecto>> ProyectosDelClienteAsync(int Cuit);
        // proyecto
        Task AltaProyectoAsync(Proyecto proyecto);
        Task<List<Proyecto>> ObtenerProyectosAsync();
        Proyecto ProyectoPorId(short IdProyecto);

        //Requerimiento
        Task AltaRequerimientoAsync(Requerimiento requerimiento);
        Task<List<Requerimiento>> ObtenerRequerimientoAsync();
        Task<Requerimiento> RequerimientoPorIdAsync(int IdRequerimiento);

        //Tecnologia
        Task AltaTecnologiasAsync(Tecnologia tecnologia);
        Task<List<Tecnologia>> ObtenerTecnologiasAsync();
        Tecnologia TecnologiaPorId(byte idTecnologia);

        Task<List<Requerimiento>> RequerimientosDeLaTecnologiaAsync(byte IdTecnologia);
        Task<List<Requerimiento>> RequerimientosDelProyectoAsync(short IdProyecto);
    }
}

