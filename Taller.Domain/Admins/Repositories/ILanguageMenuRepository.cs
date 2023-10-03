
using Taller.Domain.Admins.Models;

namespace Taller.Domain.Admins.Repositories
{
    public interface ILanguageMenuRepository
    {
        Task<IReadOnlyList<LanguageMenu>> FindAllAsync();

        Task<LanguageMenu?> FindByIdAsync(int id);

        Task<LanguageMenu?> SaveAsync(LanguageMenu menu);
    }
}
