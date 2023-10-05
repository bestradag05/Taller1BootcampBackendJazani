using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Menus;
using Taller.Domain.Admins.Models;

namespace Taller.Application.Admins.Dtos.Languages
{
    public class LanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }

        public List<MenuSimpleDto> Menus { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
