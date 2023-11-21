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
    public class MembersControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMembersServices _membersService;
        private readonly ServiceContext _serviceContext;
        public MembersControllers(IConfiguration configuration, IMembersServices membersService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _membersService = membersService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertMembers")]
        public IActionResult Post([FromBody] MembersItems Members)
        {
            try
            {
                return Ok(_membersService.InsertMembers(Members));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar los datos del voluntario: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetMembers")]
        public IActionResult GetMembers()
        {
            var Members = _serviceContext.Members.ToList();
            return Ok(Members);

        }

        [HttpDelete(Name = "DeleteMembers")]
        public IActionResult DeleteMembers(string name)
        {
            var Members = _serviceContext.Members.FirstOrDefault(p => p.name == name);
            if (Members != null)
            {
                _serviceContext.Members.Remove(Members);
                _serviceContext.SaveChanges();
                return Ok("La solicitud se ha eliminado correctamente.");
            }
            else
            {
                return NotFound("no se ha encontrado la solicitud con el identificador especificado.");
            }
        }
        [HttpPut(Name = "UpdateMembers")]
        public IActionResult UpdateMembers(string name, [FromBody] MembersItems updatedMembers)
        {
            var Members = _serviceContext.Members.FirstOrDefault(p => p.name == name);
            if (Members != null)
            {
                Members.name = updatedMembers.name;
                Members.dni = updatedMembers.dni;
                Members.birthdate = updatedMembers.birthdate;
                Members.address = updatedMembers.address;
                Members.phone = updatedMembers.phone;
                Members.email = updatedMembers.email;
                Members.iban = updatedMembers.iban;
                Members.holder = updatedMembers.holder;
                Members.services = updatedMembers.services;
                Members.members = updatedMembers.members;

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