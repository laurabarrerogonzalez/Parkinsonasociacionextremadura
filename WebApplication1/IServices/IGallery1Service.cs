using Entities;

namespace WebApplicationParkinson.IServices
{
    public interface IGallery1Service
    {
        int InsertGallery1(Gallery1Item gallery1Item);
        IEnumerable<Gallery1Item> GetAllGallery1();
        Gallery1Item DeleteGallery1(int Id_gallery1);
    }
}
