using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Documents.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentDto>();
            CreateMap<Document, DocumentSimpleDto>();
            CreateMap<Document, DocumentSaveDto>().ReverseMap();
        }
    }
}
