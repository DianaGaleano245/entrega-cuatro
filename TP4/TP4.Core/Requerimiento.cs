using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP4.Core
{
    public class Requerimiento
    {
        public static string? AltaRequerimiento;

        public int IdRequerimiento { get; set; }
        public short IdProyecto { get; set; }
        public byte IdTecnologia { get; set; }
        public string Descripcion { get; set; }
        public byte Complejidad { get; set; }

        public Requerimiento(int idRequerimiento, short idProyecto, byte idTecnologia,
        string descripcion, byte complejidad)
        {
            IdRequerimiento = idRequerimiento;
            IdProyecto = idProyecto;
            Descripcion = descripcion;
            IdTecnologia = idTecnologia;
            Complejidad = complejidad;

        }

    }
}