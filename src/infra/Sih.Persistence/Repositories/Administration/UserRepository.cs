using Sih.Domain.Interfaces.Administration;
using Sih.Entities.Administration;

namespace Sih.Persistence.Repositories.Administration
{
    public class UserRepository : GenericRepository<UserEntity>, IUserDomain
    {
    }
}
