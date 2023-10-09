using AutoMapper;
using Taller.Application.Admins.Dtos.Documents;
using Taller.Application.Cores.Exceptions;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace Taller.Application.Admins.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IDocumentRepository documentRepository, IMapper mapper, ILogger<DocumentService> logger)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DocumentDto> CreateAsync(DocumentSaveDto saveDto)
        {
            Document document = _mapper.Map<Document>(saveDto);
            document.RegistrationDate = DateTime.Now;
            document.State = true;

             await _documentRepository.SaveAsync(document);

            return _mapper.Map<DocumentDto>(document);
        }

        public async Task<DocumentDto> DisabledAsync(int id)
        {
            Document? document = await _documentRepository.FindByIdAsync(id);

            if (document is null)
            {
                throw DocumentNotFound(id);
            }
            _logger.LogInformation("Documento encontrado {name}", document.Name);

            document.State = false;
            await _documentRepository.SaveAsync(document);

            return _mapper.Map<DocumentDto>(document);
        }

        public async Task<DocumentDto> EditAsync(int id, DocumentSaveDto saveDto)
        {
            Document? document = await _documentRepository.FindByIdAsync(id);

            if (document is null)
            {
                throw DocumentNotFound(id);
            }
            _logger.LogInformation("Documento encontrado {name}", document.Name);

            _mapper.Map<DocumentSaveDto, Document>(saveDto, document);

             await _documentRepository.SaveAsync(document);

            return _mapper.Map<DocumentDto>(document);
        }

        public async Task<IReadOnlyList<DocumentDto>> findAllAsync()
        {
            IReadOnlyList<Document> documents = await _documentRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<DocumentDto>>(documents);
        }

        public async Task<DocumentDto?> FindByIdAsync(int id)
        {
            Document? document = await _documentRepository.FindByIdAsync(id);

            if (document is null)
            {
                throw DocumentNotFound(id);
            }
            _logger.LogInformation("Documento encontrado {name}", document.Name);

            return _mapper.Map<DocumentDto?>(document);
        }

        private NotFoundCoreException DocumentNotFound(int id)
        {
            return new NotFoundCoreException("Documento no encontrado para el id: " + id);
        }
    }
}
