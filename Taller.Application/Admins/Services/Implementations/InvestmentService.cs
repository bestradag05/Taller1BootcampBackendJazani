using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Taller.Application.Admins.Dtos.Investments;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Cores.Exceptions;
using Taller.Core.Paginations;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentService> _logger;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper, ILogger<InvestmentService> logger)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<InvestmentDto>> findAllAsync()
        {
            IReadOnlyList<Investment> investmens = await _investmentRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentDto>>(investmens);
        }

        public async Task<InvestmentDto> FindByIdAsync(int id)
        {
            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null) throw InvestmentNotFound(id);


            _logger.LogInformation("Inversion encontrado");

            return _mapper.Map<InvestmentDto?>(investment);
        }

        public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto saveDto)
        {
            Investment investment = _mapper.Map<Investment>(saveDto);
            investment.RegistrationDate = DateTime.Now;
            investment.State = true;

            Investment investmentSaved = await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investmentSaved);
        }


        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto saveDto)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);

            _mapper.Map<InvestmentSaveDto, Investment>(saveDto, investment);

            Investment investmentSaved = await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investmentSaved);
        }


        public async Task<InvestmentDto> DisabledAsync(int id)
        {

            Investment investment = await _investmentRepository.FindByIdAsync(id);
            investment.State = false;

            Investment investmentSaved = await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investmentSaved);
        }

        public async Task<ResponsePagination<InvestmentDto>> PaginatedSearch(RequestPagination<InvestmentFilterDto> request)
        {
            var entity = _mapper.Map<RequestPagination<Investment>>(request);
            var response = await _investmentRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<InvestmentDto>>(response);
        }

        private NotFoundCoreException InvestmentNotFound(int id)
        {
            return new NotFoundCoreException("Inversion no encontrado para el id: " + id);
        }

       
    }
}
