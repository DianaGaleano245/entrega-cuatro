namespace TP4.Core
{
    public class Tecnologia
    {
        public byte IdTecnologia { get; set; }
        public string Nombre { get; set; }
        public decimal CostoBase { get; set; }

        public Tecnologia() { }

        public Tecnologia(byte idTecnologia, string nombre, decimal costoBase)
        {
            IdTecnologia = idTecnologia;
            Nombre = nombre;
            CostoBase = costoBase;
        }
    }
}