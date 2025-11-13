namespace Tarea.Entidades.Enums
{
    /// <summary>
    /// Representa los tipos fijos de organismos marinos.
    /// </summary>
    public enum TipoOrganismo
    {
        /// <summary>
        /// Flotan en la superficie (fitoplancton, zooplancton).
        /// </summary>
        OrganismosPlanctonicos = 1,

        /// <summary>
        /// Viven en aguas libres (peces, ballenas, calamares).
        /// </summary>
        OrganismosNectonicos = 2,

        /// <summary>
        /// Viven en el fondo marino (algas, moluscos, corales).
        /// </summary>
        OrganismosBentonicos = 3
    }
}