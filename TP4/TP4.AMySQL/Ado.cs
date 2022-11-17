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

    public async Task AltaclienteAsync(Cliente cliente)
    => await MapCliente.AltaClienteAsync(cliente);


    public async Task<List<Cliente>> ObtenerClientesAsync()
    {
        return await MapCliente.ObtenerClientesAsync();
    }

    public async Task<Cliente> ClientePorCuitAsync(int cuit)
    {
        return await MapCliente.ClientePorCuitAsync(cuit);
    }

    public async Task AltaProyectoAsync(Proyecto proyecto)
    {
        await MapProyecto.AltaProyectoAsync(proyecto);
    }

    public async Task<List<Proyecto>> ObtenerProyectosAsync()
    {
        return await MapProyecto.ObtenerProyectosAsync();
    }

    public async Task<Proyecto> ProyectoPorIdAsync(short IdProyecto)
    {
        return await MapProyecto.ProyectoPorIdAsync(IdProyecto);
    }

    public async Task AltaRequerimientoAsync(Requerimiento requerimiento)
    {
        await MapRequerimiento.AltaRequerimientoAsync(requerimiento);
    }

    public async Task<List<Requerimiento>> ObtenerRequerimientoAsync()
    {
        return await MapRequerimiento.ObtenerRequerimientosAsync();
    }

    public async Task<Requerimiento> RequerimientoPorIdAsync(int IdRequerimiento)
    {
        return await MapRequerimiento.RequerimientoPorIdAsync(IdRequerimiento);
    }

    public async Task AltaTecnologiaAsync(Tecnologia tecnologia)
    {
        await MapTecnologia.AltaTecnologiaAsync(tecnologia);
    }

    public async Task<List<Tecnologia>> ObtenerTecnologiaAsync()
    {
        return await MapTecnologia.ObtenerTecnologiaAsync();
    }

    public Task<Tecnologia> TecnologiaPorIdAsync(byte idTecnologia)
    {
        return await MapTecnologia.TecnologiaPorIdAsync(idTecnologia);
    }

    public async Task<List<Proyecto>> ProyectosDelClienteAsync(int Cuit)
        => await MapProyecto.FilasFiltradasAsync("cuit", Cuit);

    public async Task<List<Requerimiento>> RequerimientosDeLaTecnologiaAsync(byte idTecnologia)
    {
        return await MapRequerimiento.FilasFiltradasAsync("IdTecnologia", idTecnologia);
    }

    public async Task<List<Requerimiento>> RequerimientosDelProyectoAsync(short IdProyecto)
    {
        return await MapRequerimiento.FilasFiltradasAsync("IdProyecto", IdProyecto);
    }
}