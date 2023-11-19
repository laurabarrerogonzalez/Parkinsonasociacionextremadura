using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Services
{
    public class NewsService : BaseContextService, INewsService
    {
        public NewsService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertNews(NewsItem news)
        {
            _serviceContext.News.Add(news);
            _serviceContext.SaveChanges();
            return news.Id_News;
        }

        public IEnumerable<NewsItem> GetAllNews()
        {
            return _serviceContext.News.ToList();
        }



        public NewsItem UpdateNews(NewsItem news)
        {
            var existingNews = _serviceContext.News.Find(news.Id_News);
            if (existingNews == null)
            {
                return null;
            }

            existingNews.title = news.title;
            existingNews.link = news.link;
            existingNews.thumbnail = news.thumbnail;

            _serviceContext.News.Update(existingNews);
            _serviceContext.SaveChanges();

            return existingNews;
        }

        public NewsItem DeleteNews(int id)
        {
            var newsToDelete = _serviceContext.News.Find(id);
            if (newsToDelete == null)
            {
                return null;
            }

            _serviceContext.News.Remove(newsToDelete);
            _serviceContext.SaveChanges();

            return newsToDelete;
        }

    }
}
