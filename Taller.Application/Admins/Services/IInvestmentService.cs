using Taller.Application.Admins.Dtos.Investments;
using Taller.Application.Cores.Services;

namespace Taller.Application.Admins.Services
{
    public interface IInvestmentService : ICrudService<InvestmentDto, InvestmentSaveDto, int>, IPaginatedService<InvestmentDto, InvestmentFilterDto>
    {
    }
}
