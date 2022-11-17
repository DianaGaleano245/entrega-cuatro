using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using TP4.Core;
namespace TP4.AdoMySQL;

public class MapCliente : Mapeador<Cliente>
{
    public MapCliente(AdoAGBD ado) : base(ado) => Tabla = "Cliente";



    // public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    public async Task<List<Cliente>> ObtenerClientesAsync() => await ColeccionDesdeTablaAsync();

    public override Cliente ObjetoDesdeFila(DataRow fila)
        => new Cliente
        {
            Cuit = Convert.ToInt32(fila["cuit"]),
            RazonSocial = fila["razonSocial"].ToString()!
        };

    // public void AltaCliente(Cliente cliente)
    //     => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);
    public async Task AltaClienteAsync(Cliente cliente)
        => await EjecutarComandoAsync("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);
    public void ConfigurarAltaCliente(Cliente cliente)
    {
        SetComandoSP("altaCliente");

        BP.CrearParametro("unCuit")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(cliente.Cuit)
            .AgregarParametro();

        BP.CrearParametro("unaRazonSocial")
            .SetTipoVarchar(45)
            .SetValor(cliente.RazonSocial)
            .AgregarParametro();
    }

    public void PostAltaCliente(Cliente cliente)
        => cliente.Cuit = Convert.ToInt32(GetParametro("unCuit").Value);



    public async Task<Cliente> ClientePorCuitAsync(int cuit)
    {
        SetComandoSP("clientePorCuit");

        BP.CrearParametro("unCuit")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(cuit)
            .AgregarParametro();

        return await ElementoDesdeSPAsync();
    }
    public Cliente ClientePorCuit(int cuit)
    {
        SetComandoSP("clientePorCuit");

        BP.CrearParametro("unCuit")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(cuit)
            .AgregarParametro();

        return ElementoDesdeSP();
    }

}
