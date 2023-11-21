using Data;
using Entities;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Services
{
    public class WorkService : BaseContextService, IWorkService
    {
        public WorkService(ServiceContext serviceContext) : base(serviceContext)
        {
        }
        public int InsertWorks(WorkItems Works)
        {
            _serviceContext.Works.Add(Works);
            _serviceContext.SaveChanges();
            return Works.Id_Works;
        }
    }
}
