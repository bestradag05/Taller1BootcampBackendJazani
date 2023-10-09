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
using Taller.Application.Admins.Dtos.MiningConsessions;
using Taller.Application.Cores.Exceptions;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class MiningConsessionService : IMiningConcessionService
    {

        private readonly IMiningConsessionRepository _miningConsessionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MiningConsessionService> _logger;

        public MiningConsessionService(IMiningConsessionRepository miningConsessionRepository, IMapper mapper, ILogger<MiningConsessionService> logger)
        {
            _miningConsessionRepository = miningConsessionRepository;
            _mapper = mapper;
             _logger = logger;
        }

        public async Task<MiningConsessionDto> CreateAsync(MiningConsessionSaveDto saveDto)
        {
            MiningConcession miningConsession = _mapper.Map<MiningConcession>(saveDto);
            miningConsession.RegistrationDate = DateTime.Now;
            miningConsession.State = true;

             await _miningConsessionRepository.SaveAsync(miningConsession);

            return _mapper.Map<MiningConsessionDto>(miningConsession);
        }

        public async Task<MiningConsessionDto> DiasabledAsync(int id)
        {

            MiningConcession? miningConsession = await _miningConsessionRepository.FindByIdAsync(id);

            if (miningConsession is null) throw MiningConcessionNotFound(id);

            _logger.LogInformation("Concesion minera encontrado {name}", miningConsession.Name);

            miningConsession.State = false;

            await _miningConsessionRepository.SaveAsync(miningConsession);

            return _mapper.Map<MiningConsessionDto>(miningConsession);
        }

        public async Task<MiningConsessionDto> EditAsync(int id, MiningConsessionSaveDto saveDto)
        {
            MiningConcession? miningConsession = await _miningConsessionRepository.FindByIdAsync(id);

            if (miningConsession is null) throw MiningConcessionNotFound(id);

            _logger.LogInformation("Concesion minera encontrado {name}", miningConsession.Name);

            _mapper.Map<MiningConsessionSaveDto, MiningConcession>(saveDto, miningConsession);

             await _miningConsessionRepository.SaveAsync(miningConsession);

            return _mapper.Map<MiningConsessionDto>(miningConsession);
        }

        public async Task<IReadOnlyList<MiningConsessionDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcession> miningConsessions= await _miningConsessionRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MiningConsessionDto>>(miningConsessions);
        }

        public async Task<MiningConsessionDto?> FindByIdAsync(int id)
        {
            MiningConcession? miningConsession = await _miningConsessionRepository.FindByIdAsync(id);

            if (miningConsession is null) throw MiningConcessionNotFound(id);

            _logger.LogInformation("Concesion minera encontrado {name}", miningConsession.Name);

            return _mapper.Map<MiningConsessionDto?>(miningConsession);
        }

        private NotFoundCoreException MiningConcessionNotFound(int id)
        {
            return new NotFoundCoreException("Concesion minera no encontrado para el id: " + id);
        }
    }
}
