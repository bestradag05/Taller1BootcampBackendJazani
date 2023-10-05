using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Permissions.Profiles
{
    public class PermissionProfiles : Profile
    {
        public PermissionProfiles() { 
            
            CreateMap<Permission, PermissionDto>();
            CreateMap<Permission, PermissionSimpleDto>();
            CreateMap<Permission, PermissionSaveDto>().ReverseMap();
        }
    }
}
