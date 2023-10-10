using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Cores.Models;

namespace Taller.Domain.Cores.Repositories
{
    public interface IBaseRepository<T, ID> where T : CoreModel<ID>
    {
        Task<IReadOnlyList<T>> FindAllAsync();
        Task<T?> FindByIdAsync(ID id);
        Task<T> SaveAsync(T entity);
        Task<T?> DisabledByIdAsync(ID id);
    }
}
