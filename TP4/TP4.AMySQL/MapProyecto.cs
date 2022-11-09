using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using TP4.Core;
namespace TP4.AdoMySQL;

public class MapProyecto : Mapeador<Proyecto>
{
    public MapProyecto(AdoAGBD ado) : base(ado) => Tabla = "Proyecto";
    public MapCliente mapCliente { get; set; }

    public MapProyecto(MapCliente mapCliente) : this(mapCliente.AdoAGBD)
    {
        this.mapCliente = mapCliente;
    }
    public List<Proyecto> ObtenerProyectos() => ColeccionDesdeTabla();
    public override Proyecto ObjetoDesdeFila(DataRow fila)
        => new Proyecto(
            idProyecto: Convert.ToInt16(fila["idProyecto"]),
            cliente: this.mapCliente.ClientePorCuit(Convert.ToInt32(fila["cuit"])),
            descripcion: fila["descripcion"].ToString(),
            presupuesto: Convert.ToDecimal(fila["presupuesto"]),
            inicio: Convert.ToDateTime(fila["inicio"]),
            fin: Convert.ToDateTime(fila["fin"])
        );

    public void AltaProyecto(Proyecto Proyecto)
        => EjecutarComandoCon("altaProyecto", ConfigurarAltaProyecto, PostAltaProyecto, Proyecto);

    public void ConfigurarAltaProyecto(Proyecto Proyecto)
    {
        SetComandoSP("altaProyecto");

        BP.CrearParametro("unIdProyecto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(Proyecto.IdProyecto)
            .AgregarParametro();

        BP.CrearParametro("unCuit")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
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
