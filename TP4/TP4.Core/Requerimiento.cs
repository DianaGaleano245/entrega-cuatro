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
        public Proyecto Proyecto { get; set; }
        public Tecnologia Tecnologia { get; set; }
        public string Descripcion { get; set; }
        public byte Complejidad { get; set; }

        public Requerimiento() {}
        public Requerimiento(int idRequerimiento, Proyecto proyecto, Tecnologia tecnologia,
        string descripcion, byte complejidad)
        {
            IdRequerimiento = idRequerimiento;
            Proyecto = proyecto;
            Descripcion = descripcion;
            Tecnologia = tecnologia;
            Complejidad = complejidad;

        }

    }
}