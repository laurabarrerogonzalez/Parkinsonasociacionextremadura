using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: api/News
        [HttpGet]
        public IActionResult GetNews()
        {
            // Aquí puedes llamar a tu servicio para obtener todas las noticias
            var news = _newsService.GetAllNews();
            return Ok(news);
        }

        // POST: api/News
        [HttpPost]
        public IActionResult PostNews([FromBody] NewsItem newsItem)
        {
            if (newsItem == null)
            {
                return BadRequest();
            }

            // Aquí puedes llamar a tu servicio para insertar la noticia
            var insertedId = _newsService.InsertNews(newsItem);
            return CreatedAtAction(nameof(GetNews), new { id = insertedId }, newsItem);
        }


        [HttpPut("{Id_News}")]
        public IActionResult PutNews(int Id_News, [FromBody] NewsItem newsItem)
        {
            var existingNews = _newsService.GetAllNews().FirstOrDefault(news => news.Id_News == Id_News);

            if (existingNews == null)
            {
                return NotFound();
            }

            existingNews.title = newsItem.title;
            existingNews.link = newsItem.link;
            existingNews.thumbnail = newsItem.thumbnail;

            var updatedNews = _newsService.UpdateNews(existingNews);

            if (updatedNews == null)
            {
                return NotFound();
            }

            return Ok(updatedNews);
        }







        [HttpDelete("{Id_News}")]
        public IActionResult DeleteNews(int Id_News)
        {
            var deletedNews = _newsService.DeleteNews(Id_News);
            if (deletedNews == null)
            {
                return NotFound();
            }

            return Ok(deletedNews);
        }






    }
}
