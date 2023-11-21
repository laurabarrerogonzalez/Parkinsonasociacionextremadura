using Data;
using Entities;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Services
{
    public class ResourcesServices : BaseContextService, IResourcesServices
    {
        public ResourcesServices(ServiceContext serviceContext) : base(serviceContext)
        {
        }
        public int InsertResources(ResourcesItems Resources)
        {
            _serviceContext.Resources.Add(Resources);
            _serviceContext.SaveChanges();
            return Resources.Id_Resources;
        }
    }
}
