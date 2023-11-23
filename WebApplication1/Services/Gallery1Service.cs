using Data;
using Entities;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Services
{
    public class Gallery1Service : BaseContextService, IGallery1Service
    {
        public Gallery1Service(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertGallery1(Gallery1Item gallery1Item)
        {
            _serviceContext.Gallery1.Add(gallery1Item);
            _serviceContext.SaveChanges();
            return gallery1Item.Id_gallery1;
        }

        public IEnumerable<Gallery1Item> GetAllGallery1()
        {
            return _serviceContext.Gallery1.ToList();
        }



        public Gallery1Item DeleteGallery1(int id)
        {
            var gallery1ToDelete = _serviceContext.Gallery1.Find(id);
            if (gallery1ToDelete == null)
            {
                return null;
            }

            _serviceContext.Gallery1.Remove(gallery1ToDelete);
            _serviceContext.SaveChanges();

            return gallery1ToDelete;
        }


    }
}
