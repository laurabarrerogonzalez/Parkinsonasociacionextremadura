using Data;
using Entities;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Services
{
    public class Gallery2Service : BaseContextService, IGallery2Service
    {
        public Gallery2Service(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertGallery2(Gallery2Item gallery2Item)
        {
            _serviceContext.Gallery2.Add(gallery2Item);
            _serviceContext.SaveChanges();
            return gallery2Item.Id_gallery2;
        }

        public IEnumerable<Gallery2Item> GetAllGallery2()
        {
            return _serviceContext.Gallery2.ToList();
        }



        public Gallery2Item DeleteGallery2(int id)
        {
            var gallery2ToDelete = _serviceContext.Gallery2.Find(id);
            if (gallery2ToDelete == null)
            {
                return null;
            }

            _serviceContext.Gallery2.Remove(gallery2ToDelete);
            _serviceContext.SaveChanges();

            return gallery2ToDelete;
        }


    }
}
