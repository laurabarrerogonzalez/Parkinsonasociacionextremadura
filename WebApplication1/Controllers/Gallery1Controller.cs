using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplicationParkinson.IServices;
using WebApplicationParkinson.Services;


namespace WebApplicationParkinson.Controllers
{
    [Route("api/gallery1")]
    [ApiController]
    public class Gallery1Controller : ControllerBase
    {
        private readonly IGallery1Service _gallery1Service;

        public Gallery1Controller(IGallery1Service gallery1Service)
        {
            _gallery1Service = gallery1Service;
        }

        [HttpGet]
        public IActionResult GetNews()
        {
            // Aquí puedes llamar a tu servicio para obtener todas las noticias
            var gallery1Item = _gallery1Service.GetAllGallery1();
            return Ok(gallery1Item);
        }


        [HttpPost]
        public IActionResult PostGallery([FromBody] Gallery1Item gallery1Item)
        {
            if (gallery1Item == null)
            {
                return BadRequest();
            }

            var insertedId = _gallery1Service.InsertGallery1(gallery1Item);
            if (insertedId == 0)
            {
                return StatusCode(500); // Indica un error interno del servidor si el ID es 0
            }

            // Devuelve el objeto creado con la estructura esperada
            var responseObject = new
            {
                id_gallery1 = insertedId,
                url = gallery1Item.url // Asumiendo que el nombre de la propiedad en la clase es "url"
            };

            return Ok(responseObject);
        }

        [HttpDelete("{Id_gallery1}")]
        public IActionResult DeleteGallery1(int Id_gallery1)
        {
            var deletedGallery1 = _gallery1Service.DeleteGallery1(Id_gallery1);
            if (deletedGallery1 == null)
            {
                return NotFound();
            }

            return Ok(deletedGallery1);
        }

    }
}
