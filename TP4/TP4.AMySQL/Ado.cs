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

    public void Altacliente(Cliente cliente)
    {
        MapCliente.AltaCliente(cliente);
    }

    public List<Cliente> ObtenerClientes()
    {
        return MapCliente.ObtenerClientes();
    }

    public Cliente ClientePorCuit(int Cuit)
    {
        throw new NotImplementedException();
    }

}