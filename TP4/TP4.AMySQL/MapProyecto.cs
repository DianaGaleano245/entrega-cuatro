using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using TP4.Core;
using System.Collections.Generic;
namespace TP4.AdoMySQL;

public class MapProyecto : Mapeador<Proyecto>
{
    public MapProyecto(AdoAGBD ado) : base(ado) => Tabla = "Proyecto";
    public MapCliente MapCliente { get; set; }
    public MapProyecto(MapCliente mapCliente) : this(mapCliente.AdoAGBD)
    {
        MapCliente = mapCliente;
    }
    public List<Proyecto> ObtenerProyectos() => ColeccionDesdeTabla();
    public override Proyecto ObjetoDesdeFila(DataRow fila)
        => new Proyecto()
        {
            Cliente = MapCliente.ClientePorCuit(Convert.ToInt32(fila["cuit"])),
            Descripcion = fila["descripcion"].ToString(),
            Presupuesto = Convert.ToDecimal(fila["presupuesto"]),
            Inicio = Convert.ToDateTime(fila["inicio"]),
            Fin = Convert.ToDateTime(fila["fin"]),
        };


    public void AltaProyecto(Proyecto Proyecto)
        => EjecutarComandoCon("altaProyecto", ConfigurarAltaProyecto, PostAltaProyecto, Proyecto);

    public void ConfigurarAltaProyecto(Proyecto Proyecto)
    {
        SetComandoSP("altaProyecto");

        BP.CrearParametro("unIdProyecto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(Proyecto.IdProyecto)
            .AgregarParametro();

        BP.CrearParametro("unCuit")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(Proyecto.Cliente.Cuit)
            .AgregarParametro();

        BP.CrearParametro("unaDescripcion")
            .SetTipoVarchar(45)
            .SetValor(Proyecto.Descripcion)
            .AgregarParametro();

        BP.CrearParametro("unPresupuesto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Decimal)
            .SetValor(Proyecto.Presupuesto)
            .AgregarParametro();

        BP.CrearParametro("unInicio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(Proyecto.Inicio)
            .AgregarParametro();

        BP.CrearParametro("unFinal")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(Proyecto.Fin)
            .AgregarParametro();
    }

    public void PostAltaProyecto(Proyecto Proyecto)
        => Proyecto.IdProyecto = Convert.ToInt16(GetParametro("unIdProyecto").Value);



    public Proyecto ProyectoPorId(short IdProyecto)
    {
        SetComandoSP("proyectoPorId");

        BP.CrearParametro("unIdProyecto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(IdProyecto)
            .AgregarParametro();

        return ElementoDesdeSP();
    }

}
