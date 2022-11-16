using TP4.Core;
using et12.edu.ar.AGBD.Ado;
using System;

namespace TP4.AdoMySQL;
public class AdoSoftware : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapCliente MapCliente { get; set; }
    public MapProyecto MapProyecto { get; set; }
    public MapTecnologia MapTecnologia { get; set; }
    public MapRequerimiento MapRequerimiento { get; set; }
    public AdoSoftware(AdoAGBD ado)
    {
        Ado = ado;
        MapCliente = new MapCliente(Ado);
        MapTecnologia = new MapTecnologia(Ado);
        MapProyecto = new MapProyecto(MapCliente);
        MapRequerimiento = new MapRequerimiento(MapProyecto, MapTecnologia);

    }

    public async Task Altacliente(Cliente cliente)
    => MapCliente.AltaClienteAsync(cliente);


    public async Task<List<Cliente>> ObtenerClientesAsync()
    {
        return await MapCliente.ObtenerClientesAsync();
    }

    public Cliente ClientePorCuit(int cuit)
    {
        return MapCliente.ClientePorCuit(cuit);
    }

    public async Task AltaProyectoAsync(Proyecto proyecto)
    {
        await MapProyecto.AltaProyectoAsync(proyecto);
    }

    public async Task<List<Proyecto>> ObtenerProyectosAsync()
    {
        return await MapProyecto.ObtenerProyectosAsync();
    }

    public Proyecto ProyectoPorId(short IdProyecto)
    {
        return MapProyecto.ProyectoPorId(IdProyecto);
    }

    public async Task AltaRequerimientoAsync(Requerimiento requerimiento)
    {
        await MapRequerimiento.AltaRequerimientoAsync(requerimiento);
    }

    public List<Requerimiento> ObtenerRequerimiento()
    {
        return MapRequerimiento.ObtenerRequerimientos();
    }

    public async Task<Requerimiento> RequerimientoPorIdAsync(int IdRequerimiento)
    {
        return await MapRequerimiento.RequerimientoPorIdAsync(IdRequerimiento);
    }

    public async Task AltaTecnologiaAsync(Tecnologia tecnologia)
    {
        await MapTecnologia.AltaTecnologiaAsync(tecnologia);
    }

    public List<Tecnologia> ObtenerTecnologia()
    {
        return MapTecnologia.ObtenerTecnologias();
    }

    public Tecnologia TecnologiaPorId(byte idTecnologia)
    {
        return MapTecnologia.TecnologiaPorId(idTecnologia);
    }

    public List<Proyecto> ProyectosDelCliente(int Cuit)
        => MapProyecto.FilasFiltradas("cuit", Cuit);

    public List<Requerimiento> RequerimientosDeLaTecnologia(byte idTecnologia)
    {
        return MapRequerimiento.FilasFiltradas("IdTecnologia", idTecnologia);
    }

    public List<Requerimiento> RequerimientosDelProyecto(short IdProyecto)
    {
        return MapRequerimiento.FilasFiltradas("IdProyecto", IdProyecto);
    }
}