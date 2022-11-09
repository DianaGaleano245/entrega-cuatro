using System;
using System.ComponentModel.DataAnnotations;
using TP4.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace tp4.Core.MVC.ViewModels
{
    public class VMProyecto
    {
        public SelectList? Clientes { get; set; }
        public string DescripcionProyecto { get; set; }
        public Decimal PresupuestoProyecto { get; set; }
        public DateTime InicioProyecto { get; set; }
        public DateTime FinProyecto { get; set; }

        [Range(1, byte.MaxValue, ErrorMessage = "Seleccionar un Cliente")]
        public int Cuit { get; set; }

        public short idProyecto { get; set; }

        public VMProyecto() { }
        public VMProyecto(IEnumerable<Cliente> clientes)
        {
            Clientes = new SelectList(clientes,
                                    dataTextField: nameof(Cliente.Cuit),
                                    dataValueField: nameof(Cliente.RazonSocial));
        }
        public VMProyecto(IEnumerable<Cliente> clientes, Proyecto proyecto)
        {

            Clientes = new SelectList(clientes,
                                    dataTextField: nameof(Cliente.Cuit),
                                    dataValueField: nameof(Cliente.RazonSocial),
                                    selectedValue: proyecto.IdProyecto);
            DescripcionProyecto = proyecto.Descripcion;
            PresupuestoProyecto = proyecto.Presupuesto;
            InicioProyecto = proyecto.Inicio;
            FinProyecto = proyecto.Fin;
            idProyecto = proyecto.IdProyecto;


        }

    }
}