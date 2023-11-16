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
    [ApiController]
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
                // Realiza el procesamiento de las opciones seleccionadas
                if (Members.Services != null && Members.Services.Count > 0)
                {
                    // Aquí puedes manejar los servicios seleccionados
                    foreach (var service in Members.Services)
                    {
                        // Realiza alguna acción con cada servicio seleccionado
                        Console.WriteLine(service.NameService);
                    }
                }

                // Guarda el miembro y los servicios en la base de datos
                _serviceContext.Members.Add(Members);
                _serviceContext.SaveChanges();

                return Ok("Datos del miembro y servicios guardados correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar los datos del miembro: {ex.Message}");
            }
        }
    }
}