using Entities;

namespace WebApplicationParkinson.IServices
{
    public interface IGallery2Service
    {
        int InsertGallery2(Gallery2Item gallery2Item);
        IEnumerable<Gallery2Item> GetAllGallery2();
        Gallery2Item DeleteGallery2(int Id_gallery2);
    }
}
