using System;
using System.ComponentModel.DataAnnotations;
using TP4.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TPAnime.MVC.ViewModels
{
    public class VMProyecto
    {
        public SelectList? Clientes { get; set; }
        public string DescripcionProyecto { get; set; }
        public Decimal PresupuestoProyecto { get; set; }
        public DateTime InicioProyecto { get; set; }
        public DateTime FinProyecto { get; set; }



        // [Range(1, byte.MaxValue, ErrorMessage = "Seleccionar un Proyecto")]
        // public short  IdProyecto { get; set; }

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
        public VMProyecto(IEnumerable<Cliente> Clientes, Proyecto proyecto)
        {
            // Proyectos = new SelectList(Proyectos,
            //                         dataTextField: nameof(Proyecto.Cuit),
            //                         dataValueField: nameof(Proyecto.Presupuesto),
            //                         dataValueField: nameof(Proyecto.Inicio),
            //                         dataValueField: nameof(Proyecto.Fin),
            //                         selectedValue: Proyecto.Id);

            Clientes = new SelectList(Clientes,
                                    dataTextField: nameof(Cliente.Cuit),
                                    dataValueField: nameof(Cliente.RazonSocial),
                                    selectedValue: proyecto.IdProyecto);
            DescripcionProyecto = proyecto.Descripcion;
            PresupuestoProyecto = proyecto.Presupuesto;
            InicioProyecto = proyecto.Inicio;
            FinProyecto = proyecto.Fin;

        }

    }
}