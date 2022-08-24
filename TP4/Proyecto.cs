namespace TP4
{
    public class Proyecto
    {
        public short idProyecto{get; set;}
        public Cliente cliente {get; set;}
        public string Descripcion {get; set;}
        public Decimal Presupuesto {get; set;}
        public DateOnly Inicio {get; set;}
        public DateOnly Fin {get; set;}
    }
}