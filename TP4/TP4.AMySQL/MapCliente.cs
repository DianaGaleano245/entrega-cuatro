using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
namespace TP4.AdoMySQL;
using TP4.Core;
using System;

public class MapCliente : Mapeador<Cliente>
{
    public MapCliente(AdoAGBD ado) : base(ado) => Tabla = "Cliente";
    
    public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    public override Cliente ObjetoDesdeFila(DataRow fila)
        => new Cliente
            {
                Cuit = Convert.ToInt32(fila["cuit"]),
                RazonSocial =  fila["razonSocial"].ToString()!
            };

    public void AltaCliente(Cliente cliente)
        => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);

    public void ConfigurarAltaCliente(Cliente cliente)
    {
        SetComandoSP("altaCliente");

        BP.CrearParametroSalida("unCuit").SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32).AgregarParametro();

        BP.CrearParametro("unaRazonSocial")
            .SetTipoVarchar(45)
            .SetValor(cliente.RazonSocial)
            .AgregarParametro();
    }

    public void PostAltaCliente(Cliente cliente)
        => cliente.Cuit = Convert.ToInt32(GetParametro("unCuit").Value);



    public Cliente ClientePorId(byte cuit)
    {
        SetComandoSP("ClientePorId");

        BP.CrearParametro("unIdCliente")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(cuit)
            .AgregarParametro();

        return ElementoDesdeSP();
    }

}
