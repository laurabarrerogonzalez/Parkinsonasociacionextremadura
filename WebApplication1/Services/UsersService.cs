using Data;
using Entities;
using WebApplicationParkinson.IServices;

namespace WebApplicationParkinson.Services
{
    public class UsersService : BaseContextService, IUsersService
    {
        public UsersService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertUsers(UsersItems Users)
        {
            _serviceContext.UsersItems.Add(Users);
            _serviceContext.SaveChanges();
            return Users.Id_Users;
        }
    }
}
