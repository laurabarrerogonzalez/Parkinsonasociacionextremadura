using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using WebApplicationParkinson.IServices;
using WebApplicationParkinson.Services;
using Microsoft.SqlServer.Server;

namespace WebApplicationParkinson.Controllers
{
     [EnableCors("AllowAll")]
    [Route("[controller]/[action]")]
    public class WorkControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWorkService _workService;
        private readonly ServiceContext _serviceContext;

        public WorkControllers(IConfiguration configuration, IWorkService workService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _workService = workService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertWorks")]
        public IActionResult Post([FromBody] WorkItems Works)
        {
            try
            {
                return Ok(_workService.InsertWorks(Works));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar los datos del voluntario: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetWorks")]
        public IActionResult GetWorks()
        {
            var Works = _serviceContext.Works.ToList();
            return Ok(Works);

        }

        [HttpDelete(Name = "DeleteWorks")]
        public IActionResult DeleteWorks(string name)
        {
            var Works = _serviceContext.Works.FirstOrDefault(p => p.name == name);
            if (Works != null)
            {
                _serviceContext.Works.Remove(Works);
                _serviceContext.SaveChanges();
                return Ok("La solicitud se ha eliminado correctamente.");
            }
            else
            {
                return NotFound("no se ha encontrado la solicitud con el identificador especificado.");
            }
        }
    }
}
