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
        public string? NombreEspecie { get; set; }
        /// <summary>
        /// Propiedad que indica el tipo de agua para la especie marina (agua dulce, agua salada)
        /// </summary>
        public string? TipoAgua { get; set; }
        /// <summary>
        /// Propiedad que indica si esta especie tiene aletas o no
        /// </summary>
        public bool TieneAletas { get; set; }
        /// <summary>
        /// Propiedad que indica si esta especie puede respirar fuera del agua o no
        /// </summary>
        public bool RespiraFueraDeAgua { get; set; }
        /// <summary>
        /// Peso, en kilos, que usalmente tiene la especie marina
        /// </summary>
        public double PesoKilos { get; set; }
    }
}
