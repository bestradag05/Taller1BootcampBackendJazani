

using AutoMapper;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Menus.Mappers
{
    public class menuMapper : Profile
    {
        public menuMapper()
        {

            CreateMap<Menu, MenuDto>();

        }
    }
}
