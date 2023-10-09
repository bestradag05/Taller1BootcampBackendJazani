using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Cores.Exceptions;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<HolderService> _logger;

        public HolderService(IHolderRepository holderRepository, IMapper mapper, ILogger<HolderService> logger)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<HolderDto> CreateAsync(HolderSaveDto saveDto)
        {
            Holder holder = _mapper.Map<Holder>(saveDto);
            holder.RegistrationDate = DateTime.Now;
            holder.State = true;

             await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holder);
        }

        public async Task<HolderDto> DisabledAsync(int id)
        {
            Holder? holder = await _holderRepository.FindByIdAsync(id);
            if (holder is null)
            {
                throw HolderNotFound(id);
            }
            _logger.LogInformation("Poseedora encontrado {name}", holder.Name);

            holder.State = false;

           await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holder);
        }

        public async Task<HolderDto> EditAsync(int id, HolderSaveDto saveDto)
        {
            Holder? holder = await _holderRepository.FindByIdAsync(id);

            if (holder is null)
            {
                throw HolderNotFound(id);
            }
            _logger.LogInformation("Poseedora encontrado {name}", holder.Name);

            _mapper.Map<HolderSaveDto, Holder>(saveDto, holder);

             await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holder);
        }

        public async Task<IReadOnlyList<HolderDto>> findAllAsync()
        {
            IReadOnlyList<Holder> holders = await _holderRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<HolderDto>>(holders);
        }

        public async Task<HolderDto?> FindByIdAsync(int id)
        {
            Holder? holder = await _holderRepository.FindByIdAsync(id);

            if (holder is null)
            {
                throw HolderNotFound(id);
            }
            _logger.LogInformation("Poseedora encontrado {name}", holder.Name);


            return _mapper.Map<HolderDto>(holder);
        }


        private NotFoundCoreException HolderNotFound(int id)
        {
            return new NotFoundCoreException("Poseedora no encontrado para el id: " + id);
        }
    }
}
