

namespace Taller.Domain.Cores.Repositories
{
    public interface ICrudRepository <T, ID>
    {
        Task<IReadOnlyList<T>> FindAllAsync();

        Task<T?> FindByIdAsync(int id);

        Task<T?> SaveAsync(T entity);

    }
}
