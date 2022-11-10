using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using TP4.Core;
namespace TP4.AdoMySQL;

public class MapRequerimiento : Mapeador<Requerimiento>
{
    public MapRequerimiento(AdoAGBD ado) : base(ado) => Tabla = "Requerimiento";
    public List<Requerimiento> ObtenerRequerimientos() => ColeccionDesdeTabla();
    public override Requerimiento ObjetoDesdeFila(DataRow fila)
        => new Requerimiento(
            idRequerimiento: Convert.ToInt32(fila["idRequerimiento"]),
            idProyecto: Convert.ToInt16(fila["idProyecto"]),
            descripcion: fila["descripcion"].ToString(),
            idTecnologia: Convert.ToByte(fila["idTecnologia"]),
            complejidad: Convert.ToByte(fila["complejidad"])
        );

    public void AltaRequerimiento(Requerimiento Requerimiento)
        => EjecutarComandoCon("altaRequerimiento", ConfigurarAltaRequerimiento, PostAltaRequerimiento, Requerimiento);

    public void ConfigurarAltaRequerimiento(Requerimiento Requerimiento)
    {
        SetComandoSP("altaRequerimiento");

        BP.CrearParametro("unIdRequerimiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(Requerimiento.IdRequerimiento)
            .AgregarParametro();

        BP.CrearParametro("unIdProyecto")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(Requerimiento.IdProyecto)
            .AgregarParametro();

        BP.CrearParametro("unIdTecnologia")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Decimal)
            .SetValor(Requerimiento.IdTecnologia)
            .AgregarParametro();

        BP.CrearParametro("unaDescripcion")
            .SetTipoVarchar(45)
            .SetValor(Requerimiento.Descripcion)
            .AgregarParametro();

        BP.CrearParametro("unaComplejidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Decimal)
            .SetValor(Requerimiento.Complejidad)
            .AgregarParametro();

    }

    public void PostAltaRequerimiento(Requerimiento Requerimiento)
        => Requerimiento.IdRequerimiento = Convert.ToInt32(GetParametro("unIdRequerimiento").Value);



    public Requerimiento RequerimientoPorId(int IdRequerimiento)
    {
        SetComandoSP("requerimientoPorId");

        BP.CrearParametro("unIdRequerimiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(IdRequerimiento)
            .AgregarParametro();

        return ElementoDesdeSP();
    }

}
