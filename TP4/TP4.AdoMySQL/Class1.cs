using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;

namespace TP4.AdoMySQL;
public class MapClientes : Mapeador<clientes>  
{
    public MapRubro(AdoAGBD ado):base(ado);
}
