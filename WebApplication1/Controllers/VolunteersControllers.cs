using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using WebApplicationParkinson.IServices;
using WebApplicationParkinson.Services;

namespace WebApplicationParkinson.Controllers
{
    [EnableCors("AllowAll")]
    [Route("[controller]/[action]")]
    public class VolunteersControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IVolunteersService _volunteersService;
        private readonly ServiceContext _serviceContext;

        public VolunteersControllers(IConfiguration configuration, IVolunteersService volunteersService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _volunteersService = volunteersService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertVolunteers")]
        public IActionResult Post([FromBody] VolunteersItems Volunteers)
        {
            try
            {
                return Ok(_volunteersService.InsertVolunteers(Volunteers));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el ID del rol: {ex.Message}");
            }
        }
    }
    
}
