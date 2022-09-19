using System;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using System.Collections.Generic;
namespace TP4.AdoMySQL;

    public class MapCliente: Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado):base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new cliente()
            {
                Cuit= Convert.ToByte(fila["idCliente"]),
                Nombre = fila["Cliente"].ToString()
            };

        public void AltaCliente(Cliente cliente)
            => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);

        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametroSalida("unIdCliente")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
                .AgregarParametro();

            BP.CrearParametro("unCliente")
                .SetTipoVarchar(45)
                .SetValor(Cliente.Nombre)
                .AgregarParametro();
        }

        public void PostAltaCliente(Cliente cliente)
        {
            var paramIdCliente = GetParametro("unIdCliente");
            cliente.Cuit = Convert.ToInt32(paramIdCliente.Value);
        }

        public Cliente ClientePorId(byte cuit)
        {
            SetComandoSP("ClientePorId");

            BP.CrearParametro("unIdCliente")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
                .SetValor(cuit)
                .AgregarParametro();

            return ElementoDesdeSP();
        }

        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    }
