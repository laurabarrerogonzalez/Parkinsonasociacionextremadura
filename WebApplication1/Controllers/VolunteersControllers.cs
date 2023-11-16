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
                return StatusCode(500, $"Error al insertar los datos del voluntario: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetVolunteers")]
        public IActionResult GetVolunteers()
        {
            var Volunteers = _serviceContext.Volunteers.ToList();
            return Ok(Volunteers);

        }

        [HttpDelete(Name = "DeleteVolunteers")]
        public IActionResult DeleteVolunteers(string name)
        {
            var Volunteers = _serviceContext.Volunteers.FirstOrDefault(p => p.name == name);
            if (Volunteers != null)
            {
                _serviceContext.Volunteers.Remove(Volunteers);
                _serviceContext.SaveChanges();
                return Ok("La solicitud se ha eliminado correctamente.");
            }
            else
            {
                return NotFound("no se ha encontrado la solicitud con el identificador especificado.");
            }
        }

        [HttpPut(Name = "UpdateVolunteers")]
        public IActionResult UpdateVolunteers(string name, [FromBody] VolunteersItems updatedVolunteers)
        {
            var Volunteers = _serviceContext.Volunteers.FirstOrDefault(p => p.name == name);
            if (Volunteers != null)
            {
                Volunteers.name = updatedVolunteers.name;
                Volunteers.dni = updatedVolunteers.dni;
                Volunteers.birthdate = updatedVolunteers.birthdate;
                Volunteers.address = updatedVolunteers.address;
                Volunteers.phone = updatedVolunteers.phone;
                Volunteers.email = updatedVolunteers.email;
                Volunteers.education = updatedVolunteers.education;
                Volunteers.shift = updatedVolunteers.shift;

                _serviceContext.SaveChanges();
                return Ok("La solicitud se ha actualizado correctamente.");
            }
            else
            {
                return NotFound("No se ha encontrado la solicitud con el identificador especificado.");
            }
        }

    }

}
