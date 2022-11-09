namespace TP4.Core
{
    public class Proyecto
    {
        public static string? AltaProyecto;

        public short IdProyecto { get; set; }
        public Cliente Cliente { get; set; }
        public string Descripcion { get; set; }
        public Decimal Presupuesto { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

        public Proyecto(short idProyecto, Cliente cliente, string descripcion,
        Decimal presupuesto, DateTime inicio, DateTime fin)
        {
            IdProyecto = idProyecto;
            Cliente = cliente;
            Descripcion = descripcion;
            Presupuesto = presupuesto;
            Inicio = inicio;
            Fin = fin;
        }
    }

}