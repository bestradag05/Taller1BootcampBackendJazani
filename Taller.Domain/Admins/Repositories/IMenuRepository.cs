
using Taller.Domain.Admins.Models;
using Taller.Domain.Cores.Repositories;

namespace Taller.Domain.Admins.Repositories
{
    public interface IMenuRepository : ICrudRepository<Menu, int>
    {
    }
}
