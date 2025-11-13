using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using Tarea.Entidades.Clases;

namespace Tarea.AccesoDatos.Data
{
    public class Memoria(IMemoryCache cache)
    {
        #region Atributos
        private readonly IMemoryCache _cache = cache;
        #endregion

        #region Metodos privados
        #endregion

        #region Metodos publicos
        #endregion
    }
}
