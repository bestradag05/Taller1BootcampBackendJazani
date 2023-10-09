using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Admins.Dtos.PeriodTypes;
using Taller.Application.Cores.Exceptions;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class PeriodTypeService : IPeriodTypeService
    {
        private readonly IPeriodTypeRepository _periodTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PeriodTypeService> _logger;

        public PeriodTypeService(IPeriodTypeRepository periodTypeRepository, IMapper mapper, ILogger<PeriodTypeService> logger)
        {
            _periodTypeRepository = periodTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PeriodTypeDto> CreateAsync(PeriodTypeSaveDto saveDto)
        {
            PeriodType periodType = _mapper.Map<PeriodType>(saveDto);
            periodType.RegistrationDate = DateTime.Now;
            periodType.State = true;

            await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<PeriodTypeDto> DiasabledAsync(int id)
        {
            PeriodType? periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null) throw PeriodTypeNotFound(id);

            _logger.LogInformation("Tipo de periodo encontrado {name}", periodType.Name);

            periodType.State = false;

            await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<PeriodTypeDto> EditAsync(int id, PeriodTypeSaveDto saveDto)
        {
            PeriodType? periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null) throw PeriodTypeNotFound(id);

            _logger.LogInformation("Tipo de periodo encontrado {name}", periodType.Name);

            _mapper.Map<PeriodTypeSaveDto, PeriodType>(saveDto, periodType);

             await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PeriodType> periodTypes = await _periodTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PeriodTypeDto>>(periodTypes);
        }

        public async Task<PeriodTypeDto?> FindByIdAsync(int id)
        {
            PeriodType? periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null) throw PeriodTypeNotFound(id);

            _logger.LogInformation("Tipo de periodo encontrado {name}", periodType.Name);

            return _mapper.Map<PeriodTypeDto?>(periodType);
        }

        private NotFoundCoreException PeriodTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de periodo no encontrado para el id: " + id);
        }

    }
}
