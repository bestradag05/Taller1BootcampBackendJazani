using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Core.Paginations;

namespace Taller.Domain.Cores.Paginations
{
    public interface IPagination<T>
    {
            Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request);  
    }
}
