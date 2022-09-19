using System;
using et12.edu.ar.AGBD.Mapeadores;

namespace TP4.AdoMySQL;

    public class MapCliente: Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado):base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente()
            {
                Cuit= Convert.ToByte(fila["idCliente"]),
                Nombre = fila["Cliente"].ToString()
            };

        public void AltaCliente(Cliente cliente)
            => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, Cliente);

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
            Cliente.Id = Convert.ToByte(paramIdCliente.Value);
        }

        public Cliente ClientePorId(byte id)
        {
            SetComandoSP("ClientePorId");

            BP.CrearParametro("unIdCliente")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
                .SetValor(id)
                .AgregarParametro();

            return ElementoDesdeSP();
        }

        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    }
