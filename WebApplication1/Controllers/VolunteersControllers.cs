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

        [HttpGet(Name = "GetVolunteers")]
        public IActionResult GetVolunteers()
        {
            var Volunteers = _serviceContext.Volunteers.ToList();
            return Ok(Volunteers);

        }

        [HttpDelete(Name = "DeleteVolunteers")]
        public IActionResult DeleteVolunteers(string Name)
        {
            var Volunteers = _serviceContext.Volunteers.FirstOrDefault(p => p.Name == Name);
            if (Volunteers != null)
            {
                _serviceContext.Volunteers.Remove(Volunteers);
                _serviceContext.SaveChanges();
                return Ok("La cancion se ha eliminado correctamente.");
            }
            else
            {
                return NotFound("no se ha encontrado la cancion con el identificador especificado.");
            }
        }

        [HttpPut(Name = "UpdateVolunteers")]
        public IActionResult UpdateVolunteers(string Name, [FromBody] VolunteersItems updatedVolunteers)
        {
            var Volunteers = _serviceContext.Volunteers.FirstOrDefault(p => p.Name == Name);
            if (Volunteers != null)
            {
                Volunteers.Name = updatedVolunteers.Name;
                Volunteers.Dni = updatedVolunteers.Dni;
                Volunteers.Birthdate = updatedVolunteers.Birthdate;
                Volunteers.Address = updatedVolunteers.Address;
                Volunteers.Phone = updatedVolunteers.Phone;
                Volunteers.Email = updatedVolunteers.Email;
                Volunteers.Education = updatedVolunteers.Education;
                Volunteers.Id_Shift = updatedVolunteers.Id_Shift;
                Volunteers.TermsAccepted = updatedVolunteers.TermsAccepted;

                _serviceContext.SaveChanges();
                return Ok("La cancion se ha actualizado correctamente.");
            }
            else
            {
                return NotFound("No se ha encontrado la cancion con el identificador especificado.");
            }
        }

    }

}
