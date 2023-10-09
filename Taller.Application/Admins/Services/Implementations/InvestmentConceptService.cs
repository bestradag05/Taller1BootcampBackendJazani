using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;
using Taller.Application.Admins.Dtos.InvestmentConcepts;
using Taller.Application.Cores.Exceptions;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class InvestmentConceptService : IInvestmentConceptService
    {
        private readonly IInvestmentConceptRepository _investmentConceptRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentConceptService> _logger;

        public InvestmentConceptService(IInvestmentConceptRepository investmentConceptRepository, IMapper mapper, ILogger<InvestmentConceptService> logger)
        {
            _investmentConceptRepository = investmentConceptRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvestmentConceptDto> CreateAsync(InvestmentConceptSaveDto saveDto)
        {
            InvestmentConcept investmentConcept = _mapper.Map<InvestmentConcept>(saveDto);
            investmentConcept.RegistrationDate = DateTime.Now;
            investmentConcept.State = true;

            await _investmentConceptRepository.SaveAsync(investmentConcept);

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<InvestmentConceptDto> DisabledAsync(int id)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);

            if (investmentConcept is null) throw InvestmentConceptFound(id);

            _logger.LogInformation("Concepto de inversion encontrado {name}", investmentConcept.Name);

            investmentConcept.State = false;

            await _investmentConceptRepository.SaveAsync(investmentConcept);

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }


        public async Task<InvestmentConceptDto> EditAsync(int id, InvestmentConceptSaveDto saveDto)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);

            if (investmentConcept is null) throw InvestmentConceptFound(id);

            _logger.LogInformation("Concepto de inversion encontrado {name}", investmentConcept.Name);

            _mapper.Map<InvestmentConceptSaveDto, InvestmentConcept>(saveDto, investmentConcept);

             await _investmentConceptRepository.SaveAsync(investmentConcept);

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<IReadOnlyList<InvestmentConceptDto>> findAllAsync()
        {
            IReadOnlyList<InvestmentConcept> investmentConcepts = await _investmentConceptRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentConceptDto>>(investmentConcepts);
        }

        public async Task<InvestmentConceptDto?> FindByIdAsync(int id)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);

            if (investmentConcept is null) throw InvestmentConceptFound(id);

            _logger.LogInformation("Concepto de inversion encontrado {name}", investmentConcept.Name);

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }


        private NotFoundCoreException InvestmentConceptFound(int id)
        {
            return new NotFoundCoreException("Concepto de inversion no encontrado para el id: " + id);
        }
    }
}
