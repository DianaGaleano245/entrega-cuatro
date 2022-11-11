using System;
using System.ComponentModel.DataAnnotations;
using TP4.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace tp4.Core.Mvc.ViewModels
{
    public class VMRequerimiento
    {
        public SelectList? Proyectos { get; set; }
        public SelectList? Tecnologias { get; set; }
        public string DescripcionRequerimiento { get; set; }
        public byte ComplejidadRequerimiento { get; set; }


        [Range(1, byte.MaxValue, ErrorMessage = "Seleccionar una Tecnologia")]
        public byte IdTecnologia { get; set; }

        [Range(1, byte.MaxValue, ErrorMessage = "Seleccionar un Proyecto")]
        public short IdProyecto { get; set; }
        public int IdRequerimiento { get; set; }

        public VMRequerimiento() { }
        public VMRequerimiento(IEnumerable<Tecnologia> tecnologias, IEnumerable<Proyecto> proyectos)
        {
            Tecnologias = new SelectList(tecnologias,
                                    dataTextField: nameof(Tecnologia.Nombre),
                                    dataValueField: nameof(Tecnologia.IdTecnologia));
            Proyectos = new SelectList(proyectos,
                                    dataTextField: nameof(Proyecto.Descripcion),
                                    dataValueField: nameof(Proyecto.IdProyecto));
        }
        public VMRequerimiento(IEnumerable<Tecnologia> tecnologias, IEnumerable<Proyecto> proyectos, Requerimiento requerimiento)
        {

            Tecnologias = new SelectList(tecnologias,
                                    dataTextField: nameof(Tecnologia.Nombre),
                                    dataValueField: nameof(Tecnologia.IdTecnologia),
                                    selectedValue: requerimiento.IdRequerimiento);
            Proyectos = new SelectList(proyectos,
                                    dataTextField: nameof(Proyecto.Descripcion),
                                    dataValueField: nameof(Proyecto.IdProyecto),
                                    selectedValue: requerimiento.IdRequerimiento);
            DescripcionRequerimiento = requerimiento.Descripcion;
            ComplejidadRequerimiento = requerimiento.Complejidad;
            IdRequerimiento = requerimiento.IdRequerimiento;
        }
    }
}
