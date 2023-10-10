using Taller.Core.Paginations;

namespace Taller.Domain.Cores.Repositories
{
    public interface IPaginatedRepository<T>
    {
        Task<ResponsePagination<T>> PaginatedSearch(RequestPagination<T> request);
    }
}
