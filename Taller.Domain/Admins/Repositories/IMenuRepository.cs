
using Taller.Domain.Admins.Models;

namespace Taller.Domain.Admins.Repositories
{
    public interface IMenuRepository
    {
        Task<IReadOnlyList<Menu>> FindAllAsync();

        Task<Menu?> FindByIdAsync(int id);

        Task<Menu?> SaveAsync(Menu menu);
    }
}
