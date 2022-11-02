namespace TP4.Core;

public class Cliente
{
    public static string? ado;

    public string RazonSocial { get; set; }
    public int Cuit { get; set; }
    //public List<Proyecto> Proyectos { get; set; }
    public Cliente() { }

    public Cliente(string razonSocial, int cuit)
    {
        RazonSocial = razonSocial;
        Cuit = cuit;
        //Proyectos = new List<Proyecto>();
    }

    // public void AgregarProyecto(Proyecto proyecto)
    // {
    //     // Proyectos.Add(proyecto);
    // }
}