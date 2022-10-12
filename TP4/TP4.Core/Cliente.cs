using System;
using System.Collections.Generic;
namespace TP4
{
    public class Cliente
    {
        public static string? ado;

        public string RazonSocial { get; set; }
        public int Cuit { get; set; }
        public List<Proyecto> Proyectos { get; set; }
        public Cliente(string razonSocial, int cuit)
        {
            RazonSocial = razonSocial;
            Cuit = cuit;
            Proyectos = new List<Proyecto>();
        }

        public static void AltaCliente(int v)
        {
            throw new NotImplementedException();
        }

        public void AgregarProyecto(Proyecto proyecto)
        {
            Proyectos.Add(proyecto);
        }
    }
}