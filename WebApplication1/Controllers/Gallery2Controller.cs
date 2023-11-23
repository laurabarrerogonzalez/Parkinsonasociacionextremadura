using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplicationParkinson.IServices;
using WebApplicationParkinson.Services;

namespace WebApplicationParkinson.Controllers
{
    [Route("api/gallery2")]
    [ApiController]
    public class Gallery2Controller : ControllerBase
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IGallery2Service _gallery2Service;
        private readonly ServiceContext _serviceContext;

        public Gallery2Controller(IGallery2Service gallery2Service, IConfigurationRoot configuration, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _gallery2Service = gallery2Service;
            _serviceContext = serviceContext;
        }

        public Gallery2Controller(IConfigurationRoot configuration, Gallery2Service gallery2Service, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _gallery2Service = gallery2Service;
            _serviceContext = serviceContext;
        }

        [HttpGet]
        public IActionResult GetNews()
        {
            // Aquí puedes llamar a tu servicio para obtener todas las noticias
            var gallery2Item = _gallery2Service.GetAllGallery2();
            return Ok(gallery2Item);
        }


        [HttpPost]
        public IActionResult PostGallery([FromBody] Gallery2Item gallery2Item)
        {
            if (gallery2Item == null)
            {
                return BadRequest();
            }

            var insertedId = _gallery2Service.InsertGallery2(gallery2Item);
            if (insertedId == 0)
            {
                return StatusCode(500); // Indica un error interno del servidor si el ID es 0
            }

            // Devuelve el objeto creado con la estructura esperada
            var responseObject = new
            {
                id_gallery2 = insertedId,
                url = gallery2Item.url // Asumiendo que el nombre de la propiedad en la clase es "url"
            };

            return Ok(responseObject);
        }

        [HttpDelete("{Id_gallery2}")]
        public IActionResult DeleteGallery2(int Id_gallery2)
        {
            var deletedGallery2 = _gallery2Service.DeleteGallery2(Id_gallery2);
            if (deletedGallery2 == null)
            {
                return NotFound();
            }

            return Ok(deletedGallery2);
        }

    }
}
