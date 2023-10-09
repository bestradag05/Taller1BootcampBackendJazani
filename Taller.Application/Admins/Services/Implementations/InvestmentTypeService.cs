using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Taller.Application.Admins.Dtos.InvestmentConcepts;
using Taller.Application.Admins.Dtos.Investments;
using Taller.Application.Admins.Dtos.InvestmentTypes;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Cores.Exceptions;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class InvestmentTypeService : IInvestmentTypeService
    {
        private readonly IInvestmentTypeRepository _investmentTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentTypeService> _logger;

        public InvestmentTypeService(IInvestmentTypeRepository investmentTypeRepository, IMapper mapper, ILogger<InvestmentTypeService> logger)
        {
            _investmentTypeRepository = investmentTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvestmentTypeDto> CreateAsync(InvestmentTypeSaveDto saveDto)
        {
            InvestmentType investmentType = _mapper.Map<InvestmentType>(saveDto);
            investmentType.RegistrationDate = DateTime.Now;
            investmentType.State = true;

             await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<InvestmentTypeDto> DisabledAsync(int id)
        {
            InvestmentType? investmentType = await _investmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null) throw InvestmentTypeNotFound(id);


            _logger.LogInformation("Tipo de inversion encontrado {name}", investmentType.Name);

            investmentType.State = false;

             await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<InvestmentTypeDto> EditAsync(int id, InvestmentTypeSaveDto saveDto)
        {
            InvestmentType? investmentType = await _investmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null) throw InvestmentTypeNotFound(id);


            _logger.LogInformation("Tipo de inversion encontrado {name}", investmentType.Name);

            _mapper.Map<InvestmentTypeSaveDto, InvestmentType>(saveDto, investmentType);

            await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<IReadOnlyList<InvestmentTypeDto>> findAllAsync()
        {
            IReadOnlyList<InvestmentType> iinvestmentTypes = await _investmentTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentTypeDto>>(iinvestmentTypes);
        }

        public async Task<InvestmentTypeDto?> FindByIdAsync(int id)
        {
            InvestmentType? investmentType = await _investmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null) throw InvestmentTypeNotFound(id);


            _logger.LogInformation("Tipo de inversion encontrado {name}", investmentType.Name);

            return _mapper.Map<InvestmentTypeDto?>(investmentType);
        }

        private NotFoundCoreException InvestmentTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de inversion no encontrado para el id: " + id);
        }
    }
}
