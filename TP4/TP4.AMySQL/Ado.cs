using System;
using TP4.Core;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using TP4;
using TP4.AdoMySQL;

namespace Ado
{
    public class Ado : IAdo
    {
        public AdoAGBD Ado { get; set; }
        public MapCliente MapCliente { get; set; }
        public Ado(AdoAGBD ado)
        {
            Ado = ado;
            MapCliente = new MapCliente(Ado);
        }

        public Ado()
        {
            
        }

        public List<Ado> ObtenerAdos() => MapCliente.ObtenerClientes();

        public void altacliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerClientes()
        {
            throw new NotImplementedException();
        }

        public void AltaProyecto(Proyecto proyecto)
        {
            throw new NotImplementedException();
        }

        public List<Proyecto> ObtenerProyectos()
        {
            throw new NotImplementedException();
        }

        public void AltaRequerimiento(Requerimiento requerimiento)
        {
            throw new NotImplementedException();
        }

        public List<Requerimiento> ObtenerRequerimiento()
        {
            throw new NotImplementedException();
        }
    }
}