using Taller.Application.Admins.Dtos.Investments;

namespace Taller.Application.Admins.Services
{
    public interface IInvestmentService
    {
        Task<IReadOnlyList<InvestmentDto>> findAllAsync();
        Task<InvestmentDto?> FindByIdAsync(int id);
        Task<InvestmentDto> CreateAsync(InvestmentSaveDto saveDto);
        Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto saveDto);
        Task<InvestmentDto> DisabledAsync(int id);
    }
}
