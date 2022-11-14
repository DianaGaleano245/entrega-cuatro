namespace TP4.Core;

public class Cliente
{

    public string RazonSocial { get; set; }
    public int Cuit { get; set; }
    public Cliente() { }

    public Cliente(string razonSocial, int cuit)
    {
        RazonSocial = razonSocial;
        Cuit = cuit;
    }
}