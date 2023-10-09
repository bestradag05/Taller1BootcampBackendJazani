using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Documents;
using Taller.Application.Admins.Dtos.Languages;

namespace Taller.Application.Admins.Services
{
    public interface IDocumentService
    {
        Task<IReadOnlyList<DocumentDto>> findAllAsync();
        Task<DocumentDto?> FindByIdAsync(int id);
        Task<DocumentDto> CreateAsync(DocumentSaveDto saveDto);
        Task<DocumentDto> EditAsync(int id, DocumentSaveDto saveDto);
        Task<DocumentDto> DisabledAsync(int id);
    }
}
