using System.ComponentModel.DataAnnotations;

namespace Tarea.Entidades.Clases
{
    public class EspecieMarina
    {
        /// <summary>
        /// Identificador unico de la especie
        /// </summary>
        public int Id { get; set; } = System.Random.Shared.Next(1, 1000000);
        /// <summary>
        /// Propiedad que indica el nombre de la especie marina
        /// </summary>
        [StringLength(100)]
        [Required(ErrorMessage = "Por favor, indique el nombre de la especie marina")]
        public string? Nombre { get; set; }
        /// <summary>
        /// Propiedad que indica el tipo de agua para la especie marina (agua dulce, agua salada)
        /// </summary>
        [StringLength(100)]
        [Required(ErrorMessage = "Por favor, indique el tipo de agua para la especie marina (agua dulce, agua salada)")]
        public string? TipoDeAgua { get; set; }
        /// <summary>
        /// Propiedad que indica si esta especie tiene aletas o no
        /// </summary>
        [Required(ErrorMessage = "Por favor, indique si la especie marina especie marina tiene aletas")]
        public bool TieneAletas { get; set; }
        /// <summary>
        /// Propiedad que indica si esta especie puede respirar fuera del agua o no
        /// </summary>
        [Required(ErrorMessage = "Por favor, indique si la especie marina especie marina puede respirar fuera del agua")]
        public bool RespiraFueraDeAgua { get; set; }
        /// <summary>
        /// Peso, en kilos, que usalmente tiene la especie marina
        /// </summary>
        [Range(0.01, double.MaxValue)]
        [Required(ErrorMessage = "Por favor, indique el peso (en kilogramos) que usalmente tiene la especie marina")]
        public double PesoKilos { get; set; }
        /// <summary>
        ///  Identificador unico del tipo de especie marina.
        /// </summary>
        [Required(ErrorMessage = "Por favor, indique el tipo de especie marina de la especie")]
        public TipoEspecieMarina? Tipo { get; set; }
    }
}
