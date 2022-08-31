using System;
using System.Collections.Generic;
namespace TP4
{
    public class Cliente
    {
        public string RazonSocial {get; set;}
        public int Cuil{get; set;}
        public List<Proyecto> Proyectos {get; set;}
        public Cliente(string razonSocial, int cuil)
        {
            RazonSocial = razonSocial;
            Cuil = cuil;
            Proyectos = new List<Proyecto>();
        }
        public void AgregarProyecto(Proyecto proyecto)
        {
            Proyecto.Add()
        } 
    }
}