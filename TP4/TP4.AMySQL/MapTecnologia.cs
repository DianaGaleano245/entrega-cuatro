using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using TP4.Core;
using System.Threading.Tasks;

namespace TP4.AMySQL;

public class MapTecnologia : Mapeador<Tecnologia>
{
        public MapTecnologia(AdoAGBD ado) : base(ado) => Tabla = "Tecnologia";

    public List<Tecnologia> ObtenerTecnologias() => ColeccionDesdeTabla();
    public override Tecnologia ObjetoDesdeFila(DataRow fila)
        => new Tecnologia
        {
            IdTecnologia = Convert.ToByte(fila["idTecnologia"]),
            CostoBase = Convert.ToDecimal(fila["costoBase"]),
            Nombre = fila["tecnologia"].ToString()!
        };

    public void AltaTecnologia(Tecnologia Tecnologia)
        => EjecutarComandoCon("altaTecnologia", ConfigurarAltaTecnologia, PostAltaTecnologia, Tecnologia);

    public void ConfigurarAltaTecnologia(Tecnologia Tecnologia)
    {
        SetComandoSP("altaTecnologia");

        BP.CrearParametro("unIdTecnologia").SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32).SetValor(Tecnologia.IdTecnologia).AgregarParametro();

        BP.CrearParametro("unCostoBase")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Decimal)
            .SetValor(Tecnologia.CostoBase)
            .AgregarParametro();

        BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(Tecnologia.Nombre)
            .AgregarParametro();
    }

    public void PostAltaTecnologia(Tecnologia Tecnologia)
        => Tecnologia.IdTecnologia = Convert.ToByte(GetParametro("unIdTecnologia").Value);



    public Tecnologia TecnologiaPorId(byte IdTecnologia)
    {
        SetComandoSP("TecnologiaPorId");

        BP.CrearParametro("unIdtecnologia")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(IdTecnologia)
            .AgregarParametro();

        return ElementoDesdeSP();
    }
}
