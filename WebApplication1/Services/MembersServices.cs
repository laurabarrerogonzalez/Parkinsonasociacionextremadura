using Data;
using Entities;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Services
{
    public class MembersServices : BaseContextService, IMembersServices
    {
        public MembersServices(ServiceContext serviceContext) : base(serviceContext)
        {
        }
        public int InsertMembers(MembersItems Members)
        {
            _serviceContext.Members.Add(Members);
            _serviceContext.SaveChanges();
            return Members.Id_Members;
        }
    }
}
