using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Core.Paginations;

namespace Taller.Application.Cores.Services
{
    public interface IPaginatedService<TDto, TDtoFilter>
    {
        Task<ResponsePagination<TDto>> PaginatedSearch(RequestPagination<TDtoFilter> request); 
    }
}
