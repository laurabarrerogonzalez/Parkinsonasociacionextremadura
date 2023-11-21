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
    }
}
