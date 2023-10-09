using Taller.Application.Admins.Dtos.InvestmentTypes;

namespace Taller.Application.Admins.Services
{
    public interface IInvestmentTypeService
    {
        Task<IReadOnlyList<InvestmentTypeDto>> findAllAsync();
        Task<InvestmentTypeDto?> FindByIdAsync(int id);
        Task<InvestmentTypeDto> CreateAsync(InvestmentTypeSaveDto saveDto);
        Task<InvestmentTypeDto> EditAsync(int id, InvestmentTypeSaveDto saveDto);
        Task<InvestmentTypeDto> DisabledAsync(int id);
    }
}
