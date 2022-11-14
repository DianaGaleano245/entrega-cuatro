namespace TP4.Core
{
    public class Proyecto
    {

        public short IdProyecto { get; set; }
        public Cliente Cliente { get; set; }
        public string Descripcion { get; set; }
        public Decimal Presupuesto { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

        public Proyecto() {}
        public Proyecto(Cliente cliente, string descripcion, Decimal presupuesto, DateTime inicio, DateTime fin)
        {
            Cliente = cliente;
            Descripcion = descripcion;
            Presupuesto = presupuesto;
            Inicio = inicio;
            Fin = fin;
        }
    }

}