namespace Tarea.Entidades.Clases
{
    public class TipoEspecieMarina
    {
        /// <summary>
        /// Identificador unico del tipo de especie marina
        /// </summary>
        public int Id { get; set; } = System.Random.Shared.Next(1, 1000000);
        /// <summary>
        /// Nombre del tipo de especie marina (Organismos Planctónicos, Organismos Nectónicos u Organismos Bentónicos)
        /// </summary>
        public string? NombreTipoEspecie { get; set; }
        /// <summary>
        /// Coleccion de especies marinas asociadas a este tipo de especie marina
        /// </summary>
        public IList<EspecieMarina>? EspeciesMarinas { get; set; }
    }
}
