using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Tarea.AccesoDatos.Data;
using Tarea.Entidades.Clases;

namespace Tarea.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieMarinaController(IMemoryCache cache) : ControllerBase
    {
        private readonly IMemoryCache _cache = cache;

        [HttpGet("ListarTiposEspeciesMarinas")]
        public ActionResult<List<TipoEspecieMarina>> ListarTiposEspeciesMarinas()
        {
            try
            {
                Memoria memoria = new Memoria(_cache);

                List<TipoEspecieMarina> listaTiposEspeciesMarinas = memoria.ListarTiposEspeciesMarinas();

                if (listaTiposEspeciesMarinas != null)
                    return Ok(listaTiposEspeciesMarinas);
                else
                    return NotFound("");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("ListarEspeciesMarinas")]
        public ActionResult<List<EspecieMarina>> ListarEspeciesMarinas()
        {
            try
            {
                Memoria memoria = new Memoria(_cache);

                List<EspecieMarina> listaEspeciesMarinas = memoria.ListarEspeciesMarinas();

                if (listaEspeciesMarinas != null)
                    return Ok(listaEspeciesMarinas);
                else
                    return NotFound("No se encontraron especies marinas.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("CrearEspecieMarina")]
        public ActionResult<bool> CrearEspecieMarina([FromBody] EspecieMarina especieMarina)
        {
            try
            {
                Memoria memoria = new Memoria(_cache);

                bool resultado = memoria.CrearEspecieMarina(especieMarina);

                if (resultado)
                    return Ok(resultado);
                else
                    return BadRequest("No se pudo agregar la especie marina.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("LeerTipoEspecieMarinaDeEspecieMarina/{idEspecieMarina}")]
        public ActionResult<TipoEspecieMarina> LeerTipoEspecieMarinaDeEspecieMarina(int idEspecieMarina)
        {
            try
            {
                Memoria memoria = new Memoria(_cache);

                TipoEspecieMarina tipoEspecieMarina = memoria.LeerTipoEspecieMarinaDeEspecieMarina(idEspecieMarina);

                if (tipoEspecieMarina != null)
                    return Ok(tipoEspecieMarina);
                else
                    return NotFound("No se encontró el tipo de especie marina.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("ActualizarEspecieMarina")]
        public ActionResult<bool> EditarEspecieMarina([FromBody] EspecieMarina especieMarina)
        {
            try
            {
                Memoria memoria = new Memoria(_cache);

                bool resultado = memoria.ActualizarEspecieMarina(especieMarina);

                if (resultado)
                    return Ok(resultado);
                else
                    return BadRequest("No se pudo editar la especie marina.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("EliminarEspecieMarina/{id}")]
        public ActionResult<bool> EliminarEspecieMarina(int id)
        {
            try
            {
                Memoria memoria = new Memoria(_cache);

                bool resultado = memoria.EliminarEspecieMarina(id);

                if (resultado)
                    return Ok(resultado);
                else
                    return BadRequest("No se pudo eliminar la especie marina.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
