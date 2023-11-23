using Entities;

namespace WebApplicationParkinson.IServices
{
    public interface INewsService
    {
        int InsertNews(NewsItem news);
        IEnumerable<NewsItem> GetAllNews();
        NewsItem UpdateNews(NewsItem news);
        NewsItem DeleteNews(int Id_News);
    }
}
