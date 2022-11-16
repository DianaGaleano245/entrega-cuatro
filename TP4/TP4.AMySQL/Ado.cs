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

    public void Altacliente(Cliente cliente)
    {
        MapCliente.AltaCliente(cliente);
    }

    public List<Cliente> ObtenerClientes()
    {
        return MapCliente.ObtenerClientes();
    }

    public Cliente ClientePorCuit(int cuit)
    {
        return MapCliente.ClientePorCuit(cuit);
    }

    public void AltaProyecto(Proyecto proyecto)
    {
        MapProyecto.AltaProyecto(proyecto);
    }

    public List<Proyecto> ObtenerProyectos()
    {
        return MapProyecto.ObtenerProyectos();
    }

    public Proyecto ProyectoPorId(short IdProyecto)
    {
        return MapProyecto.ProyectoPorId(IdProyecto);
    }



    public void AltaRequerimiento(Requerimiento requerimiento)
    {
        MapRequerimiento.AltaRequerimiento(requerimiento);
    }

    public List<Requerimiento> ObtenerRequerimiento()
    {
        return MapRequerimiento.ObtenerRequerimientos();
    }

    public Requerimiento RequerimientoPorId(int IdRequerimiento)
    {
        return MapRequerimiento.RequerimientoPorId(IdRequerimiento);
    }

    public void AltaTecnologia(Tecnologia tecnologia)
    {
        MapTecnologia.AltaTecnologia(tecnologia);
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
        return MapRequerimiento.FilasFiltradas("idTecnologia", idTecnologia);
    }




}