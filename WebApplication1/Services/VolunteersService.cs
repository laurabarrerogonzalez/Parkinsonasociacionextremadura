using Data;
using Entities;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Services
{
    public class VolunteersService : BaseContextService, IVolunteersService
    {
        public VolunteersService(ServiceContext serviceContext) : base(serviceContext)
        {
        }
        public int InsertVolunteers(VolunteersItems Volunteers)
        {
            _serviceContext.Volunteers.Add(Volunteers);
            _serviceContext.SaveChanges();
            return Volunteers.Id_Volunteers;
        }
    }
}
