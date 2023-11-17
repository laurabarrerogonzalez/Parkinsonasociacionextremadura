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
    }
}