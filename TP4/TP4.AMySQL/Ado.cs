using TP4.Core;
using et12.edu.ar.AGBD.Ado;

namespace TP4.AdoMySQL;
public class AdoSoftware : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapCliente MapCliente { get; set; }
    public AdoSoftware(AdoAGBD ado)
    {
        Ado = ado;
        MapCliente = new MapCliente(Ado);
    }

    public AdoSoftware()
    {

    }
    public void altacliente(Cliente cliente)
    {
        MapCliente.AltaCliente(cliente);
    }

    public List<Cliente> ObtenerClientes()
    {
        throw new NotImplementedException();
    }

    public void AltaProyecto(Proyecto proyecto)
    {
        throw new NotImplementedException();
    }

    public List<Proyecto> ObtenerProyectos()
    {
        throw new NotImplementedException();
    }

    public void AltaRequerimiento(Requerimiento requerimiento)
    {
        throw new NotImplementedException();
    }

    public List<Requerimiento> ObtenerRequerimiento()
    {
        throw new NotImplementedException();
    }
}