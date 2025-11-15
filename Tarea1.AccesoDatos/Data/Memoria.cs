using Microsoft.Extensions.Caching.Memory;
using Tarea.Entidades.Clases;
using Tarea.Entidades.Enums;

namespace Tarea.AccesoDatos.Data
{
    /// <summary>
    /// Provee metodos para el manejo de datos en memoria.
    /// </summary>
    /// <param name="cache">Ojeto tipo <IMemoryCache> injectado por dependencia para el manejo de los datos en memoria.</param>
    public class Memoria(IMemoryCache cache)
    {
        #region Atributos
        private readonly IMemoryCache _cache = cache;
        #endregion

        #region Metodos privados
        /// <summary>
        /// Metodo para verificar el estado de la cache para el modulo solicitado
        /// </summary>
        /// <returns>Un valor positivo, si la lista esta vacia. De lo contrario un valor negativo</returns>
        private bool EstaVacioElCache(string modulo)
        {
            bool resultado = false;

            switch (modulo)
            {
                case "EspeciesMarinas":
                    if (_cache.Get("ListaEspeciesMarinas") == null)
                        resultado = true;
                    break;
                case "TiposEspeciesMarinas":
                    if (_cache.Get("ListaTiposEspeciesMarinas") == null)
                        resultado = true;
                    break;
                default:
                    break;
            }

            return resultado;
        }
        /// <summary>
        /// Metodo para obtener la lista de tipos de especies marinas. Si la lista no existe en cache, se crea y se almacena en cache.
        /// </summary>
        /// <returns>Objeto <List<Tarea.Entidades.Clases.TipoEspecieMarina>> con los tipos de especies marinas almacenados en cache.</returns>
        private List<TipoEspecieMarina> ObtenerListaTiposEspeciesMarinas()
        {
            List<TipoEspecieMarina> resultado;

            if (EstaVacioElCache("TiposEspeciesMarinas"))
            {
                resultado = [];

                resultado.Add(new TipoEspecieMarina() { 
                    Id = TipoOrganismo.OrganismosPlanctonicos, 
                    Nombre = "Organismos Planctonicos",
                    Descripcion = "Flotan en la superficie, como el fitoplancton (algas\r\nmicroscópicas) y el zooplancton (animales microscópicos)"
                });

                resultado.Add(new TipoEspecieMarina()
                {
                    Id = TipoOrganismo.OrganismosNectonicos,
                    Nombre = "Organismos Nectonicos",
                    Descripcion = "Viven en aguas libres, como peces, ballenas, calamares y tiburones."
                });

                resultado.Add(new TipoEspecieMarina()
                {
                    Id = TipoOrganismo.OrganismosBentonicos,
                    Nombre = "Organismos Bentonicos:",
                    Descripcion = "en el fondo marino, como algas, moluscos, corales y estrellas de mar"
                });

                _cache.Set("ListaTiposEspeciesMarinas", resultado);
            }
            else
                resultado = (List<TipoEspecieMarina>)_cache.Get("ListaTiposEspeciesMarinas")!;

            return resultado;
        }
        /// <summary>
        /// Metodo para obtener la lista de especies marinas. Si la lista no existe en cache, se crea y se almacena en cache.
        /// </summary>
        /// <returns>Objeto <List<Tarea.Entidades.Clases.EspecieMarina>> con la lista de especies marinas almacenadas en cache.</returns>
        private List<EspecieMarina> ObtenerListaEspeciesMarinas()
        {
            List<EspecieMarina> resultado;

            if (EstaVacioElCache("EspeciesMarinas"))
            {
                resultado = [];

                resultado.Add(new EspecieMarina()
                {
                    Id = 1,
                    Nombre = "Fitoplancton",
                    TipoDeAgua = "Agua Salada",
                    TieneAletas = false,
                    RespiraFueraDeAgua = true,
                    PesoKilos = 0.01,
                    TipoEspecie = TipoOrganismo.OrganismosPlanctonicos
                });

                resultado.Add(new EspecieMarina()
                {
                    Id = 2,
                    Nombre = "Coral Marino",
                    TipoDeAgua = "Agua Salada",
                    TieneAletas = false,
                    RespiraFueraDeAgua = false,
                    PesoKilos = 15,
                    TipoEspecie = TipoOrganismo.OrganismosBentonicos
                });

                _cache.Set("ListaEspeciesMarinas", resultado);
            }
            else
                resultado = (List<EspecieMarina>)_cache.Get("ListaEspeciesMarinas")!;

            return resultado;
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Metodo para listar los tipos de especies marinas.
        /// </summary>
        /// <returns>Objeto <List<Tarea.Entidades.Clases.TipoEspecieMarina>> con los tipos de especies marinas.</returns>
        public List<TipoEspecieMarina> ListarTiposEspeciesMarinas()
        {
            return ObtenerListaTiposEspeciesMarinas();
        }
        /// <summary>
        /// Metodo para crear una nueva especie marina.
        /// </summary>
        /// <param name="especieMarina">Objeto <Tarea.Entidades.Clases.EspecieMarina> a crear y agregar al cache.</param>
        /// <returns>Verdadero en caso de poder agregar la nueva especie marina. Falso, en caso contrario.</returns>
        public bool CrearEspecieMarina(EspecieMarina especieMarina)
        {
            List<EspecieMarina> listaEspeciesMarinas = ObtenerListaEspeciesMarinas();

            listaEspeciesMarinas.Add(especieMarina);

            return true;
        }
        /// <summary>
        /// Metodo para listar las especies marinas existentes.
        /// </summary>
        /// <returns>Objeto <List<Tarea.Entidades.Clases.EspecieMarina>> con la lista de especies marinas existentes.</returns>
        public List<EspecieMarina> ListarEspeciesMarinas()
        {
            return ObtenerListaEspeciesMarinas();
        }
        /// <summary>
        /// Metodo para actualizar una especie marina existente.
        /// </summary>
        /// <param name="especieMarina">Objeto <Tarea.Entidades.Clases.EspecieMarina> con las informacion actualizada.</param>
        /// <returns>Verdadero en caso de poder actualizar la especie marina. Falso, en caso contrario.</returns>
        public bool ActualizarEspecieMarina(EspecieMarina especieMarina)
        {
            bool resultado = false;

            List<EspecieMarina> listaEspeciesMarinas = ObtenerListaEspeciesMarinas();

            var especieExistente = listaEspeciesMarinas.FirstOrDefault(e => e.Id == especieMarina.Id);

            if(especieExistente != null)
            {
                especieExistente.Nombre = especieMarina.Nombre;
                especieExistente.TipoDeAgua = especieMarina.TipoDeAgua;
                especieExistente.TieneAletas = especieMarina.TieneAletas;
                especieExistente.RespiraFueraDeAgua = especieMarina.RespiraFueraDeAgua;
                especieExistente.PesoKilos = especieMarina.PesoKilos;
                especieExistente.TipoEspecie = especieMarina.TipoEspecie;
                resultado = true;
            }

            return resultado;
        }
        /// <summary>
        /// Metodo para eliminar una especie marina existente.
        /// </summary>
        /// <param name="idEspecieMarina">Valor <int> con el idEspecieMarina de la especie marina a eliminar.</param>
        /// <returns>Verdadero en caso de poder eliminar la especie marina. Falso, en caso contrario.</returns>
        public bool EliminarEspecieMarina(int idEspecieMarina)
        {
            bool resultado = false;

            List<EspecieMarina> listaEspeciesMarinas = ObtenerListaEspeciesMarinas();

            if(listaEspeciesMarinas.RemoveAll(e => e.Id == idEspecieMarina) > 0)
                resultado = true;

            return resultado;
        }
        /// <summary>
        /// Metodo para leer el tipo de especie marina de una especie marina existente.
        /// </summary>
        /// <param name="idEspecieMarina">Valor <int> con el idEspecieMarina de la especie marina.</param>
        /// <returns>Objeto tipo <Tarea.Entidades.Clases.TipoEspecieMarina> con la informacion del tipo de especie marina.</returns>
        /// <exception cref="Exception"></exception>
        public TipoEspecieMarina LeerTipoEspecieMarinaDeEspecieMarina(int idEspecieMarina)
        {
            TipoEspecieMarina resultado;

            List<EspecieMarina> listaEspeciesMarinas = ObtenerListaEspeciesMarinas();

            var especieExistente = listaEspeciesMarinas.FirstOrDefault(e => e.Id == idEspecieMarina) 
                ?? throw new Exception("La especie marina no existe.");

            var tiposEspeciesMarinas = ObtenerListaTiposEspeciesMarinas();

            resultado = tiposEspeciesMarinas.FirstOrDefault(t => t.Id == especieExistente.TipoEspecie)!;

            return resultado;
        }
        #endregion
    }
}
