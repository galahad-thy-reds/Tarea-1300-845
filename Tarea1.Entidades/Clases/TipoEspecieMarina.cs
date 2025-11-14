using System.ComponentModel.DataAnnotations;
using Tarea.Entidades.Enums;

namespace Tarea.Entidades.Clases
{
    /// <summary>
    /// Representa un tipo de especie marina con sus propiedades.Utiliza el tipo fijo de organismo marino como clave unica.
    /// </summary>
    public class TipoEspecieMarina
    {
        /// <summary>
        /// Identificador unico del tipo de especie marina utilizando el tipo fijo de organismo marino.
        /// </summary>
        [Required(ErrorMessage = "Por favor, indique el tipo de organismo")]
        public TipoOrganismo Id { get; set; }
        /// <summary>
        /// Nombre del tipo de especie marina (Organismos Planctónicos, Organismos Nectónicos u Organismos Bentónicos).
        /// </summary>
        [StringLength(100)]
        [Required(ErrorMessage = "Por favor, indique el nombre del tipo de especie marina")]
        public string? Nombre { get; set; }
        /// <summary>
        /// Descripcion del tipo de especie marina.
        /// </summary>
        [StringLength(250)]
        [Required(ErrorMessage = "Por favor, indique la descripcion del tipo de especie marina")]
        public string? Descripcion { get; set; }
    }
}
