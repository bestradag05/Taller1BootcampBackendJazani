using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Taller.Application.Admins.Dtos.MeasureUnits;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Application.Cores.Exceptions;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class MeasureUnitsService : IMeasureUnitService
    {

        private readonly IMeasureUnitRepository _measureUnitRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MeasureUnitsService> _logger;

        public MeasureUnitsService(IMeasureUnitRepository measureUnitRepository, IMapper mapper, ILogger<MeasureUnitsService> logger)
        {
            _measureUnitRepository = measureUnitRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto saveDto)
        {
            MeasureUnit measureUnit = _mapper.Map<MeasureUnit>(saveDto);
            measureUnit.RegistrationDate = DateTime.Now;
            measureUnit.State = true;

             await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<MeasureUnitDto> DiasabledAsync(int id)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null) throw MeasureUnitNotFound(id);

            _logger.LogInformation("Unidad de medida encontrado {name}", measureUnit.Name);

            measureUnit.State = false;
             await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto saveDto)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null) throw MeasureUnitNotFound(id);

            _logger.LogInformation("Unidad de medida encontrado {name}", measureUnit.Name);

            _mapper.Map<MeasureUnitSaveDto, MeasureUnit>(saveDto, measureUnit);

             await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync()
        {
            IReadOnlyList<MeasureUnit> measureUnits = await _measureUnitRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MeasureUnitDto>>(measureUnits);
        }

        public async Task<MeasureUnitDto?> FindByIdAsync(int id)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null) throw MeasureUnitNotFound(id);

            _logger.LogInformation("Unidad de medida encontrado {name}", measureUnit.Name);

            return _mapper.Map<MeasureUnitDto?>(measureUnit);
        }

        private NotFoundCoreException MeasureUnitNotFound(int id)
        {
            return new NotFoundCoreException("Unidad de medida no encontrado para el id: " + id);
        }
    }
}
