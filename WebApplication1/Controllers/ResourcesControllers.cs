using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using WebApplicationParkinson.IServices;
using WebApplicationParkinson.Services;
using System.Resources;

namespace WebApplicationParkinson.Controllers
{
    [EnableCors("AllowAll")]
    [Route("[controller]/[action]")]
    public class ResourcesControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IResourcesServices _resourcesService;
        private readonly ServiceContext _serviceContext;

        public ResourcesControllers(IConfiguration configuration, IResourcesServices resourcesService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _resourcesService = resourcesService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertResources")]
        public IActionResult Post([FromBody]ResourcesItems Resources)
        {
            try
            {
                return Ok(_resourcesService.InsertResources(Resources));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar los datos del voluntario: {ex.Message}");
            }
        }
        [HttpGet(Name = "GetResources")]
        public IActionResult GetResources()
        {
            var Resources = _serviceContext.Resources.ToList();
            return Ok(Resources);

        }

        [HttpDelete(Name = "DeleteResources")]
        public IActionResult DeleteResources(string name)
        {
            var resources = _serviceContext.Resources.FirstOrDefault(p => p.name == name);
            if (resources != null)
            {
                _serviceContext.Resources.Remove(resources);
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
