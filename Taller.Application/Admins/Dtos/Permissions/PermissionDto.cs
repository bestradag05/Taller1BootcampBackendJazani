using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Menus;

namespace Taller.Application.Admins.Dtos.Permissions
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Slug { get; set; }

        public List<MenuSimpleDto> Menus { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
